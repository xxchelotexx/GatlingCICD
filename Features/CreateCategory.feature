Feature: CreateCategory

This test case is designed to Verify that is posible to create a Category

@Create @Category @Post @smoke @High
Scenario: Create Category
	Given I have a valid Category endpoint
	And valid data to create a category
	When I  send a POST request
	Then I spect a valid response and the new category data.
