Feature: Edit Products

This test case is designed to verify that is posible to Edit Products

@edit @High @smoke @Products @PUT
Scenario: Edit an existing product
	Given I have a valid endpoint 
	And I have the data to edit a product
	When a PUT request is sent
	Then I spect a valid response with the data changed
