Feature: Market

Background: 
	Given I open market search page


@MarketSmokeTest
Scenario Outline: Shoould search a product by its name
	Given I type <prodcutName>
	When I press the Search button
	And I press on the Equipment with <prodcutName>
	Then The <prodcutName> of product should be the same

	Examples:
		| prodcutName                                                             |
		| Ноутбук Apple MacBook Pro 13 with Retina display and Touch Bar Mid 2019 |