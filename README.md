

````markdown
# 📚 BookShelf API  
A simple **.NET Web API** for managing a list of books.  
This project demonstrates clean architecture using **Repository Pattern**, **Unit of Work**, **Services Layer**, **DTOs**, and **EntityConfigurations**.

---

## 📌 Features
- Get all books  
- Get a book by ID  
- Create a new book  
- Update an existing book  
- Delete a book  
- AutoMapper integration  
- EF Core + Repository + Unit of Work architecture  


# 📘 Book API Endpoints

### 🔹 GET `/api/books`
Returns all books.

**Response Example**
```json
[
  {
    "id": 1,
    "title": "English",
    "author": "J.R.R. Tolkien",
    "year": 1937
  }
]
````

---

### 🔹 GET `/api/books/{id}`

Returns a specific book by ID.

---

### 🔹 POST `/api/books`

Creates a new book.

**Request Body**

```json
{
  "title": "Clean Code",
  "author": "Robert C. Martin",
  "year": 2008
}
```

---

### 🔹 PUT `/api/books/{id}`

Updates an existing book.

**Request Body**

```json
{
  "title": "Updated Title",
  "author": "Updated Author",
  "year": 2020
}
```

---

### 🔹 DELETE `/api/books/{id}`

Deletes a book by ID.

---

## 🛠️ Technologies Used

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* AutoMapper
* Repository Pattern
* Unit Of Work Pattern
* Dependency Injection

---

## 🚀 Getting Started

### 1. Clone the repo

```bash
git clone https://github.com/yourusername/BookShelf.API.git
```

### 2. Update database

```bash
dotnet ef database update
```

### 3. Run the project

```bash
dotnet run
```

### 4. Open Swagger UI

```
https://localhost:{port}/swagger
```

---

## ✨ License

This project is open-source. Use it freely.

```
