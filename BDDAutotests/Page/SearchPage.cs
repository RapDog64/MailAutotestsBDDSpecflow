using BDDAutotests.Settings;
using log4net;
using OpenQA.Selenium;

namespace BDDAutotests.Page
{
    public class SearchPage : BasePage
    {
        private By geoCityPositionButton = By.CssSelector(".geolink__reg");
        private const string url = "https://yandex.ru/";
        private static readonly ILog logger = LogManager.GetLogger(typeof(SearchPage));

        public SearchPage NavigateToSearchPage()
        {
            Browser.NavigateTo(url);
            logger.Error("Navigate to yandex search page");
            return this;
        }

        public LocationPage ClickOnLocationCityButton()
        {
            base.ClickButton(geoCityPositionButton);

            logger.Error("Clicked on location Button");

            return new LocationPage();
        }

        public string GetCurrentLocationCity()
        {
            logger.Error("Gets the current city");
            IsElementVisible(geoCityPositionButton);
            return GetTextByJS(geoCityPositionButton);
        }
    }
}
