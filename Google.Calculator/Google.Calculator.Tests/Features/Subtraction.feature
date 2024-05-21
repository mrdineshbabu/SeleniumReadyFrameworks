Feature: Subtraction

A short summary of the feature

@tag1
Scenario: Subtraction of two single digit numbers with positive value as result
	Given User launch the google calculator url
	When User press "5"
	And User press "-"
	And User press "3"
	And User press "="
	Then User should see "2" in the result textbox

Scenario: Subtraction of two single digit numbers with negative value as result
	Given User launch the google calculator url
	When User press "1"
	And User press "-"
	And User press "3"
	And User press "="
	Then User should see "-2" in the result textbox

Scenario: Subtraction of two double digit numbers with positive value as result
	Given User launch the google calculator url
	When User press "5"
	When User press "5"
	And User press "-"
	And User press "2"
	When User press "2"
	And User press "="
	Then User should see "33" in the result textbox

Scenario: Subtraction of two double digit numbers with negative value as result
	Given User launch the google calculator url
	When User press "2"
	When User press "1"
	And User press "-"
	And User press "2"
	When User press "2"
	And User press "="
	Then User should see "-1" in the result textbox

Scenario: Subtraction of two decimal numbers with positive value as result
	Given User launch the google calculator url
	When User press "1"
	And User press "."
	And User press "4"
	And User press "-"
	And User press "0"
	And User press "."
	And User press "2"
	And User press "="
	Then User should see "1.2" in the result textbox

Scenario: Subtraction of two decimal numbers with negative value as result
	Given User launch the google calculator url
	When User press "1"
	And User press "."
	And User press "4"
	And User press "-"
	And User press "3"
	And User press "."
	And User press "2"
	And User press "="
	Then User should see "-1.8" in the result textbox