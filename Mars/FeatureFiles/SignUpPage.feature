Feature: Join and Sign In Page
	In order to test the registration and login functionality 
	As a user
	I want to be able to validate the Join and Sign In works

Scenario: When valid creds are used should result in successful registration
	Given I am at the Join page
	When I enter valid data
	And I agree to the terms and conditions
	And I click the Join button
	Then I should be registered successfully
	
Scenario: When valid creds are used should result in successful login
	Given I am at the Sign In page
	When I enter valid creds
	And I click the login button
	Then I should be logged in successfully