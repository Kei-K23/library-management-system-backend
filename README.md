# Library Management System Design

## 1. Entities

### User

- **Id** (GUID)
- **Name** (string)
- **Email** (string)
- **Password** (string, hashed)
- **Role** (enum: Admin, Librarian, Member)
- **DateJoined** (DateTime)

### Book

- **Id** (GUID)
- **Title** (string)
- **Author** (string)
- **ISBN** (string)
- **Publisher** (string)
- **PublishedDate** (DateTime)
- **Category** (string)
- **Description** (string)
- **CopiesAvailable** (int)
- **TotalCopies** (int)

### Category

- **Id** (GUID)
- **Name** (string)
- **Description** (string)

### Loan

- **Id** (GUID)
- **BookId** (GUID)
- **UserId** (GUID)
- **LoanDate** (DateTime)
- **DueDate** (DateTime)
- **ReturnDate** (DateTime, nullable)
- **Status** (enum: Loaned, Returned, Overdue)

### Reservation

- **Id** (GUID)
- **BookId** (GUID)
- **UserId** (GUID)
- **ReservationDate** (DateTime)
- **Status** (enum: Reserved, Cancelled, Completed)

### Fine

- **Id** (GUID)
- **UserId** (GUID)
- **Amount** (decimal)
- **Reason** (string)
- **Status** (enum: Unpaid, Paid)
- **DateIssued** (DateTime)

### Review

- **Id** (GUID)
- **BookId** (GUID)
- **UserId** (GUID)
- **Rating** (int)
- **Comment** (string)
- **DateReviewed** (DateTime)

## 2. API Endpoints

### User Management

- **POST /api/users/register**

  - Registers a new user.
  - **Input:** `Name`, `Email`, `Password`, `Role`.

- **POST /api/users/login**

  - Authenticates a user.
  - **Input:** `Email`, `Password`.

- **GET /api/users/{id}**

  - Retrieves user details by `Id`.

- **PUT /api/users/{id}**

  - Updates user details.
  - **Input:** `Name`, `Email`, `Password`.

- **DELETE /api/users/{id}**
  - Deletes a user account.

### Book Management

- **POST /api/books**

  - Adds a new book to the library.
  - **Input:** `Title`, `Author`, `ISBN`, `Publisher`, `PublishedDate`, `Category`, `Description`, `TotalCopies`.

- **GET /api/books**

  - Retrieves a list of all books.

- **GET /api/books/{id}**

  - Retrieves details of a specific book.

- **PUT /api/books/{id}**

  - Updates book details.
  - **Input:** `Title`, `Author`, `ISBN`, `Publisher`, `PublishedDate`, `Category`, `Description`, `TotalCopies`, `CopiesAvailable`.

- **DELETE /api/books/{id}**
  - Deletes a book from the library.

### Category Management

- **POST /api/categories**

  - Adds a new category.
  - **Input:** `Name`, `Description`.

- **GET /api/categories**

  - Retrieves a list of all categories.

- **GET /api/categories/{id}**

  - Retrieves details of a specific category.

- **PUT /api/categories/{id}**

  - Updates category details.
  - **Input:** `Name`, `Description`.

- **DELETE /api/categories/{id}**
  - Deletes a category.

### Loan Management

- **POST /api/loans**

  - Issues a loan for a book.
  - **Input:** `BookId`, `UserId`.

- **GET /api/loans**

  - Retrieves all loans.

- **GET /api/loans/{id}**

  - Retrieves details of a specific loan.

- **PUT /api/loans/{id}**

  - Updates loan status.
  - **Input:** `ReturnDate`, `Status`.

- **DELETE /api/loans/{id}**
  - Cancels a loan.

### Reservation Management

- **POST /api/reservations**

  - Reserves a book.
  - **Input:** `BookId`, `UserId`.

- **GET /api/reservations**

  - Retrieves all reservations.

- **GET /api/reservations/{id}**

  - Retrieves details of a specific reservation.

- **PUT /api/reservations/{id}**

  - Updates reservation status.
  - **Input:** `Status`.

- **DELETE /api/reservations/{id}**
  - Cancels a reservation.

### Fine Management

- **POST /api/fines**

  - Issues a fine to a user.
  - **Input:** `UserId`, `Amount`, `Reason`.

- **GET /api/fines**

  - Retrieves all fines.

- **GET /api/fines/{id}**

  - Retrieves details of a specific fine.

- **PUT /api/fines/{id}**

  - Updates fine status.
  - **Input:** `Status`.

- **DELETE /api/fines/{id}**
  - Cancels a fine.

### Review Management

- **POST /api/reviews**

  - Adds a review for a book.
  - **Input:** `BookId`, `UserId`, `Rating`, `Comment`.

- **GET /api/reviews**

  - Retrieves all reviews.

- **GET /api/reviews/{id}**

  - Retrieves details of a specific review.

- **PUT /api/reviews/{id}**

  - Updates a review.
  - **Input:** `Rating`, `Comment`.

- **DELETE /api/reviews/{id}**
  - Deletes a review.

## 3. Additional Features

### Search API

- **GET /api/search**
  - Search books by title, author, category, ISBN, etc.
  - **Input:** `query`.

### Dashboard

- **GET /api/dashboard**
  - Retrieves statistics such as total books, loans, overdue books, etc.

### Notifications

- **POST /api/notifications**
  - Send notifications to users (e.g., overdue reminders).

### Reporting

- **GET /api/reports**
  - Generates reports on loans, fines, user activity, etc.
