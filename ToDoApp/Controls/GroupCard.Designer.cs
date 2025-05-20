namespace ToDoApp.Controls
{
    partial class GroupCard
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBoxCardIcon = new PictureBox();
            labelCardTitle = new Label();
            panelCardContainer = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCardIcon).BeginInit();
            panelCardContainer.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxCardIcon
            // 
            pictureBoxCardIcon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxCardIcon.Location = new Point(0, 0);
            pictureBoxCardIcon.Name = "pictureBoxCardIcon";
            pictureBoxCardIcon.Size = new Size(104, 60);
            pictureBoxCardIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCardIcon.TabIndex = 0;
            pictureBoxCardIcon.TabStop = false;
            // 
            // labelCardTitle
            // 
            labelCardTitle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelCardTitle.AutoEllipsis = true;
            labelCardTitle.Location = new Point(0, 64);
            labelCardTitle.Margin = new Padding(0);
            labelCardTitle.MaximumSize = new Size(0, 40);
            labelCardTitle.Name = "labelCardTitle";
            labelCardTitle.Size = new Size(104, 40);
            labelCardTitle.TabIndex = 1;
            labelCardTitle.Text = "Group Name Test very big";
            labelCardTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelCardContainer
            // 
            panelCardContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCardContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelCardContainer.Controls.Add(pictureBoxCardIcon);
            panelCardContainer.Controls.Add(labelCardTitle);
            panelCardContainer.Location = new Point(8, 8);
            panelCardContainer.MaximumSize = new Size(104, 104);
            panelCardContainer.MinimumSize = new Size(104, 104);
            panelCardContainer.Name = "panelCardContainer";
            panelCardContainer.Size = new Size(104, 104);
            panelCardContainer.TabIndex = 2;
            // 
            // GroupCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.WhiteSmoke;
            Controls.Add(panelCardContainer);
            Margin = new Padding(0);
            MaximumSize = new Size(120, 120);
            MinimumSize = new Size(120, 120);
            Name = "GroupCard";
            Padding = new Padding(8);
            Size = new Size(120, 120);
            Enter += GroupCard_MouseEnter;
            KeyDown += GroupCard_KeyDown;
            Leave += GroupCard_MouseLeave;
            MouseDown += GroupCard_MouseDown;
            MouseEnter += GroupCard_MouseEnter;
            MouseLeave += GroupCard_MouseLeave;
            ((System.ComponentModel.ISupportInitialize)pictureBoxCardIcon).EndInit();
            panelCardContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxCardIcon;
        private Label labelCardTitle;
        private Panel panelCardContainer;
    }
}
