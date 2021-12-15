Feature: Country
	Check if endpoint is returning the same number of countires for each language

@smoke
Scenario: Add two numbers
	Given user checks endpoint for different languages
		| Language |
		| en       |
		| es       |
		| br       |
	Then the result sould be the same for each language