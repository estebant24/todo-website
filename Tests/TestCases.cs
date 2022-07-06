using NUnit.Framework;
using TodoListWebsite.Page;
using TodoListWebsite.Utilities;


namespace TodoListWebsite.Tests
{
    public class TestCases : Base
    {
        //* Positive Test Cases *//
       
        [Test]
        public void User_IsAble_ToAddATodo_And_IsVisibleOnTheList()
        {
            var todoPage = new TodoPage(driver);
            todoPage.addTodo("Walk the dog");
            //Assert Todo was added by checking the Todo list is displayed
            Assert.IsTrue(todoPage.getFirstTodo().Displayed);
        }

        [Test]
        public void User_IsAble_ToCompleteATodo()
        {
            var todoPage = new TodoPage(driver);
            todoPage.addTodo("Wash the car");
            todoPage.getToggle();
            todoPage.getToggle().Click();
            todoPage.getClearCompleted();
            // Assert Todo was deleted by validating "Clear Completed" is displayed
            Assert.IsTrue(todoPage.getClearCompleted().Displayed);
            todoPage.clearTodo();
            // Assert the todo list isn't displayed anymore
            Assert.IsTrue(todoPage.isTodoListPresent(driver).Equals(false));
        }

        [Test]
        public void User_IsAble_ToAdd3Todos_And_DeleteOne()
        {
            var todoPage = new TodoPage(driver);
            todoPage.addTodo("Walk the dog");
            todoPage.addTodo("Wash the car");
            todoPage.addTodo("Buy groceries");
            todoPage.getItemsLeftQuantity();
            // Assert the number quantity of Todo added is 3 by validating the "Items Left" text
            Assert.IsTrue(todoPage.getItemsLeftQuantity().Text.Contains("3"));
            todoPage.deleteFirstTodo();
            // Assert that now there are 2 Todo left by validating the "Items Left" text
            Assert.IsTrue(todoPage.getItemsLeftQuantity().Text.Contains("2"));
        }

        [Test]
        public void User_IsAble_ToAdd_And_EditATodo()
        {
            var todoPage = new TodoPage(driver);
            todoPage.addTodo("Do Homework");
            todoPage.enableEditionOnTodo();
            todoPage.editTodo("Do Zivver QA task!");
            // Assert the new Todo in the list is "Do Zivver QA task!"
            Assert.IsTrue(todoPage.getFirstTodo().Text.Equals("Do Zivver QA task!"));
        }

        //* Negative Test Cases *//
        
        [Test]
        public void User_IsNotAble_ToAddEmptyTodo()
        {
            var todoPage = new TodoPage(driver);
            todoPage.addTodo("   ");
            // Assert Todo list element isn't found on screen after entering only space as text and pressing "Enter" key
            Assert.IsTrue(todoPage.isTodoListPresent(driver).Equals(false));
        }

        [Test]
        public void User_IsNotAble_ToDeleteTodoWhileEditing()
        {
            var todoPage = new TodoPage(driver);
            todoPage.addTodo("Go to the bank");
            todoPage.enableEditionOnTodo();
            // Assert User cant delete while editing by validating if delete button isnt displayed on screen
            Assert.IsTrue(todoPage.isTodoDeleteBtnPresent(driver).Equals(false));
        }

        [Test]
        public void User_IsNotAble_ToClearUncompletedTodo()
        {
            var todoPage = new TodoPage(driver);
            todoPage.addTodo("Walk the dog");
            todoPage.addTodo("Wash the car");
            todoPage.addTodo("Buy groceries");
            // Assert the User cant clear uncompleted todos "Clear Completed" by validating button isnt displayed on screen
            Assert.IsTrue(todoPage.isClearCompletedBtnPresent(driver).Equals(false));
        }

        [Test]
        public void EnteredTextInHeader_IsNotSaved_AfterRefreshingWebsite()
        {
            var todoPage = new TodoPage(driver);
            todoPage.EnterTextInHeader("Call the plumber");
            driver.Navigate().Refresh();
            // Assert entered text on header bar isn't saved after refreshing the website
            Assert.IsTrue(todoPage.headerHasText(driver).Equals(true));
        }

    }
}