Feature: Search

A short summary of the feature

@Product_Search
Scenario: Search for products
	Given User will be on Homepage
	When User will type the '<searchtext>' in the searchbox
 #* User clicks on search button
	Then Search Results are loaded in the same page with '<searchtext>'
Examples:
    | searchtext |
    | water      |
    | java       |
    | hairgrass  |
