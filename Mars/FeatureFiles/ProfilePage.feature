Feature: Add Seller Profile Details
	In order to test the Add Profile Details functionality 
	As a seller
	I want to validate that i am able to add and
    see the details on the Profile page.

Scenario: I am able to add description
	Given I am at the Profile Page
	When I click description icon
	And I enter description
	And I click save
	Then Description saved message should be displayed
	And Saved description should be displayed on the profile page

Scenario: I am able to add a language
	Given I am at the Profile Page
	When I click Add New in languages 
	And I enter language
	And I choose language level 
	And I click Add in languages 
	Then Language saved message should be displayed
	And Added language should be displayed on the profile page

Scenario: I am able to add a skill
	Given I am at the Profile Page
	When I click skills tab
	And I click Add New in skills
	And I enter skill
	And I choose skill level
	And I click Add in skills
	Then Skill saved message should be displayed
	And Added skill should be displayed on the profile page

Scenario: I am able to add a certification
	Given I am at the Profile Page
	When I click certifications tab
	And I click Add New in certifications
	And I enter certificate
	And I enter certified from
	And I select year
	And I click Add in certifications
	Then Certification saved message should be displayed
	And Added certification should be displayed on the profile page

Scenario: I am able to add education
	Given I am at the Profile Page
	When I click education tab
	And I click Add New in education
	And I enter college
	And I select country
	And I select title
	And I enter degree
	And I select year of graduation
	And I click Add in education
	Then Education saved message should be displayed
	And Added education should be displayed on the profile page

Scenario: I am able to set availability
	Given I am at the Profile Page
	When I click availability icon
	And I select availability
	Then Availability updated message should be displayed

Scenario: I am able to set hours
	Given I am at the Profile Page
	When I click hours icon
	And I select hours
	Then Hours updated message should be displayed

Scenario: I am able to set earn target
	Given I am at the Profile Page
	When I click earn target icon
	And I select earn target
	Then Earn Target updated message should be displayed

Scenario: I am able to change password
	Given I am at the change password Page
	When I enter valid credentials
	And I click Save button
	Then Password changed message should be displayed	