Feature: Authentication

This test case is designed to Verify that is possible to Authenticate using valid credentials

@High @Authentication @smoke-test
Scenario: Authentication using Valid Credentials
	Given I authenticate using valid credentials
	When I send a POST request
	Then I receive a valid response and a valid Token
