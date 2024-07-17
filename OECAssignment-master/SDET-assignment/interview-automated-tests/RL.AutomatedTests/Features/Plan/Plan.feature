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
        When I click on the procedure "Front Seat Control Switch - Removal and Installation - Front Seats"
        Then I should see the selected procedure under the added to plan section
        When I click on the procedure "Specifications - Specifications - Suspension System - General Information"
        Then I should see the selected procedure under the added to plan section
        When I assign the procedure "Front Seat Control Switch - Removal and Installation - Front Seats" to "Nick Morrison"
        Then I should see "Nick Morrison" under the procedure "Front Seat Control Switch - Removal and Installation - Front Seats"        
        When I assign the procedure "Specifications - Specifications - Suspension System - General Information" to "Nick Morrison"
        Then I should see "Nick Morrison" under the procedure "Specifications - Specifications - Suspension System - General Information"
        When I assign the procedure "Specifications - Specifications - Suspension System - General Information" to "Tony Bidner"
        Then I should see "Nick Morrison" under the procedure "Specifications - Specifications - Suspension System - General Information"
        When I refresh the page
        Then I should see "Nick Morrison" under the procedure "Front Seat Control Switch - Removal and Installation - Front Seats" after refresh
        Then I should see "Nick Morrison" under the procedure "Specifications - Specifications - Suspension System - General Information" after refresh
        Then I should see "Nick Morrison" under the procedure "Specifications - Specifications - Suspension System - General Information" after refresh

