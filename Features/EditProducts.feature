Feature: Edit Products

A short summary of the feature

@edit @Critital @smoke
Scenario: Edit an existing product
	Given I have a valid endpoint 
	And I have the data to edit a product
	When a PUT request is sent
	Then I spect a valid response with the data changed
