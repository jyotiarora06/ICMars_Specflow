Feature: Functionality around Chat

Scenario: I am able to chat with the seller
	Given I am at the Service Detail Page
	When I click Chat button
	And I enter message in the chat box
	And I click send
	Then Message should be sent

Scenario: I am able to view the chat history 
	Given I am in the Chat room
	When I enter seller name in search box
	Then Chat History with the seller should be visible 


