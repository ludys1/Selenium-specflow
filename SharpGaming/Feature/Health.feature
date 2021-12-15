Feature: Health
	Checking if health is OK

@smoke
Scenario: Health check
	Given user asks api for health
	Then health service should be ok