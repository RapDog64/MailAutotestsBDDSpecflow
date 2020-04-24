using BDDAutotests.Settings;
using log4net;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace BDDAutotests.Page.MarketPage
{
    public class MarketResultPage : BasePage
    {
        private By productName = By.CssSelector(".n-snippet-card2__title");
        private static readonly ILog logger = LogManager.GetLogger(typeof(MarketResultPage));


        public string PressOnTheEquipment(string nameOfProduct)
        {
            logger.Info("Waiting for " + productName + " element");
            IsElementVisible(productName);
            

            List<IWebElement> listOfSerchedProductNames = Browser.GetDriver().FindElements(productName).ToList();
            foreach (var product in listOfSerchedProductNames)
            {
                if (product.Text.Contains(nameOfProduct))
                {
                    return product.Text;
                }
            }

            logger.Debug("Didn't found " + productName);
            return "";
        }
    }
}
