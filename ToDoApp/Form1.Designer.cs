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
            textBoxTask = new TextBox();
            btnAddTask = new Button();
            btnDeleteTask = new Button();
            clbTasks = new CheckedListBox();
            comboBoxTaskGroups = new ComboBox();
            btnAddGroup = new Button();
            labelGroupInfo = new Label();
            labelTaskArea = new Label();
            labelListInfo = new Label();
            labelTaskInfo = new Label();
            SuspendLayout();
            // 
            // textBoxTask
            // 
            textBoxTask.Location = new Point(12, 209);
            textBoxTask.Multiline = true;
            textBoxTask.Name = "textBoxTask";
            textBoxTask.ScrollBars = ScrollBars.Vertical;
            textBoxTask.Size = new Size(400, 90);
            textBoxTask.TabIndex = 0;
            // 
            // btnAddTask
            // 
            btnAddTask.AutoSize = true;
            btnAddTask.Location = new Point(418, 207);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(128, 30);
            btnAddTask.TabIndex = 2;
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.AutoSize = true;
            btnDeleteTask.Location = new Point(418, 360);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(128, 30);
            btnDeleteTask.TabIndex = 3;
            btnDeleteTask.Text = "Delete Task";
            btnDeleteTask.UseVisualStyleBackColor = true;
            btnDeleteTask.Click += btnDeleteTask_Click;
            // 
            // clbTasks
            // 
            clbTasks.CheckOnClick = true;
            clbTasks.FormattingEnabled = true;
            clbTasks.Location = new Point(12, 360);
            clbTasks.Name = "clbTasks";
            clbTasks.Size = new Size(400, 180);
            clbTasks.TabIndex = 5;
            clbTasks.ItemCheck += clbTasks_ItemCheck;
            // 
            // comboBoxTaskGroups
            // 
            comboBoxTaskGroups.FormattingEnabled = true;
            comboBoxTaskGroups.Location = new Point(12, 32);
            comboBoxTaskGroups.Name = "comboBoxTaskGroups";
            comboBoxTaskGroups.Size = new Size(400, 28);
            comboBoxTaskGroups.TabIndex = 6;
            comboBoxTaskGroups.SelectedIndexChanged += comboBoxTaskGroups_SelectedIndexChanged;
            // 
            // btnAddGroup
            // 
            btnAddGroup.Location = new Point(418, 30);
            btnAddGroup.Name = "btnAddGroup";
            btnAddGroup.Size = new Size(128, 30);
            btnAddGroup.TabIndex = 7;
            btnAddGroup.Text = "Add List";
            btnAddGroup.UseVisualStyleBackColor = true;
            btnAddGroup.Click += btnAddGroup_Click;
            // 
            // labelGroupInfo
            // 
            labelGroupInfo.AutoSize = true;
            labelGroupInfo.Location = new Point(12, 9);
            labelGroupInfo.Name = "labelGroupInfo";
            labelGroupInfo.Size = new Size(149, 20);
            labelGroupInfo.TabIndex = 8;
            labelGroupInfo.Text = "Choose a Task Group:";
            // 
            // labelTaskArea
            // 
            labelTaskArea.AutoSize = true;
            labelTaskArea.Font = new Font("Segoe UI", 14F);
            labelTaskArea.Location = new Point(187, 127);
            labelTaskArea.Name = "labelTaskArea";
            labelTaskArea.Size = new Size(208, 32);
            labelTaskArea.TabIndex = 9;
            labelTaskArea.Text = "Task Management";
            // 
            // labelListInfo
            // 
            labelListInfo.AutoSize = true;
            labelListInfo.Location = new Point(12, 337);
            labelListInfo.Name = "labelListInfo";
            labelListInfo.Size = new Size(65, 20);
            labelListInfo.TabIndex = 10;
            labelListInfo.Text = "Task List:";
            // 
            // labelTaskInfo
            // 
            labelTaskInfo.AutoSize = true;
            labelTaskInfo.Location = new Point(12, 186);
            labelTaskInfo.Name = "labelTaskInfo";
            labelTaskInfo.Size = new Size(83, 20);
            labelTaskInfo.TabIndex = 11;
            labelTaskInfo.Text = "Task Name:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 553);
            Controls.Add(labelTaskInfo);
            Controls.Add(labelListInfo);
            Controls.Add(labelTaskArea);
            Controls.Add(labelGroupInfo);
            Controls.Add(btnAddGroup);
            Controls.Add(comboBoxTaskGroups);
            Controls.Add(clbTasks);
            Controls.Add(btnDeleteTask);
            Controls.Add(btnAddTask);
            Controls.Add(textBoxTask);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimumSize = new Size(600, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ToDo App";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxTask;
        private Button btnAddTask;
        private Button btnDeleteTask;
        private CheckedListBox clbTasks;
        private ComboBox comboBoxTaskGroups;
        private Button btnAddGroup;
        private Label labelGroupInfo;
        private Label labelTaskArea;
        private Label labelListInfo;
        private Label labelTaskInfo;
    }
}
