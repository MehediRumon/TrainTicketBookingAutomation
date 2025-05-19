using OpenQA.Selenium;

namespace eTicketBangladesh_Railway.Login
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement GetLoginPage() => _driver.FindElement(LoginElement.LoginPage);
        public IWebElement GetIAgreeButton() => _driver.FindElement(LoginElement.IAgreeButton);
        public IWebElement GetMobileNumber() => _driver.FindElement(LoginElement.MobileNumber);
        public IWebElement GetPassword() => _driver.FindElement(LoginElement.Password);
        public IWebElement GetLoginBtn() => _driver.FindElement(LoginElement.LoginBtn);
        public IWebElement GetProfileDropdown() => _driver.FindElement(LoginElement.ProfileDropdown);
        public IWebElement GetLogoutBtn() => _driver.FindElement(LoginElement.LogoutBtn);
    }
}
