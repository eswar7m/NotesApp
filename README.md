# Notes Application

## Overview

This is a simple **ASP.NET Core MVC** web application that demonstrates the basics of the MVC pattern using a **Notes** feature. The application includes the default `Home` controller and an additional `Notes` controller to manage notes with create, edit, view, and delete functionality.

The project is intended as a clean starter example for learning or building CRUD-based MVC applications.

---

## Features

* ASP.NET Core MVC architecture
* Default `Home` controller
* `Notes` controller with CRUD operations
* Notes displayed in a tabular format
* Create, Edit, and Delete actions for notes
* Strongly-typed model and views

---

## Project Structure

```
/Controllers
│── HomeController.cs
│── NotesController.cs

/Models
│── Note.cs

/Views
│── /Home
│   └── Index.cshtml
│
│── /Notes
│   ├── Index.cshtml          // Displays all notes in a table
│   ├── Upsert.cshtml         // Create and edit note view
│   ├── Delete.cshtml         // Create Delete note view (readonly)
```

---

## Models

1. The application uses a simple `Note` model

```csharp
public class Note
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
```

---

## Controllers

### 1. HomeController

* Handles default application routes
* Typically used for landing or dashboard page

### 2. NotesController

Responsible for managing notes:

* `Index` – Displays all notes in a table
* `Upsert` – Create a new note or edit an existing one
* `Delete` – Deletes a note

---

## Views

### Notes Index View

* Displays all notes in a table format. Columns include:

  * Title
  * Description
  * Actions (Edit / Delete)

### Upsert View

* View for both creating and editing notes
* Uses model binding and validation

### Delete View

* View for displaying note, non-editable fields

---

## Technologies Used

* ASP.NET Core MVC
* C#
* Razor Views
* Bootstrap

---