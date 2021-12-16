Feature: Country
	Check if endpoint is returning the same number of countires for each language

@smoke
Scenario: Check if the returning objects have the same countries
	Given user checks endpoint for different languages
		| Language |
		| en       |
		| es       |
		| br       |
	Then the result sould be the same for each language