Feature: Create a Product

Test case desgined to test the creation of a product with the data (name, description, category and price)

@product @Create @smoke @critical
Scenario: Product Creation
	Given I have the product creation endpoint
	And valid data
	When I send a POST request,
	Then I receive a valid response with the new product data
