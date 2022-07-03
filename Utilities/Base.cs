using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TodoListWebsite.Page;
using WebDriverManager.DriverConfigs.Impl;

namespace TodoListWebsite.Utilities
{
    public class Base
    {
        public IWebDriver driver;
        public ExtentReports extent;
        public ExtentTest test;
        
        //* Report Setting *//
        [OneTimeSetUp]
        public void ReportSetup()

        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Project: ", "Todos Website");
            extent.AddSystemInfo("Browser: ", "Chrome");
            extent.AddSystemInfo("QA Engineer: ", "Esteban Tedesco");
        }

        [SetUp]
        public void Setup()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://todomvc.com/examples/angular2/");
            driver.Manage().Window.Maximize();
            var todoPage = new TodoPage(driver);
            todoPage.waitUntilHeaderPresent();
        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            if (status == TestStatus.Failed)
            {
                test.Fail("Test failed");
                test.Log(Status.Fail, "Test failed with logtrace: " + stackTrace);
            }
            else if (status == TestStatus.Passed)
            {
                test.Pass("Test passed");
            }
            extent.Flush();
            driver.Quit();
        }
    }
}
