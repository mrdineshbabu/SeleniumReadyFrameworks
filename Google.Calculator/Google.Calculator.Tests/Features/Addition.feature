Feature: Addition

Tests related to Addition Functionality

Scenario: Addition of two single digit numbers
	Given User launch the google calculator url
	When User press "1"
	And User press "+"
	And User press "3"
	And User press "="
	Then User should see "4" in the result textbox

Scenario: Addition of two double digit numbers
	Given User launch the google calculator url
	When User press "21"
	And User press "+"
	And User press "22"
	And User press "="
	Then User should see "43" in the result textbox

Scenario: Addition of two decimal numbers
	Given User launch the google calculator url
	When User press "1"
	And User press "."
	And User press "4"
	And User press "+"
	And User press "3"
	And User press "."
	And User press "2"
	And User press "="
	Then User should see "4.6" in the result textbox