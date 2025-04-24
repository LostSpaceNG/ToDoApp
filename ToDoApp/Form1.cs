using System.Data.SqlClient;
using System.Data.SQLite;
using System.Xml.Serialization;

namespace ToDoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // App Version Info
        private const string AppVersion = "1.1.0";

        // Connection String for DB Setup
        string connectionString = "Data Source=tasks.db;Version=3;";

        // Creates DB if doesn't exist
        private void CreateDatabase()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Create Tasks Table if not exists
                string query = @"CREATE TABLE IF NOT EXISTS Tasks (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Title TEXT NOT NULL,
                                IsDone INTEGER DEFAULT 0
                             )";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();

                // Create TaskGroups Table if not exists
                var cmd1 = new SQLiteCommand(@"
                    CREATE TABLE IF NOT EXISTS TaskGroups (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL UNIQUE
                    );", conn);
                cmd1.ExecuteNonQuery();

                // Insert Default Group if not exists
                var cmd2 = new SQLiteCommand(@"
                    INSERT OR IGNORE INTO TaskGroups (Id, Name)
                    VALUES (1, 'Default');", conn);
                cmd2.ExecuteNonQuery();

                // Add GroupId to Tasks table if not exists
                var cmd3 = new SQLiteCommand(@"
                    PRAGMA table_info(Tasks);", conn);

                bool hasGroupId = false;

                using (var reader = cmd3.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["name"].ToString() == "GroupId")
                        {
                            hasGroupId = true;
                            break;
                        }
                    }
                }

                if (!hasGroupId)
                {
                    var alterCmd = new SQLiteCommand(@"
                        ALTER TABLE Tasks ADD COLUMN GroupId INTEGER DEFAULT 1;", conn);
                    alterCmd.ExecuteNonQuery();
                }
            }
        }

        // Loads Tasks from DB
        private void LoadTasks(int? groupId = null)
        {
            // Clear Task list
            clbTasks.Items.Clear();

            // Create connection with DB
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Create SQL Query
                string query = "SELECT * FROM Tasks";
                if (groupId != null)
                {
                    query += " WHERE GroupId = @groupId";
                }

                // Prepare SQL Command
                var command = new SQLiteCommand(query, conn);
                if (groupId != null)
                {
                    command.Parameters.AddWithValue("@groupId", groupId);
                }

                // Read data from Tasks Table
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TaskItem item = new TaskItem
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Title = reader["Title"].ToString()!,
                            IsDone = Convert.ToInt32(reader["IsDone"]) == 1,
                            GroupId = Convert.ToInt32(reader["GroupId"])
                        };

                        // Add Tasks to UI Task list
                        clbTasks.Items.Add(item, item.IsDone);
                    }
                }
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string taskTitle = textBoxTask.Text.Trim();

            // Return, if Task is empty
            if (string.IsNullOrWhiteSpace(taskTitle))
            {
                MessageBox.Show("Please enter a Task first.", "Task Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Add Task to Group
            if (comboBoxTaskGroups.SelectedItem is Group selectedGroup)
            {
                // Save Task in DB
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string sql = "INSERT INTO Tasks (Title, IsDone, GroupId) VALUES (@task, 0, @groupId)";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@task", taskTitle);
                    cmd.Parameters.AddWithValue("@groupId", selectedGroup.Id);
                    cmd.ExecuteNonQuery();
                }

                // Clear input field
                textBoxTask.Clear();
                // Refresh Task list
                LoadTasks(selectedGroup.Id);
            }
            else
            {
                // Show Info Message
                MessageBox.Show("Please select a Task Group.", "Task Group Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            // Remove selected Task from Tasklist
            if (clbTasks.SelectedIndex >= 0)
            {
                string taskText = clbTasks.SelectedItem!.ToString()!;

                // Remove from DB
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM Tasks WHERE Title = @task";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@task", taskText);
                    cmd.ExecuteNonQuery();
                }

                // Remove from UI
                clbTasks.Items.RemoveAt(clbTasks.SelectedIndex);
            }
            else
            {
                // Show Info Message
                MessageBox.Show("Please select a Task first.", "Task Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void clbTasks_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Update the DB after the UI has updated
            // (makes sure we are reading the correct, updated checkbox state)
            this.BeginInvoke(new Action(() =>
            {
                string taskText = clbTasks.Items[e.Index].ToString()!;
                int isDone = clbTasks.GetItemChecked(e.Index) ? 1 : 0;

                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "UPDATE Tasks SET IsDone = @isDone WHERE Title = @task";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@isDone", isDone);
                    cmd.Parameters.AddWithValue("@task", taskText);
                    cmd.ExecuteNonQuery();
                }
            }));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += $" | v{AppVersion}";
            CreateDatabase();
            LoadGroups();
        }

        // -------- NEW ---------
        private void LoadGroups()
        {
            // Clear Group list
            comboBoxTaskGroups.Items.Clear();

            // Retrieve Groups from DB
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand(@"
                    SELECT Id, Name FROM TaskGroups", conn);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBoxTaskGroups.Items.Add(new Group
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
            }

            // Auto-select first group
            if (comboBoxTaskGroups.Items.Count > 0)
                comboBoxTaskGroups.SelectedIndex = 0;
        }

        private void comboBoxTaskGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTaskGroups.SelectedItem is Group selectedGroup)
            {
                LoadTasks(selectedGroup.Id);
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            // Ask user for list name
            var input = Microsoft.VisualBasic.Interaction.InputBox("Enter new list name:", "New Task List");
            if (string.IsNullOrWhiteSpace(input))
                return;

            // Add new list to Task Groups
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand(@"
                    INSERT OR IGNORE INTO TaskGroups (Name) VALUES (@name);", conn);
                cmd.Parameters.AddWithValue("@name", input.Trim());
                cmd.ExecuteNonQuery();
            }

            // Refresh Task Groups
            LoadGroups();
        }
    }

    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public override string ToString() => Name;
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsDone { get; set; }
        public int GroupId { get; set; }
        public override string ToString() => Title;
    }
}
