# Changelog

All notable changes to the project will be documented in this file.

---

## 📌 Version 1.2.0 – Modern UI & Smart Layout (Released on: 20-05-2025)

### ✨ New Features

- **New UI Style and Structure**:
    - **Group View** rendering groups as modern *icon + label* cards.
    - **Task View** with `CheckedListBox` for listing tasks in a selected group.
    - Navigation between Views and particular Groups.
    - Enabled Window resize and maximize.

- **Custom GroupCard Component**:
    - Created `GroupCard` as a `UserControl` with image and text.
    - Unified styling, click behavior, and keyboard accessibility.
    - Uses `Tag` property to bind to group model.
    - Supports hover effects and Enter key activation.

- **Custom Layout System**:
    - Introduced `GroupCardsPanel.cs`, a custom layout manager using a regular `Panel`.
    - Dynamically calculates positioning of group cards for full responsive design.
    - Replaced problematic `FlowLayoutPanel` with clean, manual layout logic.

- **New Prompt System**:
    - Created reusable `PromptForm` for creating/renaming groups and tasks with simple input validation.
    - Dynamically configured title and message text.

- **Group Management Features**:
    - **Rename** and **Delete** via right-click context menu on group cards.
    - New "Add Group" card always rendered as the first item.

- **Task Management Features**:
    - Task editing (rename) via dedicated button.
    - Clean task creation and deletion logic.

- **Resources & Icons**:
    - Introduced icons for Group View.
    - Added `Resources.resx` support.

### 🔧 Technical Improvements

- Moved `Group` and `TaskItem` classes into `/Models/` folder.
- Extracted **all DB logic** into `/Services/DatabaseService.cs`:
    - Contains CRUD, table initialization, and SQLite connection logic.
    - Added `ExecuteSafely()` wrapper for safe DB error handling (e.g. `UNIQUE` constraint violations).

### 🐛 Fixed

- Fixed several UI layout bugs when restoring from minimized or maximized state and on first form load.
- Resource file (.resx) not updating — resolved by updating VS2022 and build tools.

### 📁 Documentation

- Created this `CHANGELOG.md` file for structured version updates.
- Cleaned up `DEVDOC.md`, moving v1.1.0 details here.

### 🧪 Testing & Usage

- See [How to Run in README](./README.md)

---

## 📌 Version 1.1.0 – Task Groups & Filtering (Released on: 24-04-2025)

### ✨ New Features

- Introduced **Task Groups** for organizing to-dos by category
- Created `TaskGroups` table in database
- Tasks now belong to a selected group via `GroupId`
- Added group selection dropdown
- Added filtering logic to load only tasks for selected group

### 🔧 Technical Improvements

- Refactored `LoadTasks()` method to accept group filter
- Connected group dropdown with filtering logic
- Introduced constant `AppVersion` displayed in app title

### 🧪 Testing & Usage

- See [How to Run in README](./README.md)