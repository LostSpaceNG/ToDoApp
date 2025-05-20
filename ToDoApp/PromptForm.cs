namespace ToDoApp
{
    public partial class PromptForm : Form
    {
        public string ResponseText
        {
            get => textBoxInput.Text;
            set => textBoxInput.Text = value;
        }

        public PromptForm(string title, string message)
        {
            InitializeComponent();
            this.Text = title;
            labelPrompt.Text = message;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            // Input Validation
            if (string.IsNullOrWhiteSpace(textBoxInput.Text))
            {
                MessageBox.Show("Input cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
