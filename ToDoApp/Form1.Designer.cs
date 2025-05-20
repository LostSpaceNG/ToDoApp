namespace ToDoApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelTasks = new Panel();
            btnEditTask = new Button();
            btnBackToMenu = new Button();
            btnDeleteTask = new Button();
            btnAddTask = new Button();
            checkedListBoxTasks = new CheckedListBox();
            labelGroupTitle = new Label();
            contextMenuGroup = new ContextMenuStrip(components);
            renameGroupToolStripMenuItem = new ToolStripMenuItem();
            deleteGroupToolStripMenuItem = new ToolStripMenuItem();
            panelTasks.SuspendLayout();
            contextMenuGroup.SuspendLayout();
            SuspendLayout();
            // 
            // panelTasks
            // 
            panelTasks.BackColor = Color.FromArgb(21, 21, 21);
            panelTasks.Controls.Add(btnEditTask);
            panelTasks.Controls.Add(btnBackToMenu);
            panelTasks.Controls.Add(btnDeleteTask);
            panelTasks.Controls.Add(btnAddTask);
            panelTasks.Controls.Add(checkedListBoxTasks);
            panelTasks.Controls.Add(labelGroupTitle);
            panelTasks.Dock = DockStyle.Fill;
            panelTasks.Location = new Point(0, 0);
            panelTasks.Name = "panelTasks";
            panelTasks.Size = new Size(762, 533);
            panelTasks.TabIndex = 13;
            panelTasks.Visible = false;
            // 
            // btnEditTask
            // 
            btnEditTask.Anchor = AnchorStyles.Bottom;
            btnEditTask.Location = new Point(319, 460);
            btnEditTask.Name = "btnEditTask";
            btnEditTask.Size = new Size(124, 29);
            btnEditTask.TabIndex = 4;
            btnEditTask.Text = "Edit Task";
            btnEditTask.UseVisualStyleBackColor = true;
            btnEditTask.Click += BtnEditTask_Click;
            // 
            // btnBackToMenu
            // 
            btnBackToMenu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBackToMenu.Location = new Point(618, 40);
            btnBackToMenu.Name = "btnBackToMenu";
            btnBackToMenu.Size = new Size(80, 29);
            btnBackToMenu.TabIndex = 1;
            btnBackToMenu.Text = "← Back";
            btnBackToMenu.UseVisualStyleBackColor = true;
            btnBackToMenu.Click += BtnBackToMenu_Click;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.Anchor = AnchorStyles.Bottom;
            btnDeleteTask.Location = new Point(475, 460);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(124, 29);
            btnDeleteTask.TabIndex = 5;
            btnDeleteTask.Text = "Delete Task";
            btnDeleteTask.UseVisualStyleBackColor = true;
            btnDeleteTask.Click += BtnDeleteTask_Click;
            // 
            // btnAddTask
            // 
            btnAddTask.Anchor = AnchorStyles.Bottom;
            btnAddTask.Location = new Point(163, 460);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(124, 29);
            btnAddTask.TabIndex = 3;
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += BtnAddTask_Click;
            // 
            // checkedListBoxTasks
            // 
            checkedListBoxTasks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkedListBoxTasks.BackColor = Color.White;
            checkedListBoxTasks.Font = new Font("Segoe UI Variable Small Semilig", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkedListBoxTasks.FormattingEnabled = true;
            checkedListBoxTasks.Location = new Point(64, 96);
            checkedListBoxTasks.Name = "checkedListBoxTasks";
            checkedListBoxTasks.Size = new Size(634, 316);
            checkedListBoxTasks.TabIndex = 2;
            checkedListBoxTasks.ItemCheck += CheckedListBoxTasks_ItemCheck;
            // 
            // labelGroupTitle
            // 
            labelGroupTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelGroupTitle.AutoEllipsis = true;
            labelGroupTitle.Font = new Font("Segoe UI", 14F);
            labelGroupTitle.ForeColor = Color.White;
            labelGroupTitle.Location = new Point(64, 35);
            labelGroupTitle.Name = "labelGroupTitle";
            labelGroupTitle.Size = new Size(535, 32);
            labelGroupTitle.TabIndex = 0;
            labelGroupTitle.Text = "Title";
            // 
            // contextMenuGroup
            // 
            contextMenuGroup.ImageScalingSize = new Size(20, 20);
            contextMenuGroup.Items.AddRange(new ToolStripItem[] { renameGroupToolStripMenuItem, deleteGroupToolStripMenuItem });
            contextMenuGroup.Name = "contextMenuGroup";
            contextMenuGroup.Size = new Size(133, 52);
            // 
            // renameGroupToolStripMenuItem
            // 
            renameGroupToolStripMenuItem.Name = "renameGroupToolStripMenuItem";
            renameGroupToolStripMenuItem.Size = new Size(132, 24);
            renameGroupToolStripMenuItem.Text = "Rename";
            renameGroupToolStripMenuItem.Click += RenameGroupToolStripMenuItem_Click;
            // 
            // deleteGroupToolStripMenuItem
            // 
            deleteGroupToolStripMenuItem.Name = "deleteGroupToolStripMenuItem";
            deleteGroupToolStripMenuItem.Size = new Size(132, 24);
            deleteGroupToolStripMenuItem.Text = "Delete";
            deleteGroupToolStripMenuItem.Click += DeleteGroupToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(762, 533);
            Controls.Add(panelTasks);
            MinimumSize = new Size(780, 580);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ToDo App";
            Load += Form1_Load;
            panelTasks.ResumeLayout(false);
            contextMenuGroup.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelTasks;
        private Label labelGroupTitle;
        private CheckedListBox checkedListBoxTasks;
        private Button btnBackToMenu;
        private Button btnDeleteTask;
        private Button btnAddTask;
        private ContextMenuStrip contextMenuGroup;
        private ToolStripMenuItem renameGroupToolStripMenuItem;
        private ToolStripMenuItem deleteGroupToolStripMenuItem;
        private Button btnEditTask;
    }
}
