# 📘 ToDoApp MVP – Development Documentation

This document provides a clear, structured overview of the development process, architecture, decisions, and potential improvements for the `ToDoApp` built in C# using WinForms and a `CheckedListBox` for task management.

---

## 📌 Project Summary

**Project Name:** ToDoApp

**Type:** Windows Desktop Application

**Tech Stack:**
- C# (.NET 6)
- WinForms
- SQLite
- Visual Studio
- Git + GitHub

**Goal:**

To create a simple, minimal, and functional To-Do List application using a `CheckedListBox` for a clean user experience. The app allows users to add, complete, and delete tasks with persistence using a local database.

---

## 🧱 Development Timeline & Phases

✅ **Phase 1: Setup**

- Created a new WinForms project (ToDoApp) using .NET 6
- Initialized Git in the solution root folder
- Set up .gitignore to exclude build files (bin/, obj/, etc.)

✅ **Phase 2: MVP Features (Core Logic)**

- Integrated CheckedListBox for listing tasks with checkable status
- Connected SQLite using System.Data.SQLite NuGet package
- Created a simple local database (tasks.db) with one table:

    ```sql
    CREATE TABLE Tasks (
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        Title TEXT NOT NULL,
        IsDone INTEGER DEFAULT 0
    );

- Implemented the following core functionalities:
  - ➕ Add new task
  - ✅ Mark/unmark task as done (syncs to DB)
  - 🗑 Delete selected task(s)
  - ♻️ Refresh UI from DB on each load or change

✅ **Phase 3: GitHub Upload**

- Created GitHub repo and linked it to local project
- Pushed all source files along with .gitignore and README.md
- (Planned to include screenshot & future improvements)

---

## ⚙️ Architecture Overview

**Frontend (UI):** WinForms, one main form with:

- `CheckedListBox` (clbTasks)
- `TextBox` for new task input
- `Buttons`: Add, Delete

**Backend/Logic:**

- Class-level SQLite connection
- CRUD functions:
  - `LoadTasks()` - load tasks
  - `btnAdd_Click()` - add task
  - `btnDelete_Click()` - delete task
  - `clbTasks_ItemCheck()` - update task status

**Persistence:**

- Tasks stored in local SQLite DB
- Boolean-like `IsDone` stored as `INTEGER` (0 or 1)

---

## 💡 Key Decisions

| Decision                             | Reason                               |
|--------------------------------------|--------------------------------------|
| ✅ Use CheckedListBox                | Built-in support for checkable items        |
| ✅ Use SQLite                        | Lightweight, no setup needed, portable      |
| ❌ No external libraries             | Kept MVP lightweight and beginner-friendly  |
| ❌ No async/await or threading       | Avoided complexity at MVP level             |

---

## 🧪 Testing & Validation

- Manual testing of:
  - Adding tasks
  - Toggling checkboxes (done/not done)
  - Deleting tasks
  - Persistence after restart

- Database file observed using `DB Browser for SQLite` to validate storage

---

## 📷 Screenshot Placeholder

(To be added later to showcase final UI of the app)

---

## 🚀 Possible Improvements

| Feature                              | Benefit                              |
|--------------------------------------|--------------------------------------|
| Edit existing task                   | Better UX                            |
| Reorder tasks                        | Prioritization                       |
| Dark/light mode                      | User preference                      |
| Cloud sync (Firebase?)               | Portability                          |
| Due dates / reminders                | More power for productivity          |
| Categorize tasks by topics           | Browse between different areas       |

---

## 📄 License

MIT License

---

## 🙋 Author

*`Spaced Out`*

Beginner-friendly C# Developer building a portfolio with clean, real-world projects.

GitHub: https://github.com/LostSpaceNG