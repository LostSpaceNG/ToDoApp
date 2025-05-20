using ToDoApp.Controls;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp
{
    public partial class Form1 : Form
    {
        // App Version Info
        private const string AppVersion = "1.2.0";

        private Group? selectedGroup;
        private GroupCardsPanel? groupCardsPanel;
        private Bitmap groupIcon = Properties.Resources.TaskGroupIcon;
        private Bitmap addGroupIcon = Properties.Resources.AddNewIcon;

        private readonly DatabaseService dbService = new DatabaseService();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += $" | v{AppVersion}";

            dbService.InitializeDatabase();
            InitializeGroupCardsPanel();
            ShowGroupView();

            LoadGroupCards(dbService.GetAllGroups());
        }

        // Workaround to fix UI layout bug on first form load
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            groupCardsPanel!.RefreshLayout();
        }

        #region Group View Logic

        // Show Group View
        private void ShowGroupView()
        {
            panelTasks.Visible = false;
            groupCardsPanel!.Visible = true;
        }

        // Initialize the container panel for the group cards
        private void InitializeGroupCardsPanel()
        {
            groupCardsPanel = new GroupCardsPanel
            {
                Dock = DockStyle.Fill,
                BackColor = panelTasks.BackColor,
                ForeColor = panelTasks.ForeColor,
            };

            this.Controls.Add(groupCardsPanel);
        }

        // Load and render all Groups as GroupCard Controls
        private void LoadGroupCards(List<Group> groups)
        {
            var cards = new List<Control>();

            // Create the "New List" Button
            var newListCard = new GroupCard
            {
                ForeColor = Color.White,
                IsNewListBtn = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            newListCard.SetGroupData("New List", addGroupIcon);
            newListCard.Click += CreateNewGroup!;
            cards.Add(newListCard);

            // Create all cards
            foreach (var group in groups)
            {
                var card = new GroupCard
                {
                    Tag = group,
                    ContextMenuStrip = contextMenuGroup,
                    ForeColor = Color.White,
                };
                card.SetGroupData(group.Name, groupIcon);
                card.Click += GroupCard_Click!;
                cards.Add(card);
            }

            groupCardsPanel!.SetCards(cards);
        }

        // "Click" - Event Handler for Group Card
        private void GroupCard_Click(object sender, EventArgs e)
        {
            if (sender is GroupCard card && card.Tag is Group group)
            {
                selectedGroup = group;
                labelGroupTitle.Text = selectedGroup.Name;
                LoadTasksForGroup(selectedGroup.Id);
                ShowTaskView();
            }
        }

        // Creates a new Group
        private void CreateNewGroup(object sender, EventArgs e)
        {
            // Load PromptForm to ask for user input
            using (PromptForm prompt = new PromptForm("New List", "Enter the list name:"))
            {
                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    string groupName = prompt.ResponseText;

                    if (!string.IsNullOrWhiteSpace(groupName))
                    {
                        // Add the new Group and refresh the Group View
                        dbService.AddGroup(groupName);
                        LoadGroupCards(dbService.GetAllGroups());
                        // Refresh Panel to avoid UI Bug
                        groupCardsPanel!.RefreshLayout();
                    }
                }
            }
        }

        // Rename a Group
        private void RenameGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contextMenuGroup.SourceControl is GroupCard groupCard && groupCard.Tag is Group group)
            {
                // Load PromptForm to ask for user input
                using (PromptForm prompt = new PromptForm("Rename List", "Enter the new list name:"))
                {
                    // Pass old value
                    prompt.ResponseText = group.Name;

                    if (prompt.ShowDialog() == DialogResult.OK)
                    {
                        string newGroupName = prompt.ResponseText;

                        if (!string.IsNullOrWhiteSpace(newGroupName))
                        {
                            // Update the Group and refresh the Group View
                            dbService.RenameGroup(group.Id, newGroupName);
                            LoadGroupCards(dbService.GetAllGroups());
                            // Refresh Panel to avoid UI Bug
                            groupCardsPanel!.RefreshLayout();
                        }
                    }
                }
            }
        }

        // Delete a Group
        private void DeleteGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contextMenuGroup.SourceControl is GroupCard groupCard && groupCard.Tag is Group group)
            {
                // Ask for confirmation
                var confirm = MessageBox.Show($"Delete list '{group.Name}' and all its tasks?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    // Delete the Group and refresh the Group View
                    dbService.DeleteGroup(group.Id);
                    LoadGroupCards(dbService.GetAllGroups());
                    // Refresh Panel to avoid UI Bug
                    groupCardsPanel!.RefreshLayout();
                }
            }
        }

        #endregion

        #region Task Panel Logic

        // Show Task Panel
        private void ShowTaskView()
        {
            groupCardsPanel!.Visible = false;
            panelTasks.Visible = true;
        }

        // Load Tasks for a selected Group
        private void LoadTasksForGroup(int groupId)
        {
            // Clear Task list
            checkedListBoxTasks.Items.Clear();

            // Get and load Tasks
            List<TaskItem> tasks = dbService.GetTasksByGroupId(groupId);
            foreach (TaskItem task in tasks)
            {
                int index = checkedListBoxTasks.Items.Add(task);
                checkedListBoxTasks.SetItemChecked(index, task.IsDone);
            }
        }

        //
        // Event Handlers
        //
        private void BtnBackToMenu_Click(object sender, EventArgs e)
        {
            ShowGroupView();
        }

        private void BtnAddTask_Click(object sender, EventArgs e)
        {
            // Load PromptForm to ask for user input
            using (PromptForm prompt = new PromptForm("New Task", "Enter the task:"))
            {
                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    string taskTitle = prompt.ResponseText;

                    if (!string.IsNullOrWhiteSpace(taskTitle))
                    {
                        // Add the new Task and refresh the Task View
                        dbService.AddTask(taskTitle, selectedGroup!.Id);
                        LoadTasksForGroup(selectedGroup.Id);
                    }
                }
            }
        }

        private void BtnEditTask_Click(object sender, EventArgs e)
        {
            if (checkedListBoxTasks.SelectedItem is TaskItem selectedTask)
            {
                // Load PromptForm to ask for user input
                using (PromptForm prompt = new PromptForm("Edit Task", "Edit the task:"))
                {
                    // Pass old value
                    prompt.ResponseText = selectedTask.Title;

                    if (prompt.ShowDialog() == DialogResult.OK)
                    {
                        string newTaskTitle = prompt.ResponseText;

                        if (!string.IsNullOrWhiteSpace(newTaskTitle))
                        {
                            // Update the Task and refresh the Task View
                            dbService.EditTask(selectedTask.Id, newTaskTitle);
                            LoadTasksForGroup(selectedGroup!.Id);
                        }
                    }
                }
            }
            else
            {
                // Show Info Message
                MessageBox.Show("Please select a Task first.", "Task Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDeleteTask_Click(object sender, EventArgs e)
        {
            if (checkedListBoxTasks.SelectedItem is TaskItem selectedTask)
            {
                // Delete the Task and refresh the Task View
                dbService.DeleteTask(selectedTask.Id);
                LoadTasksForGroup(selectedGroup!.Id);
            }
            else
            {
                // Show Info Message
                MessageBox.Show("Please select a Task first.", "Task Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CheckedListBoxTasks_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Update the DB after the UI has updated
            // (makes sure we are reading the correct, updated checkbox state)
            this.BeginInvoke(new Action(() =>
            {
                if (checkedListBoxTasks.SelectedItem is TaskItem selectedTask)
                {
                    bool isDone = checkedListBoxTasks.GetItemChecked(e.Index);

                    dbService.UpdateTaskStatus(selectedTask.Id, isDone);
                }
            }));
        }

        #endregion

    }
}
