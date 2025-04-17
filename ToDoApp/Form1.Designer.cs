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
            txtTask = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            clbTasks = new CheckedListBox();
            SuspendLayout();
            // 
            // txtTask
            // 
            txtTask.Location = new Point(12, 12);
            txtTask.Name = "txtTask";
            txtTask.Size = new Size(329, 27);
            txtTask.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.AutoSize = true;
            btnAdd.Location = new Point(12, 56);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(128, 30);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add Task";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.AutoSize = true;
            btnDelete.Location = new Point(12, 252);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(128, 30);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete Task";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // clbTasks
            // 
            clbTasks.FormattingEnabled = true;
            clbTasks.Location = new Point(12, 122);
            clbTasks.Name = "clbTasks";
            clbTasks.Size = new Size(329, 114);
            clbTasks.TabIndex = 5;
            clbTasks.ItemCheck += clbTasks_ItemCheck;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 553);
            Controls.Add(clbTasks);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(txtTask);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ToDo App";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTask;
        private Button btnAdd;
        private Button btnDelete;
        private CheckedListBox clbTasks;
    }
}
