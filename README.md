# 🎬 MoviesAPI

A RESTful Web API built with ASP.NET Core for managing movies and genres. This project follows best practices in software architecture, such as Clean Architecture and the use of DTOs. It provides full CRUD operations and supports querying by genre, all documented via Swagger UI.

🔗 **Swagger UI:**  
![image](https://github.com/user-attachments/assets/df6a6c0e-5ace-4c01-8d70-b0c16b58275b)

---

## 🛠️ Tech Stack

- **Backend:** ASP.NET Core Web API  
- **Database:** SQL Server (via Entity Framework Core)  
- **Architecture:** Clean Architecture Principles  
- **Documentation:** Swagger / OpenAPI  
- **Tools:** Visual Studio, Postman, LINQ, Git

---

## 📌 Features

### 🔹 Genres

- `GET /api/Genres` – Retrieve all genres  
- `POST /api/Genres` – Add a new genre  
- `PUT /api/Genres/{id}` – Update an existing genre  
- `DELETE /api/Genres/{id}` – Delete a genre by ID  

### 🔹 Movies

- `GET /api/Movies` – Retrieve all movies  
- `POST /api/Movies` – Add a new movie  
- `GET /api/Movies/{id}` – Get movie by ID  
- `PUT /api/Movies/{id}` – Update a movie  
- `GET /api/Movies/{genreid}` – Filter movies by genre  
- `DELETE /api/Movies/{id}` – Delete a movie by ID  

---

## 📦 DTOs & Models

- `CreateGenreDto` – Used for creating new genres  
- `CreateMovieDto` – Used for adding new movies  
- AutoMapper is used for mapping between DTOs and domain models  

---

## ✅ How to Run Locally

1. Clone the repository:
   ```bash
   git clone https://github.com/abdelrahmangamall/MoviesAPI.git
   cd MoviesAPI
