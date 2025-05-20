using System.Data.SQLite;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    internal class DatabaseService
    {
        private readonly string _connectionString = "Data Source=tasks.db;Version=3;";

        // Exception Handling Helper
        private void ExecuteSafely(Action dbAction)
        {
            try
            {
                dbAction();
            }
            catch (SQLiteException ex)
            {
                if (ex.ResultCode == SQLiteErrorCode.Constraint)
                {
                    MessageBox.Show("This entry already exists or violates a constraint.", "Constraint Violation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Database error: {ex.Message}", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InitializeDatabase()
        {
            ExecuteSafely(() =>
            {
                // Connect to Database
                using var connection = new SQLiteConnection(_connectionString);
                connection.Open();

                // Main Command for Table Creation
                SQLiteCommand cmd = connection.CreateCommand();
                // Create Tables "Tasks" and "TaskGroups" if not exists
                cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS TaskGroups (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL UNIQUE
                );

                CREATE TABLE IF NOT EXISTS Tasks (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    IsDone INTEGER DEFAULT 0
                );";

                cmd.ExecuteNonQuery();

                // Insert Default Group into Task Groups if not exists
                var cmd2 = new SQLiteCommand(@"
                    INSERT OR IGNORE INTO TaskGroups (Id, Name)
                    VALUES (1, 'Default');", connection);
                cmd2.ExecuteNonQuery();

                // Add GroupId to Tasks table if not exists
                var cmd3 = new SQLiteCommand(@"PRAGMA table_info(Tasks);", connection);

                bool hasGroupId = false;

                using var reader = cmd3.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["name"].ToString() == "GroupId")
                    {
                        hasGroupId = true;
                        break;
                    }
                }

                if (!hasGroupId)
                {
                    var alterCmd = new SQLiteCommand(@"
                        ALTER TABLE Tasks ADD COLUMN GroupId INTEGER DEFAULT 1;", connection);
                    alterCmd.ExecuteNonQuery();
                }
            });
        }


        #region TASK Operations

        //
        // Manage Tasks
        //

        // Add new Task
        public void AddTask(string title, int groupId, bool isDone = false)
        {
            ExecuteSafely(() =>
            {
                // Connect to Database
                using var connection = new SQLiteConnection(_connectionString);
                connection.Open();

                // Create SQL query
                string query = "INSERT INTO Tasks (Title, IsDone, GroupId) VALUES (@title, @isDone, @groupId)";
                // Prepare and execute SQL Command
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@isDone", isDone ? 1 : 0);
                cmd.Parameters.AddWithValue("@groupId", groupId);
                cmd.ExecuteNonQuery();
            });
        }

        // Edit Task
        public void EditTask(int taskId, string newTitle)
        {
            ExecuteSafely(() =>
            {
                // Connect to Database
                using var connection = new SQLiteConnection(_connectionString);
                connection.Open();

                // Create SQL query
                string query = "UPDATE Tasks SET Title = @title WHERE Id = @id";
                // Prepare and execute SQL Command
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@title", newTitle);
                cmd.Parameters.AddWithValue("@id", taskId);
                cmd.ExecuteNonQuery();
            });
        }

        // Delete Task
        public void DeleteTask(int taskId)
        {
            ExecuteSafely(() =>
            {
                // Connect to Database
                using var connection = new SQLiteConnection(_connectionString);
                connection.Open();

                // Create SQL query
                string query = "DELETE FROM Tasks WHERE Id = @id";
                // Prepare and execute SQL Command
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", taskId);
                cmd.ExecuteNonQuery();
            });
        }

        // Get Tasks by Group
        public List<TaskItem> GetTasksByGroupId(int groupId)
        {
            List<TaskItem> tasks = new List<TaskItem>();

            ExecuteSafely(() =>
            {
                // Connect to Database
                using var connection = new SQLiteConnection(_connectionString);
                connection.Open();

                // Create SQL query
                string query = "SELECT Id, Title, IsDone FROM Tasks WHERE GroupId = @groupId";
                // Prepare SQL Command
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@groupId", groupId);

                // Get tasks
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tasks.Add(new TaskItem
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Title = reader["Title"].ToString()!,
                        IsDone = Convert.ToInt32(reader["IsDone"]) == 1,
                        GroupId = groupId
                    });
                }
            });

            return tasks;
        }

        // Update Task status
        public void UpdateTaskStatus(int taskId, bool isDone)
        {
            ExecuteSafely(() =>
            {
                // Connect to Database
                using var connection = new SQLiteConnection(_connectionString);
                connection.Open();

                // Create SQL query
                string query = "UPDATE Tasks SET IsDone = @isDone WHERE Id = @id";
                // Prepare and execute SQL Command
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@isDone", isDone ? 1 : 0);
                cmd.Parameters.AddWithValue("@id", taskId);
                cmd.ExecuteNonQuery();
            });
        }

        // Get Single Task
        public TaskItem? GetTaskById(int taskId)
        {
            TaskItem? task = null;

            ExecuteSafely(() =>
            {
                // Connect to Database
                using var connection = new SQLiteConnection(_connectionString);
                connection.Open();

                // Create SQL query
                string query = "SELECT * FROM Tasks WHERE Id = @id";
                // Prepare SQL Command
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", taskId);

                // Get task
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    task = new TaskItem
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Title = reader["Title"].ToString()!,
                        IsDone = Convert.ToInt32(reader["IsDone"]) == 1,
                        GroupId = Convert.ToInt32(reader["GroupId"])
                    };
                }
            });
            
            return task;
        }

        // Delete all tasks from a group
        public void DeleteAllTasksByGroupId(int groupId)
        {
            ExecuteSafely(() =>
            {
                // Connect to Database
                using var connection = new SQLiteConnection(_connectionString);
                connection.Open();

                // Create SQL query
                string query = "DELETE FROM Tasks WHERE GroupId = @groupId";
                // Prepare and execute SQL Command
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@groupId", groupId);
                cmd.ExecuteNonQuery();
            });
        }

        #endregion

        #region GROUP Operations

        //
        // Manage Task Groups
        //

        // Add new Group
        public void AddGroup(string name)
        {
            ExecuteSafely(() =>
            {
                // Connect to Database
                using var connection = new SQLiteConnection(_connectionString);
                connection.Open();

                // Create SQL query
                string query = "INSERT INTO TaskGroups (Name) VALUES (@name)";
                // Prepare and execute SQL Command
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();
            });
        }

        // Get all Groups
        public List<Group> GetAllGroups()
        {
            List<Group> groups = new List<Group>();

            ExecuteSafely(() =>
            {
                // Connect to Database
                using var connection = new SQLiteConnection(_connectionString);
                connection.Open();

                // Create SQL query
                string query = "SELECT Id, Name FROM TaskGroups";
                // Prepare SQL Command
                SQLiteCommand cmd = new SQLiteCommand(query, connection);

                // Get Groups
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    groups.Add(new Group
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString()!
                    });
                }
            });

            return groups;
        }

        // Rename a Group
        public void RenameGroup(int groupId, string newName)
        {
            ExecuteSafely(() =>
            {
                // Connect to Database
                using var connection = new SQLiteConnection(_connectionString);
                connection.Open();

                // Create SQL query
                string query = "UPDATE TaskGroups SET Name = @name WHERE Id = @id";
                // Prepare and execute SQL Command
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", newName);
                cmd.Parameters.AddWithValue("@id", groupId);
                cmd.ExecuteNonQuery();
            });
        }

        // Delete a Group
        public void DeleteGroup(int groupId)
        {
            ExecuteSafely(() =>
            {
                // Connect to Database
                using var connection = new SQLiteConnection(_connectionString);
                connection.Open();

                // Create SQL query
                string query = "DELETE FROM TaskGroups WHERE Id = @id";
                // Prepare and execute SQL Command
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", groupId);
                cmd.ExecuteNonQuery();
            });
        }

        #endregion
    }
}
