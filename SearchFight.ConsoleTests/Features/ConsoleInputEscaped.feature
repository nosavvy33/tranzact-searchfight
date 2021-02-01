Feature: ConsoleInputEscaped
	In order to enforce search results include certain words
	As a user
	I want to include quoted words in my search query

@positive @smoke
Scenario: Include quoted words in search query
	Given the query helper is available
	When I enter query as 'net php "java script"'
	Then the result should be 3