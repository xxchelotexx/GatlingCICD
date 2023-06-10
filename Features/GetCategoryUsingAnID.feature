Feature: Get Category using an ID

This test case is designed to Verify that is posible to get the data of a category using an ID

@GET @id @Category @Medium
Scenario: GET a category using an ID
	Given I Have a valid category endpoint
	And a valid category ID,
	When I send a GET  request
	Then I spect a valid response with the category data
