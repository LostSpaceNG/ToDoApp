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

        // Connection String for DB Setup
        string connectionString = "Data Source=tasks.db;Version=3;";

        // Creates DB if doesn't exist
        private void CreateDatabase()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Create Tasks Table with Id and Task Columns
                string sql = @"CREATE TABLE IF NOT EXISTS Tasks (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Task TEXT,
                                IsDone INTEGER DEFAULT 0
                             )";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        // Loads Tasks from DB
        private void LoadTasks()
        {
            // create connection with DB
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                // create SQL command
                string sql = "SELECT Task, IsDone FROM Tasks";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                // Read Data from column "Task" and add to Tasklist
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string task = reader["Task"].ToString()!;
                        bool isDone = Convert.ToInt32(reader["IsDone"]) == 1;
                        clbTasks.Items.Add(task, isDone);
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Check the input field
            if (!string.IsNullOrWhiteSpace(txtTask.Text))
            {
                // Save Task in DB
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO Tasks (Task, IsDone) VALUES (@task, 0)";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@task", txtTask.Text);
                    cmd.ExecuteNonQuery();
                }

                // Add to Tasklist
                clbTasks.Items.Add(txtTask.Text, false);
                // Clear input field
                txtTask.Clear();
            }
            else
            {
                // show Info Message
                MessageBox.Show("Please enter a Task first.", "Task Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Remove selected Task from Tasklist
            if (clbTasks.SelectedIndex >= 0)
            {
                string taskText = clbTasks.SelectedItem!.ToString()!;

                // Remove from DB
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM Tasks WHERE Task = @task";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@task", taskText);
                    cmd.ExecuteNonQuery();
                }

                // Remove from UI
                clbTasks.Items.RemoveAt(clbTasks.SelectedIndex);
            }
            else
            {
                // show Info Message
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
                    string sql = "UPDATE Tasks SET IsDone = @isDone WHERE Task = @task";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@isDone", isDone);
                    cmd.Parameters.AddWithValue("@task", taskText);
                    cmd.ExecuteNonQuery();
                }
            }));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateDatabase();
            LoadTasks();
        }
    }
}
