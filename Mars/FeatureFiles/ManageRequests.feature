﻿Feature: Functionality around Manage Requests

Scenario: I am able to Accept Received Request
	Given I am at Received Requests page
	When I click Accept
	Then Request should be accepted

Scenario: I am able to Decline Received Request
	Given I am at Received Requests page
	When I click Decline
	Then Request should be declined

Scenario: I am able to Withdraw Sent Request
	Given I am at Sent Requests page
	When I click Withdraw
	Then Request should be withdrawn
	
Scenario: I am able to Complete Sent Request
	Given I am at Sent Requests page
	When I click Completed
	Then Request should be completed
	
	
