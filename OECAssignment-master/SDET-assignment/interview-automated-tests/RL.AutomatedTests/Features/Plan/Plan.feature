Feature: Plan feature
    Test creating and adding procedures to a plan

    # example
    Scenario: Create Plan
        Given I'm on the start page
        When I click on start
        Then I'm on the plan page

# Expected test
  Scenario: Adding user to a plan procedure
        Given I'm on the start page
        When I click on start
        Then I'm on the plan page
        When I click on the checkbox a procedure
        Then I should see the selected procedure under the added to plan section
        When I assign the procedure to a user
        Then I should see the assigned user name in the user section
        When I refresh the page
        Then I should see the assigned user name in the user section after refresh