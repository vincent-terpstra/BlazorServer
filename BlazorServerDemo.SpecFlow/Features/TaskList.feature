@UseSlowBrowser
@TaskList
Feature: TaskList Page Tasks
	TaskList lists tasks for a user
	
Background: a user on the TaskList page
	Given a user logged in as username
	And the user is in the TaskList page

Scenario: User in TaskList page
	Then the name on the page is username
	
Scenario: Progress bar updates
	When the user adds a task "task one"
	Then the progress is 0
	And the task at 0 is "task one"
	When task 0 is clicked
	Then the progress is 100
	
Scenario: User cannot add empty tasks
	When the user adds a task ""
	Then total tasks is 0
