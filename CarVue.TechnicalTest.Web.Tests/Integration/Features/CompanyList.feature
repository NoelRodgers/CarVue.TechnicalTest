@CompanyList @Common
Feature: CompanyList
	In order to be able to view all the company contact information
	As a user of the Company Address Book
	I should be able to see a list of companies


Scenario: Companies List Page with no Companies
	Given I have no companies
	When I navigate to the Company List page
	Then I should see a message 'No companies found' in the 'Company List' section
	And I should not see a list of companies in the 'Company List' section


Scenario: Companies List Page with Companies
	Given I have the following companies with default information:
		| Company Name |
		| Company A    |
		| Company B    |
		| Company C    |
	When I navigate to the Company List page
	Then I should see a list of companies with the following items in the 'Company List' section:
		| Company Name |
		| Company A    |
		| Company B    |
		| Company C    |

