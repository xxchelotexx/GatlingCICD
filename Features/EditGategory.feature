Feature: Edit Category

This Test case is designed to Verify that is posible to Edit a Category

@edit @PUT @Category @smoke @Medium
Scenario: Edit Category
	Given I have a valid category endpoint
	And I have a valid ID
	And I have valid data.
	When I send a PUT request,
	Then I spect a valid response and the data edited.
