using BDDAutotests.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using log4net.Config;
using log4net;

namespace BDDAutotests.Page
{
    public class LocationPage : BasePage
    {
        private By inputCityField = By.Id("city__front-input");
        private By cityDescription = By.CssSelector(".b-autocomplete-item__reg");

        private static  ILog logger = LogManager.GetLogger(typeof(LocationPage));       

        public SearchPage PressCityFromSuggetionMenu()
        {
            IsElementVisible(cityDescription);
            IWebElement cityDescriptionElement = Browser.GetDriver().FindElement(cityDescription);
            logger.Debug("Pressing the from suggetion menu.");

            Actions builder = new Actions(Browser.GetDriver());
            builder.Click(cityDescriptionElement).Build().Perform();

            logger.Debug("The city has been confirmed.");

            return new SearchPage();
        }

        public LocationPage TypeCity(string city)
        {
            base.JSClick(inputCityField);

            Browser.GetDriver().FindElement(inputCityField).Clear();
            Browser.GetDriver().FindElement(inputCityField).SendKeys(city);
            logger.Debug("The city has been typed");

            return this;
        }
    }
}
