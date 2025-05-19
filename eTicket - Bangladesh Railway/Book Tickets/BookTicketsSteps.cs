using eTicketBangladesh_Railway.Book_Tickets;
using OpenQA.Selenium;
using Xunit.Abstractions;
using System;
using System.Linq;
using System.Threading;

namespace eTicketBangladesh_Railway
{
    [Binding]
    public class BookTicketsSteps
    {
        private readonly BookTicketsPage page;
        private readonly ITestOutputHelper testOutput;

        public BookTicketsSteps(BookTicketsPage page, ITestOutputHelper testOutput)
        {
            this.page = page;
            this.testOutput = testOutput;
        }

        [When(@"Click Book Now Button for Selected Class (.*)")]
        public void WhenClickBookNowButtonForSeatClass(string seatClass)
        {
            seatClass = seatClass.Trim('\"'); // Remove quotes if any
            Thread.Sleep(2000);

            var allSeatClassDivs = page.GetAllSeatClassElements();
            bool isClassFound = false;

            foreach (var div in allSeatClassDivs)
            {
                try
                {
                    var classNameElement = div.FindElement(page.GetSeatClassNameLocator());
                    string className = classNameElement.Text.Trim();

                    testOutput.WriteLine($"Found seat class: '{className}'");

                    if (className.Equals(seatClass, StringComparison.OrdinalIgnoreCase))
                    {
                        isClassFound = true;

                        var bookNowButtons = div.FindElements(page.GetBookNowButtonLocator());

                        if (bookNowButtons.Any() && bookNowButtons.First().Displayed)
                        {
                            var bookNowBtn = bookNowButtons.First();

                            page.ScrollToElement(bookNowBtn);
                            Thread.Sleep(500);

                            bookNowBtn.Click();
                            testOutput.WriteLine($"✅ Clicked 'BOOK NOW' for seat class: {seatClass}");
                        }
                        else
                        {
                            testOutput.WriteLine($"❌ Seat class '{seatClass}' not available (BOOK NOW button not displayed).");
                        }

                        break;
                    }
                }
                catch (NoSuchElementException)
                {
                    continue;
                }
            }

            if (!isClassFound)
            {
                testOutput.WriteLine($"❌ Seat class '{seatClass}' not found on the page.");
            }
        }

        [When("Select Available Seats")]
        public void WhenSelectAvailableSeats()
        {
            var coachElement = page.GetCoachElementWithAvailableSeats();
            page.ScrollToElement(coachElement);
            page.SelectCoachWithAvailableSeats();
            Thread.Sleep(1500);

            var selectedSeats = page.SelectAvailableSeats(4);

            if (selectedSeats.Count > 0)
            {
                testOutput.WriteLine("Selected Seats: " + string.Join(", ", selectedSeats));
            }
            else
            {
                testOutput.WriteLine("No available seats found.");
            }
        }

        [When("Click on Continue Purchase")]
        public void WhenClickOnContinuePurchase()
        {
            page.ScrollToPurchaseButton();
            page.GetPurchaseButton().Click();
        }
    }
}
