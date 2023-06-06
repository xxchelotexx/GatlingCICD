Feature: GetProducts

A short summary of the feature

@Get @Products
Scenario: Get Products
	Given I have a the Gatling Enpoint
	When I send a GET request
	Then I spect a valid response with all products
