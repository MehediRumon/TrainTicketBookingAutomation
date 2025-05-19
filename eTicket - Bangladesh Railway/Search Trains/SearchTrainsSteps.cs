using eTicketBangladesh_Railway.Login;
using eTicketBangladesh_Railway.Search_Trains;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;

namespace eTicketBangladesh_Railway
{
    [Binding]
    public class SearchTrainsSteps
    {
        private readonly SearchTrainsPage _page;
        private readonly IWebDriver _driver;

        public SearchTrainsSteps(SearchTrainsPage page, IWebDriver driver)
        {
            _page = page;
            _driver = driver;
        }

        [Given("Select From Station {string}")]
        public void GivenSelectFromStation(string fromStation)
        {
            var input = _page.GetFromStation();
            input.Click();
            Thread.Sleep(500);
            input.SendKeys(fromStation);
            Thread.Sleep(1000); // wait for suggestions to appear

            // Press Arrow Down and Enter to select first suggestion
            input.SendKeys(Keys.ArrowDown);
            input.SendKeys(Keys.Enter);
        }

        [When("Select To Station {string}")]
        public void WhenSelectToStation(string toStation)
        {
            var input = _page.GetToStation();
            input.Click();
            Thread.Sleep(500);
            input.SendKeys(toStation);
            Thread.Sleep(1000); // wait for suggestions

            //input.SendKeys(Keys.ArrowDown);
            input.SendKeys(Keys.Enter);
        }


        [When("Select Date of Journey {string}")]
        public void WhenSelectDateOfJourney(string date)
        {
            string futureDate = DateTime.Now.AddDays(9).ToString("dd/MM/yyyy");

            var dateField = _page.GetDate();

            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].value = arguments[1];", dateField, futureDate);
        }


        [When("Choose Class {string}")]
        public void WhenChooseClass(string tclass)
        {
            var selectElement = new SelectElement(_page.GetClass());
            selectElement.SelectByText(tclass);
        }

        [When("Click on Search Trains")]
        public void WhenClickOnSearchTrains()
        {
            _page.GetSearch().Click();
            Thread.Sleep(1000);
        }

        [Then("Verify Search Result")]
        public void ThenVerifySearchResult()
        {
            Assert.True(_page.GetModifySearch().Displayed, "Modify Search Button Not Displayed");
        }
    }
}
