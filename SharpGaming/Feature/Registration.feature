﻿Feature: Registration
	Registration to oddsking application

@smoke
Scenario: Perform Registration on oddsking application
	Given user is on home page
	And user CTA register button
	When user fill the register form
	Then he should be informed about wrong location