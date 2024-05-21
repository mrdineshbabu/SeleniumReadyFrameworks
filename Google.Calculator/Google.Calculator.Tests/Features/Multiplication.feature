Feature: Multiplication

A short summary of the feature

@tag1
Scenario: Multiplication of two single digit numbers with positive value as result
	Given User launch the google calculator url
	When User press "5"
	And User press "×"
	And User press "3"
	And User press "="
	Then User should see "15" in the result textbox

Scenario: Multiplication of two single digit numbers with negative value as result
	Given User launch the google calculator url
	When User press "1"
	And User press "×"
	And User press "-"
	And User press "3"
	And User press "="
	Then User should see "-3" in the result textbox

Scenario: Multiplication of two negative single digit numbers with positive value as result
	Given User launch the google calculator url
	When User press "-"
	And User press "1"
	And User press "×"
	And User press "-"
	And User press "3"
	And User press "="
	Then User should see "3" in the result textbox

Scenario: Multiplication of two double digit numbers with positive value as result
	Given User launch the google calculator url
	When User press "1"
	And User press "0"
	And User press "×"
	And User press "2"
	When User press "0"
	And User press "="
	Then User should see "200" in the result textbox

Scenario: Multiplication of two double digit numbers with negative value as result
	Given User launch the google calculator url
	When User press "1"
	And User press "0"
	And User press "×"
	And User press "-"
	And User press "2"
	When User press "0"
	And User press "="
	Then User should see "-200" in the result textbox

Scenario: Multiplication of two decimal numbers with positive value as result
	Given User launch the google calculator url
	When User press "1"
	And User press "."
	And User press "4"
	And User press "×"
	And User press "0"
	And User press "."
	And User press "2"
	And User press "="
	Then User should see "0.28" in the result textbox

Scenario: Multiplication of two decimal numbers with negative value as result
	Given User launch the google calculator url
	When User press "1"
	And User press "."
	And User press "4"
	And User press "×"
	And User press "-"
	And User press "0"
	And User press "."
	And User press "2"
	And User press "="
	Then User should see "-0.28" in the result textbox
