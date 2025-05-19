using OpenQA.Selenium;

namespace eTicketBangladesh_Railway.Book_Tickets
{
    public class BookTicketsElement
    {
        public static By SeatClassContainer => By.CssSelector(".single-seat-class");
        public static By SeatClassName => By.CssSelector(".seat-class-name");
        public static By BookNowButton => By.CssSelector("button.book-now-btn");
        


        public static By AllSeatClasses => By.CssSelector("div.single-seat-class");


        public static IWebElement CoachDropdown(IWebDriver driver) =>
            driver.FindElement(By.Id("select-bogie")); // Update locator as needed

        public static IReadOnlyCollection<IWebElement> AvailableSeats(IWebDriver driver) =>
            driver.FindElements(By.CssSelector(".btn-seat.seat-available"));
        public static By PurchaseButton => By.XPath("//button[@type='submit']");
    }
}
