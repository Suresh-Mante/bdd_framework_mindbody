@very_high
Feature: Login
	In order to maintain the employees
	As a user
	I want to login into the portal

Background:
	Given I have a browser and orangehrm page

Scenario: Valid Credentials
	When I enter username as 'Admin'
	And I enter password as 'admin123'
	And I click on Login
	Then I should be successfully logged in
	And I shoud be navigated to 'PIM' dashboard screen

#Scenario: Invalid Credentials
#Given I have a browser and orangehrm page
#When I enter username as 'Adminn'
#And I enter password as 'admin123'
#And I click on Login
#Then I should not be able log in
#And I should get an error message as 'Invalid credentials'

Scenario Outline: Invalid Credentials
	When I enter username as '<username>'
	And I enter password as '<password>'
	And I click on Login
	Then I should not be able to log in
	And I should get an error message as '<error_message>'
Examples:
	| username | password | error_message       |
	| john     | john123  | Invalid credentials |
	| saul     | saul123  | Invalid credentials |