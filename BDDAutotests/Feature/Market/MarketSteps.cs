using BDDAutotests.Page.MarketPage;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BDDAutotests.Feature.Market
{
    [Binding]
    public class MarketSteps
    {

        private string actualProductName = "";

        [Given(@"I open market search page")]
        public void GivenIOpenMarketSearchPage()
        {
            new MarketSearchPage().GoToMarketPlace();
        }

        [Given(@"I type (.*)")]
        public void WhenIType(string productName)
        {
            new MarketSearchPage().TypeWordForSeacthing(productName);
        }

        [When(@"I press the Search button")]
        public void WhenIPressTheSearchButton()
        {
            new MarketSearchPage().PressSearchButton();
        }

        [When(@"I press on the Equipment with (.*)")]
        public void WhenIPressOnTheEquipmentWith(string productName)
        {
            actualProductName = new MarketResultPage().PressOnTheEquipment(productName);
        }

        [Then(@"The (.*) of product should be the same")]
        public void ThenTheOfProductShouldBeTheSame(string productName)
        {
            Assert.That(actualProductName, Is.EqualTo(productName));
        }
    }
}
