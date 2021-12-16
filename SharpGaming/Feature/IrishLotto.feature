Feature: IrishLotto
	Check the results of Irish Lotto for last 7 days

@smoke
Scenario: Check if filtering by date is working properly
	Given user navigates to Irish Lotto page
	When user CTA result button
	And filter result for last seven days
	Then user should only see results from seven days ago