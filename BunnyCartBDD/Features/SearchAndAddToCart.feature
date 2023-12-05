Feature: SearchAndAddToCart

A short summary of the feature

@Product_Search
Scenario: 01 Search for products
	Scenario: Search & Add to Cart
	Given User will be on Homepage
	When User will type the '<searchtext>' in the searchbox
	Then Search Results are loaded in the same page with '<searchtext>'
	* Heading should have '<searchtext>'
	* Title should have '<searchtext>'
	When User selects a '<productno>'
	Then Product page '<searchtext>' is loaded
Examples:
	| searchtext | productno |
	| Water      | 1	|
	| Java	     | 1	|
