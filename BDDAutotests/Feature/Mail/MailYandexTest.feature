@Smoke
Feature: MailYandexTest
	

Scenario: Check the mail works correctly
	Given I open login page
	Given I log in as a user 
	When I create a letter
	And I save the letter as a draft
	When I open the draft folder
	And I send the letter
	Then The letter has been displayed in the sent folder
	When I log out
	Then I see the Enter to the mail button