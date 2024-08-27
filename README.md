# RentACar Web Application


## Overview

RentACar is a comprehensive web application built with .NET Core 8 that allows users to book and manage car rentals online. The application offers features such as car browsing, booking, user authentication, and management of rental history.

## Table of Contents

- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [API Documentation](#api-documentation)
- [Technologies Used](#technologies-used)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Features

- **User Authentication**: Secure login and registration system.
- **Car Browsing**: View available cars with filters by model, type, and availability.
- **Booking System**: Book cars for specific dates and manage bookings.
- **Admin Panel**: Manage cars, users, and bookings.
- **Responsive Design**: Fully responsive design, optimized for both desktop and mobile devices.

## Installation

To set up the project locally, follow these steps:

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/rentacar.git

2. Navigate to the project directory:
   ```bash
   cd rentacar
3. Install the required dependencies:
   ```bash
   dotnet restore
4. Update the appsettings.json file with your database connection string.
5. Apply migrations and seed the database:
   ```bash
   dotnet ef database update
6. Run the application:
   ```bash
   dotnet run

## Usage
Once the application is running, you can access it via your browser at http://localhost:5000.

To access the admin panel, go to http://localhost:5000/admin.

## API Documentation
The API documentation is available via Swagger. Once the application is running, navigate to:
```bash
http://localhost:5000/swagger/index.html
```
This will provide detailed information about the available API endpoints, request parameters, and responses.

## Technologies Used

- **Backend**: .NET Core 8, Entity Framework Core
- **Database**: SQL Server
- **Frontend**: Razor Pages (or Angular, React, etc. if used)
- **Authentication**: ASP.NET Core Identity
- **API Documentation**: Swagger
- **Version Control**: Git

## Contributing
Contributions are welcome! To contribute to this project, follow these steps:

1. Fork the repository.
2. Create a new branch:
   ```bash
   git checkout -b feature-branch
   ```
3. Make your changes.
4. Commit your changes:
   ```bash
   git commit -m 'Add new feature'
   ```
5.Push to the branch:
   ```bash
   git push origin feature-branch
   ```
6. Open a Pull Request.
   
