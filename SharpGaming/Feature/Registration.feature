Feature: Registration
	Registration to oddsking application

@smoke
Scenario: Perform Registration on oddsking application
	Given user is on home page
	And user CTA join button
	When user fill the register account from
	And user fill the personal form
	And user fill the contact form
	And user fill the address form
	And user fill the settings form
	Then user should be informed that registration was unsuccessful