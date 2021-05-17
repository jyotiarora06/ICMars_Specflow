Feature: Add Seller Profile Details
	In order to test the Add Profile Details functionality 
	As a seller
	I want to validate that i am able to add and
    see the details on the Profile page.

Scenario: I am able to add description
	Given I am at the Profile Page
	When I click description icon
	And I enter description Testing Add Profile Details
	And I click save
	Then Description message Description has been saved successfully should be displayed
	And Description Testing Add Profile Details should be displayed on the profile page

Scenario: I am able to add a language
	Given I am at the Profile Page
	When I click Add New in languages 
	And I enter language English
	And I choose language level 
	And I click Add in languages 
	Then Language message English has been added to your languages should be displayed
	And Language English should be displayed on the profile page


Scenario: I am able to add a skill
	Given I am at the Profile Page
	When I click skills tab
	And I click Add New in skills
	And I enter skill Drum
	And I choose skill level
	And I click Add in skills
	Then Skill message Drum has been added to your skills should be displayed
	And Skill Drum should be displayed on the profile page


