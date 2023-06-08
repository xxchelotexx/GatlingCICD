Feature: Get Categories

Test Designed to verify if it is possible to get all the categories with the enpoint

@edit @Critital @smoke
Scenario: Get Categories
	Given I have a valid endpoint for categories
	When a GET request is sent
	Then I spect a valid response.