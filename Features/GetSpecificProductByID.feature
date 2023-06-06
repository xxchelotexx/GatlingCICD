Feature: GetSpecificID

A short summary of the feature

@GET @SpecificID
Scenario: Get Product by ID
	Given Given I have a Valid product ID
	When I send a Get request
	Then I Spect a Valid Response
