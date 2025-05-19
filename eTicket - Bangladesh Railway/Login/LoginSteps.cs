using eTicketBangladesh_Railway.Helper;
using Microsoft.Extensions.Configuration;

namespace eTicketBangladesh_Railway.Login
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage _page;
        private readonly IConfiguration _configuration;

        public LoginSteps(LoginPage page)
        {
            _page = page;
            _configuration = AppHelper.GetAppSettings();
        }

        [Given("Go to railway login page")]
        public void GivenGoToRailwayLoginPage()
        {
             _page.GetIAgreeButton().Click();
            _page.GetLoginPage().Click();
        }

        [When("Enter mobile number")]
        public void WhenEnterMobileNumber()
        {
            _page.GetMobileNumber().SendKeys(_configuration["Admin:Username"]);
        }

        [When("Enter password")]
        public void WhenEnterPassword()
        {
            _page.GetPassword().SendKeys(_configuration["Admin:Password"]);
        }

        [Then("Click on loginBtn")]
        public void ThenClickOnLoginBtn()
        {
            _page.GetLoginBtn().Click();
            _page.GetProfileDropdown().Click();
            Thread.Sleep(1000);
            Assert.True(_page.GetLogoutBtn().Displayed, "Logout Button is not displayed.");
        }

    }
}
