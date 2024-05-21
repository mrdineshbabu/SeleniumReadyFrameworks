Feature: KeypadValues

A short summary of the feature

Scenario: Verify Keypad Number - 0
	Given User launch the google calculator url
	When User press "0"
	Then User should see "0" in the result textbox

Scenario: Verify Keypad Number - 1
	Given User launch the google calculator url
	When User press "1"
	Then User should see "1" in the result textbox

Scenario: Verify Keypad Number - 2
	Given User launch the google calculator url
	When User press "2"
	Then User should see "2" in the result textbox

Scenario: Verify Keypad Number - 3
	Given User launch the google calculator url
	When User press "3"
	Then User should see "3" in the result textbox

Scenario: Verify Keypad Number - 4
	Given User launch the google calculator url
	When User press "4"
	Then User should see "4" in the result textbox

Scenario: Verify Keypad Number - 5
	Given User launch the google calculator url
	When User press "5"
	Then User should see "5" in the result textbox

Scenario: Verify Keypad Number - 6
	Given User launch the google calculator url
	When User press "6"
	Then User should see "6" in the result textbox

Scenario: Verify Keypad Number - 7
	Given User launch the google calculator url
	When User press "7"
	Then User should see "7" in the result textbox

Scenario: Verify Keypad Number - 8
	Given User launch the google calculator url
	When User press "8"
	Then User should see "8" in the result textbox

Scenario: Verify Keypad Number - 9
	Given User launch the google calculator url
	When User press "9"
	Then User should see "9" in the result textbox

Scenario: Verify Keypad Symbol Plus
	Given User launch the google calculator url
	When User press "+"
	Then User should see "+" in the result textbox

Scenario: Verify Keypad Symbol Minus
	Given User launch the google calculator url
	When User press "-"
	Then User should see "-" in the result textbox

Scenario: Verify Keypad Symbol Multiply
	Given User launch the google calculator url
	When User press "×"
	Then User should see "×" in the result textbox

Scenario: Verify Keypad Symbol Divide
	Given User launch the google calculator url
	When User press "÷"
	Then User should see "÷" in the result textbox

Scenario: Verify Keypad Symbol Dot
	Given User launch the google calculator url
	When User press "."
	Then User should see "." in the result textbox

Scenario: Verify Keypad Symbol AC
	Given User launch the google calculator url
	When User press "1"
	And User press "+"
	And User press "3"
	And User press "="
	Then User should see "4" in the result textbox
	When User press "AC"
	Then User should see "0" in the result textbox

Scenario: Verify Keypad Symbol CE
	Given User launch the google calculator url
	When User press "1"
	Then User should see "1" in the result textbox
	When User press "CE"
	Then User should see "0" in the result textbox

Scenario: Verify error value displayed
	Given User launch the google calculator url
	When User press "."
	Then User should see "." in the result textbox
	When User press "="
	Then User should see "Error" in the result textbox