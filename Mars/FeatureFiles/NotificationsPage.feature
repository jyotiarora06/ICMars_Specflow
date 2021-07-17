Feature: Functionality around Notification
	
Scenario: I am able to Load More notifications
	Given I am at the Notifications Page
	When I click Load More
	Then More notifications should be loaded

Scenario: I am able to Show Less notifications
	Given I am at the Notifications Page
	When I click Load More
	And I click Show Less
	Then Less notifications should be displayed

Scenario: I am able to select a notification
	Given I am at the Notifications Page
	When I select a notification
	Then Notification should be selected

Scenario: I am able to unselect a notification
	Given I am at the Notifications Page
	When I select a notification
	And I unselect a notification
	Then Notification should be unselected

Scenario: I am able to Select all notifications
	Given I am at the Notifications Page
	When I click Select all 
	Then All notifications should be selected

Scenario: I am able to Unselect all notifications
	Given I am at the Notifications Page
	When I click Select all
	And I click Unselect all
	Then All notifications should be unselected

Scenario: I am able to mark notification as read
	Given I am at the Notifications Page
	When I select a notification
	And I click Mark selection as read
	Then Notification should be marked as read

Scenario: I am able to delete a notification
	Given I am at the Notifications Page
	When I select a notification
	And I click Delete selection
	Then Notification should be deleted