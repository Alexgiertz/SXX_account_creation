# SXX Company Account Registration

A C# console application developed for a school assignment to turn Azure DevOps user stories and acceptance criteria into working functionality for a booking system.

## Features

- Register a company customer and a linked login account.
- Validate required fields and email address formats.
- Reject duplicate organisation numbers and login email addresses.
- Log in using an email address and password.
- Display registration confirmations, validation errors, and the company name after successful login.

## Project Structure

- **Models:** Company information and login account data, linked by company customer ID.
- **Interfaces:** Contracts for the service and repositories.
- **Repository:** In-memory storage and lookup operations.
- **Service:** Registration, validation, and login logic.
- **UI:** Console menus, input, and messages.
- **Program.cs:** Creates the dependencies and starts the menu.

## Running the Application

Requires the .NET 10 SDK. From the folder containing this README, run:

```sh
dotnet run --project ConsoleApp1/SXX_account_creation.csproj
```

Alternatively, open `SXX_account_creation.slnx` in a compatible version of Visual Studio and run the console project.

## Diagrams

Editable PlantUML sources are included:

- [Class diagram](company-account-class-diagram-updated.puml)
- [Activity diagram](company-account-activity-diagram.puml)
- [Registration and login sequence diagrams](company-account-sequence-diagrams.puml)

## Limitations

Data is stored only in memory and is lost when the application closes. Passwords are entered visibly and stored as plain text for this basic assignment. Login displays a welcome message without maintaining a signed-in session. Booking management, staff accounts, and permission management are outside the implemented scope.
