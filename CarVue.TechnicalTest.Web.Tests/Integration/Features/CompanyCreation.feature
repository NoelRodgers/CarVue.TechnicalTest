@CompanyCreation @CompanyList @Common
Feature: CompanyCreation
	In order to be able add items into the company address book
	As a user of the Company Address Book
	I should be able to add a new company

Scenario: Navigate to the Add Company Page
	Given I am on the Company List Page
	When I click on the 'Create New Company' link
	Then I should be on the Company Add Page

Scenario: Check Company Name is required
	Given I am on the Company Add Page
	When I enter nothing into the 'Company Name' textbox
	And I click the 'Save' button
	Then I should see the 'Company Name is required' validation message 

Scenario: Save a new company
	Given I am on the Company Add Page
	When I enter 'My New Company' into the 'Company Name' textbox
	And I click the 'Save' button
	Then I should be taken to the Company List Page
	And I should see a message 'Company Saved'
	Then I should see a list of companies with the following items in the 'Company List' section:
		| Company Name   |
		| My New Company |
 