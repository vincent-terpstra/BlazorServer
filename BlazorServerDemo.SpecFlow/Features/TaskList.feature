@UseSlowBrowser
@TaskList
Feature: TaskList Page Tasks
	TaskList lists tasks for a user

Background: a user on the TaskList page
	Given a user logged in as username
	And the user is in the TaskList page

Scenario: User in TaskList page
	Then the name on the page is username
