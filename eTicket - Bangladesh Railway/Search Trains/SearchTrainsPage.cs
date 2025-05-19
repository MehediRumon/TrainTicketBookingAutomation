using OpenQA.Selenium;

namespace eTicketBangladesh_Railway.Search_Trains
{
    public class SearchTrainsPage
    {
        private readonly IWebDriver _driver;
        public SearchTrainsPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement GetFromStation() => _driver.FindElement(SearchTrainsElement.FromStation);
        public IWebElement GetToStation() => _driver.FindElement(SearchTrainsElement.ToStation);
        public IWebElement GetDate() => _driver.FindElement(SearchTrainsElement.Date);
        public IWebElement GetClass() => _driver.FindElement(SearchTrainsElement.Class);
        public IWebElement GetSearch() => _driver.FindElement(SearchTrainsElement.Search);
        public IWebElement GetModifySearch() => _driver.FindElement(SearchTrainsElement.ModifySearch);
    }
}
