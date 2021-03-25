Feature: IntegrationTests
	Non-UI elements of projection calculator integration tests

Scenario Outline: Calculate Growth
	Given I want to calculate <risk>
	And I give 'initial' investment of <money1>
	And I give 'monthly' investment of <money2>
	And my target is <target>
	And I hope to invest for <years>
	When I calculate the results
	Then I am told if my investment is <doable>
	And provided with a final yearly total of <total>
	Examples: 
	| risk   | money1 | money2 | target | years | doable | total |
	| low    | 100    | 2      | 150    | 2     | False  | 172   |
	| low    | 100    | 2      | 105    | 2     | True   | 172   |
	| medium | 100    | 2      | 150    | 2     | False  | 172   |
	| medium | 100    | 2      | 105    | 2     | True   | 172   |
	| high   | 100    | 2      | 150    | 2     | False  | 172   |
	| high   | 100    | 2      | 105    | 2     | True   | 172   |