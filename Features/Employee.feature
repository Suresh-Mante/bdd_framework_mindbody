@low
Feature: Employee
In order to add,edit, delete employee records 
As an admin
I want to modify the employee details in dashboard

Background:
	Given I have a browser and orangehrm page

Scenario Outline: Add Valid Employee
	When I enter username as '<username>'
	And I enter password as '<password>'
	And I click on Login
	And I click on PIM menu
	And I click on Add employee
	And I fill the add employee section
		| firstname   | middlename   | lastname   | employee_id   | toggle_login_detail   | username           | password           | confirm_password           | status   |
		| <firstname> | <middlename> | <lastname> | <employee_id> | <toggle_login_detail> | <account_username> | <account_password> | <account_confirm_password> | <status> |
	And I click on save
	Then I should be navigated to personal details section with added employee records.
Examples:
	| username | password | firstname | middlename | lastname | employee_id | toggle_login_detail | account_username | account_password | account_confirm_password | status   |
	| Admin    | admin123 | Suresh    | S          | Mante    | 1001        | off                 | surya            | Welcome@123      | Welcome@123              | disabled |
	| Admin    | admin123 | Surya     | S          | Mante    | 1002        | off                 | ganesh           | Welcome@123      | Welcome@123              | enabled  |


#1. Navigate to the url
#2. Enter Admin username
#3. Enter password
#4. Click Login
#5. click on PIM
#6. Click on Add Employee
#7. Enter firstname
#8. Enter middlename
#9. Enter lastname
#10. Enter Employee Id
#12. Check - create credential
#13. Enter Username
#14. Enter password
#15. Enter Confirm password
#16. Select status as Disabled
#17. Click on save
