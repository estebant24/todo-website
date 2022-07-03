using NUnit.Framework;
using TodoListWebsite.Page;
using TodoListWebsite.Utilities;


namespace TodoListWebsite.Tests
{
    public class TestCases : Base
    {
        //* Positive Test Cases *//
       
        [Test]
        public void User_IsAbleToAddATask_And_IsVisibleOnTheList()
        {
            var todoPage = new TodoPage(driver);
            todoPage.addTodo("Walk the dog");
            Assert.IsTrue(todoPage.getFirstTodo().Displayed); //Assert Todo was added by checking the Todo list is displayed
        }

        [Test]
        public void User_IsAbleToCompleteATodo()
        {
            var todoPage = new TodoPage(driver);
            todoPage.addTodo("Wash the car");
            todoPage.getToggle();
            todoPage.getToggle().Click();
            todoPage.getClearCompleted();
            Assert.IsTrue(todoPage.getClearCompleted().Displayed); // Assert Todo was deleted by validating "Clear Completed" is displayed
        }

        [Test]
        public void User_IsAble_ToAdd3Tasks_And_DeleteOne()
        {
            var todoPage = new TodoPage(driver);
            todoPage.addTodo("Walk the dog");
            todoPage.addTodo("Wash the car");
            todoPage.addTodo("Buy groceries");
            todoPage.getItemsLeftQuantity();
            Assert.IsTrue(todoPage.getItemsLeftQuantity().Text.Contains("3"));// Assert the number quantity of Todo added is 3 by validating the "Items Left" text
            todoPage.deleteFirstTodo();
            Assert.IsTrue(todoPage.getItemsLeftQuantity().Text.Contains("2")); // Assert that now there are 2 Todo left by validating the "Items Left" text
        }

        [Test]
        public void User_IsAble_ToAdd_And_EditATask()
        {
            var todoPage = new TodoPage(driver);
            todoPage.addTodo("Do Homework");
            todoPage.enableEditionOnTodo();
            todoPage.editTodo("Do Zivver QA task!");
            Assert.IsTrue(todoPage.getFirstTodo().Text.Equals("Do Zivver QA task!")); // Assert the new Todo in the list is "Do Zivver QA task!"
        }

        //* Negative Test Cases *//
        
        [Test]
        public void User_IsNotAble_ToAddEmptyTask()
        {
            var todoPage = new TodoPage(driver);
            todoPage.addTodo("");
            Assert.IsTrue(todoPage.isTodoListPresent(driver).Equals(false)); // Assert the Todo list element isnt found on screen
        }

        [Test]
        public void User_IsNotAble_ToDeleteTodoWhileEditing()
        {
            var todoPage = new TodoPage(driver);
            todoPage.addTodo("Go to the bank");
            todoPage.enableEditionOnTodo();
            Assert.IsTrue(todoPage.isTodoDeleteBtnPresent(driver).Equals(false)); // Assert User cant delete while editing by validating if delete button isnt displayed on screen
        }

        [Test]
        public void User_IsNotAble_ToClearUncompletedTodo()
        {
            var todoPage = new TodoPage(driver);
            todoPage.addTodo("Walk the dog");
            todoPage.addTodo("Wash the car");
            todoPage.addTodo("Buy groceries");
            Assert.IsTrue(todoPage.isClearCompletedBtnPresent(driver).Equals(false)); // Assert the User cant clear uncompleted todos "Clear Completed" by validating button isnt displayed on screen
        }

        [Test]
        public void EnteredTextInHeader_IsNotSaved_AfterRefreshingWebsite()
        {
            var todoPage = new TodoPage(driver);
            todoPage.EnterTextInHeader("Call the plumber");
            driver.Navigate().Refresh();
            Assert.IsTrue(todoPage.headerHasText(driver).Equals(true)); // Assert entered text on header bar isn't saved after refreshing the website
        }

    }
}