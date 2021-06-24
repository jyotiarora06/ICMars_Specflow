Feature: Functionality around Share Skill and Manage Listings

Scenario: I am able to create service listing
	Given I am at the Share Skill Page
	When I enter data in fields
	And I click save on Share Skill Page
	Then Service should be saved

Scenario: I am able to edit service listing
	Given I am at the Manage Listings Page
	When I click edit action
	And I update the data in fields
	And I click save on Share Skill Page
	Then Service should be updated 

Scenario: I am able to delete service listing
	Given I am at the Manage Listings Page
	When I click delete action
	And I click Yes on Delete your Service popup
	Then Service should be deleted 

