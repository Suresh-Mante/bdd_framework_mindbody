@high
Feature: EmergencyContacts
In order to reach the employee relation on emergency
As an admin
I want to access and update employee emergency contacts

Background:
	Given I have a browser and orangehrm page

Scenario Outline: Add Emergency Contact
	When I enter username as '<username>'
	And I enter password as '<password>'
	And I click on Login
	And I click on My Info
	And I click on Emergency Contacts
	And I click on Add Emergency Contact
	And I fill the Add Emergency Contact section
		| name   | relationship   | home_telephone   | mobile   | work_telephone   |
		| <name> | <relationship> | <home_telephone> | <mobile> | <work_telephone> |
	And I click on save
	Then I should be navigated to Assigned Emergency Contacts section with added Emergency Contacts.
Examples:
	| username | password | name  | relationship | home_telephone | mobile | work_telephone |
	| Admin    | admin123 | Jimmy | Brother      | 3444           | 554    | 5554           |
	| Admin    | admin123 | Saul  | Father       | 43444          | 3554   | 25554          |

