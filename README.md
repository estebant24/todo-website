# Todo Website Automated Test Cases 

Automated test cases for the Todo website QA test challenge.
The objective of these automation project is to cover all the main scenarios to ensure the quality of the Todo Website.

## Features

*Positive test scenarios:*
* User is able to add a to-do and view it in the list 
* User is able to edit a to-do from the list
* User is able to mark the to-do as completed and clear it from the list
* User is able to delete a to-do from the list

*Negative test scenarios:*
* User is not able to add a to-do when entering only space as text
* User is not able to delete a to-do while editing it
* User is not able to clear to-dos that are not marked as completed
* User is not able to see the entered text on the header bar when refreshing the website

## Tech

The automated test cases are done with the following technologies:

- Selenium Webdriver framework - https://www.selenium.dev/downloads/
- C# Language - https://docs.microsoft.com/en-us/dotnet/csharp/
- NUnit test framework - https://nunit.org/
- Visual Studio IDE - https://visualstudio.microsoft.com/
- Page Object Model Design Pattern
- Stored in Github - https://github.com/estebant24/todo-website

## Project Content

This project contains 3 Folders: 

- **Page folder**, containing the _TodoPage_ class with all the elements & methods from the main page
- **Tests folder**, containing the _TestCases_ class with all the test cases
- **Utilities folder**, containing the _Base_ class with all the Set ups used for running the tests

Additional Files:

- **Index.html** file with the latest test cases run report
- **README** file 

## Installation

For this project to work, the following Nuget packages need to be installed:

| Packages | 
| ------ | 
| DotNetSeleniumExtras.PageObjects | 
| DotNetSeleniumExtras.PageObjects.Core | 
| DotNetSeleniumExtras.WaitHelpers | 
| ExtentReports | 
| NUnit | 
| NUnit3TestAdapter | 
| NUnit.Analyzers |
| Selenium.Support |
| Selenium.WebDriver |
| Selenium.WebDriver.ChromeDriver |
| System.Configuration.ConfigurationManager |
| WebDriverManager |

To install this packages go to the project "TodoListWebsite" in the project explorer, right click on it and select "Manage NuGet Packages"