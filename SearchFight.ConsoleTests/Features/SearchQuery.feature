Feature: SearchQuery
	In order to get results from given search engines
	As a user
	I want to search these words

@positive @smoke
Scenario: Get results from two search engines
	Given two search engines are set
	When I enter my search words as 'net java'
	Then the results should include 4 search results
	And the results include 2 search engine winners
	And the results has an absolute winner