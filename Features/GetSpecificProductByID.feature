Feature: GetSpecificID

A short summary of the feature

@GET @SpecificID @critical
Scenario: Get Product by ID
	Given I have a Valid product ID
	When I send a Get request
	Then I Spect a Valid Response
