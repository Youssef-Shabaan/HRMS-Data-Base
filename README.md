# HRMS Database Design 🗂️

A Human Resource Management System (HRMS) database designed using **Entity Framework Core (Code First)**. This project focuses on clean relational modeling, realistic HR business rules, and scalable design suitable for real-world systems.

---

## Overview ℹ️

The database manages core HR functionalities such as:

* Employee management
* Department structure
* Payroll processing
* Attendance tracking
* Leave management
* Employee training programs

The design follows relational database best practices and EF Core conventions.

---

## Entities & Description 🧩

### Employee

Represents a company employee.

**Properties:**

* `Id` (PK)
* `Name`
* `Position`
* `HireDate`
* `DepartmentId` (FK)

**Relationships:**

* Belongs to one `Department`
* Has one optional `Payroll`
* Has many `Attendances`
* Has many `Leaves`
* Participates in many `Trainings`

---

### Department

Represents organizational departments.

**Properties:**

* `Id` (PK)
* `Name`

**Relationships:**

* Has many `Employees`

---

### Payroll

Represents employee salary details.

**Properties:**

* `Id` (PK)
* `Salary`
* `NetPay` (Computed Column)
* `EmployeeId` (FK)

**Notes:**

* One-to-One relationship with `Employee`
* `NetPay` is calculated automatically in the database

---

### Attendance

Represents daily attendance records.

**Properties:**

* `Id` (PK)
* `Date`
* `TimeIn`
* `TimeOut`
* `EmployeeId` (FK)

**Relationships:**

* Each attendance record belongs to one `Employee`

---

### Leave

Represents employee leave requests.

**Properties:**

* `Id` (PK)
* `StartDate`
* `EndDate`
* `EmployeeId` (FK)

**Relationships:**

* Each leave belongs to one `Employee`

---

### Training

Represents training programs.

**Properties:**

* `Id` (PK)
* `Name`

**Relationships:**

* Many-to-Many with `Employee`
* Implemented via join table `EmployeeTraining`

---

## Database Relationships Summary 🔗

| Relationship           | Type         |
| ---------------------- | ------------ |
| Department → Employees | One-to-Many  |
| Employee → Payroll     | One-to-One   |
| Employee → Attendance  | One-to-Many  |
| Employee → Leave       | One-to-Many  |
| Employee ↔ Training    | Many-to-Many |

---

## Technologies Used 🛠️

* .NET / C#
* Entity Framework Core
* SQL Server
* Code First Migrations

---

## Design Decisions 📐

* Navigation properties are nullable where relationships are optional
* Foreign keys enforce data integrity
* Computed columns used for derived values
* Fluent API used for full control over relationships

---

## Future Enhancements 🚀

* Salary history tracking
* Roles & permissions
* Performance reviews
* Promotions and bonuses
* Soft delete support

---

## Authors 👥

* **Youssef Shabaan** – Backend Developer (.NET)

  * GitHub: Youssef-Shabaan

* **Hussein Hashiem** – Backend Developer (.NET)

  * GitHub: Hussein-Hashiem

---

## Notes 📝

This database is designed for learning, portfolio demonstration, and as a foundation for a full HRMS backend system.

Feel free to fork, improve, and use it in your own projects 🚀
