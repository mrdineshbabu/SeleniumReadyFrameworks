Feature: Division

A short summary of the feature

@tag1
Scenario: Division of two single digit numbers with positive value as result
	Given User launch the google calculator url
	When User press "6"
	And User press "÷"
	And User press "3"
	And User press "="
	Then User should see "2" in the result textbox

Scenario: Division of two single digit numbers with negative value as result
	Given User launch the google calculator url
	When User press "-"
	And User press "6"
	And User press "÷"
	And User press "3"
	And User press "="
	Then User should see "-2" in the result textbox

Scenario: Division of two negative single digit numbers with positive value as result
	Given User launch the google calculator url
	When User press "-"
	And User press "4"
	And User press "÷"
	And User press "-"
	And User press "2"
	And User press "="
	Then User should see "2" in the result textbox

Scenario: Division of two double digit numbers with positive value as result
	Given User launch the google calculator url
	When User press "2"
	And User press "0"
	And User press "÷"
	And User press "1"
	When User press "0"
	And User press "="
	Then User should see "2" in the result textbox

Scenario: Division of two double digit numbers with negative value as result
	Given User launch the google calculator url
	When User press "-"
	When User press "2"
	And User press "0"
	And User press "÷"
	And User press "1"
	When User press "0"
	And User press "="
	Then User should see "-2" in the result textbox

Scenario: Division of two decimal numbers with positive value as result
	Given User launch the google calculator url
	When User press "1"
	And User press "."
	And User press "4"
	And User press "÷"
	And User press "0"
	And User press "."
	And User press "2"
	And User press "="
	Then User should see "7" in the result textbox

Scenario: Division of two decimal numbers with negative value as result
	Given User launch the google calculator url
	When User press "-"
	And User press "1"
	And User press "."
	And User press "4"
	And User press "÷"
	And User press "0"
	And User press "."
	And User press "2"
	And User press "="
	Then User should see "-7" in the result textbox

Scenario: Division of a number by zero
	Given User launch the google calculator url
	When User press "6"
	And User press "÷"
	And User press "0"
	And User press "="
	Then User should see "Infinity" in the result textbox


