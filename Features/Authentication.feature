Feature: Authentication

A short summary of the feature

@Critical @Authentication @smoke-test
Scenario: Authentication using Valid Credentials
	Given I authenticate using valid credentials
	When I send a POST request
	Then I receive a valid response and a valid Token
