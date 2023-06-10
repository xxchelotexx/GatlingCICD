Feature: GetSpecificID

This test case is designed to Verify that is posible to get an specific product by ID

@GET @SpecificID @High @smoke
Scenario: Get Product by ID
	Given I have a Valid product ID
	When I send a Get request
	Then I Spect a Valid Response
