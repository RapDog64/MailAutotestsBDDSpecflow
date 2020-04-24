using BDDAutotests.Settings;
using log4net;
using OpenQA.Selenium;

namespace BDDAutotests.Page.MarketPage
{
    public class MarketSearchPage : BasePage
    {
        private string url = "https://market.yandex.ru/";
        private By searchField = By.Id("header-search");
        private By searchButton = By.XPath("//button[@type='submit']");
        private static readonly ILog logger = LogManager.GetLogger(typeof(MarketResultPage));
        public MarketSearchPage GoToMarketPlace()
        {
            Browser.NavigateTo(url);
            return this;
        }

        public MarketSearchPage TypeWordForSeacthing(string equipment)
        {
            base.ClickButton(searchField);
            logger.Debug("typing name of " + equipment);
            Browser.GetDriver().FindElement(searchField).SendKeys(equipment);
            
            return this;
        }

        public MarketResultPage PressSearchButton()
        {
            base.ClickButton(searchButton);
            logger.Debug("Pressed the search button.");

            return new MarketResultPage();
        }
    }
}
