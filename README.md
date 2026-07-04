# Ebel.ValidatorKit

Validation library (CPF/Name) developed in .NET, accompanied by a demonstration API for consumption.  
The project focuses on best practices for versioning, CI/CD, and NuGet package publishing.

---

## 🎯 Purpose

This project was developed for educational purposes to practice and consolidate fundamental concepts of the software lifecycle, including:

- Creation and maintenance of reusable libraries in .NET
- Versioning following Semantic Versioning
- Publishing packages to NuGet
- CI/CD pipeline automation using GitHub Actions
- Consuming a library through an API (Minimal API)

---

## 🛠 Technologies Used

- C#
- .NET
- Minimal API
- NuGet
- GitHub Actions
- xUnit (tests)

---

## 📁 Project Structure

- `/src`
  - `ValidatorKit` → Main validation library
  - `ValidatorKit.Api` → Demonstration API
- `/tests`
  - `ValidatorKit.Tests`
 
---

## 📦 Installation

The library can be installed via NuGet:

```bash
dotnet add package Ebel.ValidatorKit
```
---

## 🚀 Lybrary Usage

Example of CPF validation:

```csharp
var result = cpf.ValidateCpf();

if (!result.IsValid)
{
    Console.WriteLine(result.Code);
}
```

The validation result returns a `ValidationResult`, which encapsulates:

- Validation state (`IsValid`)

- Error code (`Code`)

- Descriptive message

--- 

## 🌐 Demonstration API

The API was created using ***Minimal API*** with the sole purpose of demonstrating the consumption of the `Ebel.ValidatorKit` library.

> ⚠️ **Warning**  
> This API is not intended for production use and is provided only as a testing and learning environment.

It exposes simple endpoints that receive input data and return the validation results from the library.

---

## 🔄 Versioning and CI/CD

- The project follows Semantic Versioning (SemVer)

- Automated pipeline using GitHub Actions

- Build, tests, and NuGet package publishing are handled automatically via workflow

---

## 📌 Project Status

✔️ Project completed for study and learning purposes.

---

## 📄 License

This project is free to use for educational purposes.

---

## 👤 Autor
Bernardo Ebel <br>
[GitHub](https://github.com/EbelBernardo) | [LinkedIn](https://www.linkedin.com/in/bernardo-ebel-743831303/)

## 📌 Final Notes

This project represents a practical study of creating, versioning, and distributing libraries in .NET.
