Feature: GetProducts

This test Case is designed to Verify that is posible to Get Products.

@Get @Products @smoke @medium
Scenario: Get Products
	Given I have a the Gatling enpoint
	When I send a GET request,
	Then I spect a valid response
