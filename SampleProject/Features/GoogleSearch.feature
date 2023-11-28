Feature: GoogleSearch
To perform search operation on google home page. 

@tag1
Scenario: To perform search with google search button
	Given Google homepage should be loaded
	When Type "hp laptop" in the search text input
	And Click on the Google search button
	Then the results should be displayed on the next page with title "hp laptop - Google Search"

	Scenario: To perform search with IMFL button
	Given Google homepage should be loaded
	When Type "hp laptop" in the search text input
	And Click on the IMFL button
	Then the results should be Redirected to a new page with title "HP Laptops"