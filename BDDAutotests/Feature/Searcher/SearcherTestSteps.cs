using BDDAutotests.Page;
using BDDAutotests.Settings;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BDDAutotests.Feature.Searcher
{
    [Binding]
    public class SearcherTestSteps : BaseTest
    {
        [Given(@"I open search page")]
        public void GivenIOpenSearchPage()
        {
            new SearchPage().NavigateToSearchPage();     
        }

        [When(@"I click on location city button")]
        public void WhenIClickOnLocationCityButton()
        {
            new SearchPage().ClickOnLocationCityButton();
        }

        [Then(@"I type a (.*) of a city")]
        public void ThenITypeAOfACity(string expectedCity)
        {
            new LocationPage().TypeCity(expectedCity);
        }
        
        [Then(@"I press city from suggetion menu")]
        public void ThenIPressCityFromSuggetionMenu()
        {
            new LocationPage().PressCityFromSuggetionMenu();
        }

        [Then(@"Rerutn to the search page and see the location has been changed to (.*)")]
        public void ThenRerutnToTheSearchPageAndSeeTheLocationHasBeenChangedTo(string expectedCity)
        { 
            var actualCity = new SearchPage().GetCurrentLocationCity();
            Assert.That(actualCity, Is.EqualTo(expectedCity));
        }
    }
}
