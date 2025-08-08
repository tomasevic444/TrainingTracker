# Training Tracker

A full-stack web application designed to help users log their workouts and track their fitness progress over time. 

## Demo



https://github.com/user-attachments/assets/52c04189-85c6-42ce-9eac-9715aad862f1



---

## Features

-   **Secure User Authentication**: Complete registration and login flow using JWT (JSON Web Tokens) for secure API communication.
-   **Workout Logging**: An intuitive dialog allows users to log workouts, specifying type, date, duration, calories, intensity, and fatigue.
-   **Dynamic Dashboard**: A central dashboard that displays a list of all logged workouts, with updates when a new workout is added.
-   **Progress Visualization**: A dedicated progress page with a month selector to view aggregated weekly statistics, including total duration, workout count, and average intensity/fatigue.
-   **Automatic Data Seeding**: For ease of testing, the database is automatically seeded with a sample user and a rich history of workout data on the first run.

---

## Tech Stack & Architecture

### **Backend**

-   **Framework**: ASP.NET Core Web API (.NET 8)
-   **Architecture**: Clean Architecture, separating concerns into Core, Application, Infrastructure, and API layers.
-   **Database**: PostgreSQL (managed via Docker Compose).
-   **Data Access**: Entity Framework Core 8 with the Repository Pattern.
-   **Core Patterns**: CQRS with MediatR for clean, decoupled application logic.
-   **Validation**: FluentValidation with pipeline behaviors
-   **Security**: JWT Bearer token authentication.

### **Frontend**

-   **Framework**: Angular.
-   **UI Library**: Angular Material for a high-quality, consistent user interface.
-   **Styling**: SCSS with a modular, component-based approach.
---

## Getting Started

Follow these instructions to get the project up and running on your local machine.

### **Prerequisites**

-   [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
-   [Node.js](https://nodejs.org/) (and [Angular CLI](https://angular.io/cli)
-   [Docker Desktop](https://www.docker.com/products/docker-desktop/)
-   [Visual Studio 2022](https://visualstudio.microsoft.com/) and [VS Code](https://code.visualstudio.com/).

### **Installation & Setup**

#### **1. Clone the Repository**

Open your terminal and clone the project to a location of your choice:
```bash
git clone <your-github-repository-url>
```
This will create a `TrainingTracker` folder. All subsequent steps are performed from within this folder.

#### **2. Start the Database**

Ensure Docker Desktop is running. In a terminal at the root of the `TrainingTracker` folder, run:
```bash
docker-compose up -d
```


#### **3. Run the Backend API (.NET)**

-   **1. Create Local Configuration File**
    -   To follow security best practices, development-specific settings are not stored in the main repository. A ready-to-use template is provided for a quick and easy setup.
    -   In your file explorer, navigate to the `server/TrainingTracker/TrainingTracker.API/` directory.
    -   Find the file named **`appsettings.Development.json.example`**.
    -   Make a copy of it in the same folder and rename the copy to **`appsettings.Development.json`**.
    -   _The template contains all the correct settings, so no editing is needed._

-   **2. Launch the Application in Visual Studio**
    -   Navigate to the `server/TrainingTracker` and double-click the **`TrainingTracker.sln`** file to open the solution.
    -   In the Solution Explorer, right-click on the **`TrainingTracker.API`** project and select **"Set as Startup Project"**.
    -   Press **F5** or click the "Start" button to launch the API.

_On the first launch, the application will automatically connect to the Docker database, apply migrations, and seed the sample data._

#### **4. Run the Frontend Client (Angular)**

-   Open a **new terminal**.
-   Navigate into the `client` directory from the project root:
    ```bash
    cd client
    ```
-   Install the required npm packages:
    ```bash
    npm install
    ```
-   Start the Angular development server:
    ```bash
    ng serve
    ```
-   Open your web browser and navigate to: **[http://localhost:4200](http://localhost:4200)**

---
## Sample User Credentials

For immediate testing, the database seeder creates the following user:

-   **Username:** `testuser`
-   **Password:** `Password123!`
