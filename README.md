# 🏦 BankSystem
BankSystem is a program where you log in to a bank. Depending on your role (administrator or user) you will start with a menu of options once logged in successfully. When logged in as a user, your menu consists of viewing your bankaccounts, applying for a loan, transferring money between your own accounts or to other users and viewing all of your transactions. When logged in as an administrator, your menu will contain adding a new user, deleting an existing user, view a list of all existing users and updating the daily exhange rate.

## 👥 Classes
### LoginManager
LoginManager class handles the log in function and limits the number of login attempts to three.
### Person
Person class determines if the user is an admin or a regular user depending on name and password.

#####   -Administrator,
##### Administrator class inherits from Person class. Administrator class can add new users, delete users and update exchange rate.
#####   -User, 
##### User class inherits from Person class. User class can add new bankaccounts, transfer money between accounts, transfer money to other users and take out a bank loan. 

## ℹ️ Background
The program is developed according to a backlog with a requirements specification. It is a grading group project where we have figured out and learned how to work as a team with contributions on GitHub.

## 📹 Application Demo

### Admin demo
https://github.com/callefransson/BankSystem/assets/144247326/396c42a8-478a-4d3b-acfa-24a08d736f90

### User demo
https://github.com/callefransson/BankSystem/assets/144247326/a24f4742-480e-4d45-81cd-af9f50e5d864

## 🎮 Authors and acknowledgement
### 🐱 Team CodeCats
#### 🧩 PeterMolen 
#### 🧩 GabriellaNilsson
#### 🧩 thisisaverycoolusername
#### 🧩 callefransson
#### 🧩 m-lovqvist

