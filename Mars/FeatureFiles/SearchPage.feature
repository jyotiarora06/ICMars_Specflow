Feature: Search skills
	In order to test the Search skills functionality 
	As a seller
	I want to validate that i am able to search and
    see the skills.

Scenario: I am able to search skills from all categories
	Given I am at the Search Page
	When I enter search data in Search skills 
	And I click enter
	Then Search data should be displayed
	
Scenario: I am able to search skills using filter
	Given I am at the Search Page
	When I select filter
	And I enter search data in Search skills 
	And I click enter
	Then Search data should be displayed