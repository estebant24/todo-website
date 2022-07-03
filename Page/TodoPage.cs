using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TodoListWebsite.Page
{
    public class TodoPage
    {
        private IWebDriver driver;

        //* Elements *//
        By todoBar = By.ClassName("new-todo");
        By deleteBtn = By.ClassName("destroy");
        By todoList = By.ClassName("todo-list");
        By itemsLeft = By.TagName("strong");
        By firstTodo = By.ClassName("view");
        By toggle = By.ClassName("toggle");
        By clearCompleted = By.ClassName("clear-completed");
        By header = By.ClassName("header");
                
        //* Methods *//
        public TodoPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void EnterTextInHeader(String todo)
        {
            driver.FindElement(todoBar).SendKeys(todo);
        }
        
        public void addTodo(String todo)
        {
            driver.FindElement(todoBar).SendKeys(todo);
            driver.FindElement(todoBar).SendKeys(Keys.Return);
        }

        public void deleteTodo()
        {
            driver.FindElement(deleteBtn).Click();
        }

        public void clearTodo()
        {
            driver.FindElement(clearCompleted).Click();
        }

        public IWebElement getFirstTodo()
        {
            return driver.FindElement(firstTodo);
        }

        public IWebElement getToggle()
        {
            return driver.FindElement(toggle);
        }

        public IWebElement getClearCompleted()
        {
            return driver.FindElement(clearCompleted);
        }

        public IWebElement getItemsLeftQuantity()
        {
            return driver.FindElement(itemsLeft);
        }

        public IWebElement getFirstTodoInList()
        {
            return driver.FindElement(todoList).FindElement(By.XPath("//label[text()='Walk the dog']"));
        }

        public void editTodo(string newTodo)
        {
            IWebElement edit = driver.FindElement(By.ClassName("edit"));
            edit.SendKeys(Keys.Control + "a");
            String newtext = newTodo;
            edit.SendKeys(newtext);
            edit.SendKeys(Keys.Return);
        }

        public void deleteFirstTodo()
        {
            Thread.Sleep(1000);
            Actions action = new Actions(driver);
            action.MoveToElement(getFirstTodoInList()).Build().Perform();
            deleteTodo();
        }

        public void enableEditionOnTodo()
        {
            Actions action = new Actions(driver);
            action.DoubleClick(getFirstTodo()).Build().Perform();
            IWebElement edit = driver.FindElement(By.ClassName("edit"));
            edit.Click();
        }

        public bool isTodoListPresent(IWebDriver driver)
        {
            try
            {
                driver.FindElement(firstTodo);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool isTodoDeleteBtnPresent(IWebDriver driver)
        {
            if (driver.FindElement(deleteBtn).Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isClearCompletedBtnPresent(IWebDriver driver)
        {
            try
            {
                driver.FindElement(clearCompleted);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool headerHasText(IWebDriver driver)
        {
            if (driver.FindElement(todoBar).Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void waitUntilHeaderPresent()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(header));
        }
    }
}
