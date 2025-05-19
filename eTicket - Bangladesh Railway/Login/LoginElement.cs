using OpenQA.Selenium;

namespace eTicketBangladesh_Railway.Login
{
    public static class LoginElement
    {
        public static By LoginPage => By.XPath("//a[@title='Login' and @href='/login']");
        public static By IAgreeButton => By.CssSelector("button.agree-btn");
        public static By MobileNumber => By.XPath("//input[@id='mobile_number']");
        public static By Password => By.XPath("//input[@id='password']");
        public static By LoginBtn => By.XPath("//button[@type='submit']");
        public static By ProfileDropdown => By.XPath("//div[@class='railway-logged-user ng-tns-c37-11']");
        public static By LogoutBtn => By.XPath("//span[normalize-space()='Logout']");
    }
}
