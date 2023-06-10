Feature: GetAllCategories

Test case designed to verify that is possible to get all categories

@Category @GET @smoke @medium
Scenario: Get Categories
	Given I have a categories endpoin
	When I send a GET request
	Then I spect  a valid response
