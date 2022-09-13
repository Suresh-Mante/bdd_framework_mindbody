Feature: PetShop
In order to create an environment to manage pet shop
As a user
I want to create, edit, delete, get pet details

Scenario: Find Pet By petId
Given I have base url 'https://petstore.swagger.io/v2/' and resource 'pet/120'
When I do the Get Request
Then I should get the response as 200
And I should get the details of pet in json format

Scenario: Find Pet By Invalid petId
Given I have base url 'https://petstore.swagger.io/v2/' and resource 'pet/-102'
When I do the Get Request
Then I should get the response as 400
And I should get the message as 'Invalid petId'

Scenario: Find pet by non-existing petId
Given I have base url 'https://petstore.swagger.io/v2/' and resource 'pet/502'
When I do the Get Request
Then I should get the response as 404
And I should get the message as 'Pet not found'

Scenario: Delete pet by petId
Given I have base url 'https://petstore.swagger.io/v2/' and resource 'pet/121'
And I need to add api_key 'Ak88' in the header
When I do the delete request
Then I should get the response as 200

Scenario: Delete pet by invalid petId
Given I have base url 'https://petstore.swagger.io/v2/' and resource 'pet/-102'
And I need to add api_key 'Ak88' in the header
When I do the delete request
Then I should get the response as 400
And I should get the message as 'Invalid petId'

Scenario: Delete pet by non-existing petId
Given I have base url 'https://petstore.swagger.io/v2/' and resource 'pet/502'
And I need to add api_key 'Ak88' in the header
When I do the delete request
Then I should get the response as 404
And I should get the message as 'Pet not found'