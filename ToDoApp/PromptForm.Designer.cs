namespace ToDoApp
{
    partial class PromptForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelPrompt = new Label();
            textBoxInput = new TextBox();
            btnConfirm = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // labelPrompt
            // 
            labelPrompt.AutoSize = true;
            labelPrompt.Location = new Point(15, 9);
            labelPrompt.Name = "labelPrompt";
            labelPrompt.Size = new Size(61, 20);
            labelPrompt.TabIndex = 0;
            labelPrompt.Text = "Prompt:";
            // 
            // textBoxInput
            // 
            textBoxInput.Location = new Point(16, 40);
            textBoxInput.Multiline = true;
            textBoxInput.Name = "textBoxInput";
            textBoxInput.ScrollBars = ScrollBars.Vertical;
            textBoxInput.Size = new Size(340, 90);
            textBoxInput.TabIndex = 1;
            // 
            // btnConfirm
            // 
            btnConfirm.DialogResult = DialogResult.OK;
            btnConfirm.Location = new Point(202, 153);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(74, 29);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "OK";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += BtnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(282, 153);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(74, 29);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // PromptForm
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(372, 203);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(textBoxInput);
            Controls.Add(labelPrompt);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "PromptForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PromptForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPrompt;
        private TextBox textBoxInput;
        private Button btnConfirm;
        private Button btnCancel;
    }
}