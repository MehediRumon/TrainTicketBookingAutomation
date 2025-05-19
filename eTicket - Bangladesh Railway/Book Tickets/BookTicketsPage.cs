using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace eTicketBangladesh_Railway.Book_Tickets
{
    public class BookTicketsPage
    {
        private IWebDriver _driver;

        public BookTicketsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IReadOnlyCollection<IWebElement> GetAllSeatClassElements() =>
            _driver.FindElements(BookTicketsElement.SeatClassContainer);

        public By GetSeatClassNameLocator() => BookTicketsElement.SeatClassName;
        public By GetBookNowButtonLocator() => BookTicketsElement.BookNowButton;

        public IWebElement GetPurchaseButton() => _driver.FindElement(BookTicketsElement.PurchaseButton);

        public void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView({ behavior: 'smooth', block: 'center' });", element);
        }

        public void ScrollToPurchaseButton()
        {
            IWebElement purchaseButton = GetPurchaseButton();
            ScrollToElement(purchaseButton);
        }

        public IWebElement GetCoachElementWithAvailableSeats()
        {
            return _driver.FindElement(By.XPath("//div[contains(@class,'seat-available-wrap')]"));
        }

        public void SelectCoachWithAvailableSeats()
        {
            var dropdown = BookTicketsElement.CoachDropdown(_driver);
            Thread.Sleep(1000);

            var select = new SelectElement(dropdown);

            foreach (var option in select.Options)
            {
                if (option.Text.Contains("Seat(s)"))
                {
                    var seatMatch = Regex.Match(option.Text, @"(\d+)\s*Seat\(s\)");
                    if (seatMatch.Success && int.Parse(seatMatch.Groups[1].Value) >= 1)
                    {
                        select.SelectByText(option.Text);
                        Thread.Sleep(1500);
                        break;
                    }
                }
            }
        }

        public List<string> SelectAvailableSeats(int maxSeats)
        {
            var selectedSeats = new List<string>();
            Thread.Sleep(1500);

            var seats = BookTicketsElement.AvailableSeats(_driver);

            foreach (var seat in seats)
            {
                if (selectedSeats.Count >= maxSeats)
                    break;

                try
                {
                    ScrollToElement(seat);
                    Thread.Sleep(300);

                    string seatNumber = seat.GetAttribute("title");
                    seat.Click();

                    Thread.Sleep(300); 
                    selectedSeats.Add(seatNumber);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Seat click error: " + ex.Message);
                }
            }

            return selectedSeats;
        }
    }
}
