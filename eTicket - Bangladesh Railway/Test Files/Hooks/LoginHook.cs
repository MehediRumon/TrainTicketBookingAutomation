using eTicketBangladesh_Railway.Helper;
using eTicketBangladesh_Railway.Login;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicketBangladesh_Railway.Test_Files.Hooks
{
    public class LoginHook
    {
        private readonly LoginPage _loginPage;
        private readonly IConfiguration _configuration;
        public LoginHook(IWebDriver driver, ScenarioInfo scenarioInfo)
        {
            _loginPage = new LoginPage(driver);
            _configuration = AppHelper.GetAppSettings();
            if (scenarioInfo.Title.Contains("Log") == false)
            {
                GetAuthentication(_loginPage);
            }
        }

        private void GetAuthentication(LoginPage login)
        {
            Thread.Sleep(1000);
            login.GetIAgreeButton().Click();
            login.GetLoginPage().Click();
            login.GetMobileNumber().SendKeys(_configuration["Admin:Username"]);
            login.GetPassword().SendKeys(_configuration["Admin:Password"]);
            login.GetLoginBtn().Click();
        }
    }
}
