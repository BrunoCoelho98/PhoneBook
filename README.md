# Phone Book Application

## Introduction

This project demonstrates a basic Phone Book application built using C# and Entity Framework. It allows users to manage contacts with their phone numbers,email addresses and social groups through a console interface. The application follows the Code-First approach, using SQLite for the database, and includes features for adding, updating, deleting, and viewing contacts. Additionally, it provides functionality for sending messages (it doesn't actually send a message, just save messages send in the database).

## Features

- **Add, Update, Delete, and View Contacts:** Manage contacts with their phone numbers and email addresses.
- **Email Validation:** Ensures email addresses follow proper formats.
- **Phone Number Validation:** Ensures phone numbers follow proper formats.
- **Social Groups:** Allows user to categorize contacts into social groups.
- **Message Sending:** Allows user to save messages in his contact's information.

## Requirements

- .NET 6.0 or later
- SQLite

## Usage

### Setting up the Database and Application


1. **Configure the Connection String**: Update the connection string to match your SQLite configuration. 
2. **Configure the Database:** The application uses Entity Framework Code-First approach. Run the following command to set up the database:
```c#
Update-Database
```
3. **Run the Application:** Start the application


### Running the Application

1. Start the application and follow the console prompts to add, update, delete, and view contacts and SocialGroups.
2. Use the `SendMessage` option in the contacts menu to send messages to contacts.


## Project Structure

- **Controllers:** Handle user input and manage the flow of the application.
- **Services:** Implement business logic.
- **ContactContext:** Interact with the database using Entity Framework.
- **Models:** Define the data structures for contacts, emails, and phone numbers.
- **Utilities:** Provide validation and user input handling.
