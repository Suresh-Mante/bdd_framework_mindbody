Feature: Store
In order to create an environment to manage pet shop
As a user
I want to handle the orders

Scenario: Find purchase order by Id
Given I have base url 'https://petstore.swagger.io/v2/' and resource 'store/order/3'
When I do the Get Request
Then I should get the response as 200
And I should get the details of purchase order in json format