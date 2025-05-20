namespace ToDoApp.Controls
{
    public partial class GroupCard : UserControl
    {
        public bool IsNewListBtn { get; set; } = false;

        public GroupCard()
        {
            InitializeComponent();

            this.BackColor = Color.Transparent;
            this.TabStop = true;
            this.SetStyle(ControlStyles.Selectable, true);
            this.Dock = DockStyle.None;
            this.Anchor = AnchorStyles.None;

            // Forward Events from all children to raise MainControl (this) Events
            ForwardEvents(panelCardContainer);
            ForwardEvents(pictureBoxCardIcon);
            ForwardEvents(labelCardTitle);
        }

        private void ForwardEvents(Control child)
        {
            child.Click += (s, e) => this.OnClick(e);
            child.MouseEnter += (s, e) => this.OnMouseEnter(e);
            child.MouseLeave += (s, e) => this.OnMouseLeave(e);
            child.MouseDown += (s, e) => this.OnMouseDown(e);
        }

        public void SetGroupData(string groupName, Image icon)
        {
            labelCardTitle.Text = groupName;
            pictureBoxCardIcon.Image = icon;
        }

        //
        // Event Handlers
        //
        private void GroupCard_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkSlateGray;
        }

        private void GroupCard_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        private void GroupCard_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.Teal;
        }

        private void GroupCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.OnClick(EventArgs.Empty);
                e.Handled = true;
            }
        }
    }
}
