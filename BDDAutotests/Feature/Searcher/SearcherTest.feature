Feature: SearcherTest

@SmokeSearcherTest
Scenario Outline: Change location on the Yandex searcher
	Given I open search page
	When I click on location city button
	Then I type a <name> of a city
	And I press city from suggetion menu
	Then Rerutn to the search page and see the location has been changed to <name>

	Examples:
		| name            |
		| Санкт-Петербург |