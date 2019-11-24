using System;
using TechTalk.SpecFlow;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace UnitTestProject1.StepDefinition
{
    [Binding]

    public class AmazonBooksBuySteps
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;

        public void SetUp()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }


        [Given(@"I navigate to “www\.amazon\.com”\.")]
        public void GivenINavigateToWww_Amazon_Com_()
        {
            driver.Navigate().GoToUrl("https://www.amazon.com.br/");
            driver.Manage().Window.Size = new System.Drawing.Size(1600, 860);
            Assert.IsTrue(driver.Title.ToLower().Contains("amazon"));
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I select the option “Books” in the dropdown next to the search text input criteria\.")]
        public void WhenISelectTheOptionBooksInTheDropdownNextToTheSearchTextInputCriteria_()
        {
            var element = driver.FindElement(By.CssSelector(".hm-icon"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(element).Perform();

            driver.FindElement(By.CssSelector(".hm-icon")).Click();
            driver.FindElement(By.CssSelector(".hmenu-visible > li:nth-child(9) > .hmenu-item")).Click();
            driver.FindElement(By.CssSelector(".hmenu-visible > li:nth-child(3) div")).Click();
        }
        
        [When(@"I reach the detailed book page, I check if the name in the header is the same name of the book that I select previously\.")]
        public void WhenIReachTheDetailedBookPageICheckIfTheNameInTheHeaderIsTheSameNameOfTheBookThatISelectPreviously_()
        {
            Assert.IsTrue(driver.Title.ToLower().Contains("livros"));
        }
        
        [Then(@"I search for “Test automation”\.")]
        public void ThenISearchForTestAutomation_()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).Click();
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("Test automation");
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys(Keys.Enter);
        }
        
        [Then(@"I select the cheapest book of the page without using any sorting method available\.")]
        public void ThenISelectTheCheapestBookOfThePageWithoutUsingAnySortingMethodAvailable_()

        { 

            List<IWebElement> allBooks = driver.FindElement(By.PartialLinkText("Test"));
            Array.Sort(allBooks);

            String bookName = allBooks.First();

            driver.FindElement(By.Name(bookName)).Click();
            driver.FindElement(By.Id("add-to-cart-button")).Click();
        }
    }
}
