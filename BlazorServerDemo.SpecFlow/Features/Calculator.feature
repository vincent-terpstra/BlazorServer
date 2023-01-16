Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator]($projectname$/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

    @Calculator
    Scenario: Add two numbers
        Given the first number is <First>
        And the second number is <Second>
        When the two numbers are added
        Then the result should be <Add>

    Examples:
      | First | Second | Add |
      | 50    | 70     | 120 |
      | 30    | 40     | 70  |
      | 60    | 30     | 90  |

    Scenario: Subtract two numbers
        Given the first number is <First>
        And the second number is <Second>
        When the two numbers are subtracted
        Then the result should be <Subtract>

    Examples:
      | First | Second | Subtract |
      | 50    | 70     | -20      |
      | 30    | 40     | -10      |
      | 60    | 30     | 30       |