@Counter
Feature: Counter Component checks

Scenario: Counter is clicked (.*) times
    Given a user in the counter page
    Then the page has errors is false
    When the increase button is clicked <total> times
    Then the counter value is <expected>
    Then the page has errors is <errors>

Examples:
  | total | expected | errors |
  | 1     | 1        | false  |
  | 2     | 2        | false  |
  | 3     | 3        | false  |
  | 4     | 3        | false  |
  | 5     | 3        | false  |
  | 6     | 3        | false  |
  | 7     | 7        | false  |
  | 8     | 8        | false  |
  | 9     | 9        | false  |
  | 10    | 9        | true   |