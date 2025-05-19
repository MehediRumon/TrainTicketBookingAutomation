using OpenQA.Selenium;

namespace eTicketBangladesh_Railway.Search_Trains
{
    public static class SearchTrainsElement
    {
        public static By FromStation => By.XPath("//input[@id='dest_from']");
        public static By StationOption(string from) => By.XPath("/html/body//li[@class='ui-menu-item']/a[text()='{from}']");
        public static By ToStation => By.XPath("//input[@id='dest_to']");
        public static By Date => By.Id("doj");
        public static By Class => By.XPath("//select[@id='choose_class']");
        public static By Search => By.XPath("//button[@type='submit']");
        public static By ModifySearch => By.XPath("//button[@class='modify_search mod_search']");
    }
}
