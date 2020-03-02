Feature: LoanRequest 
	In order to

@browser
Scenario: Loan request is denied
	Given Bart wants to apply for a loan
	When he submits a request for a 10000 dollar loan with a 100 dollar down payment
	Then he sees that his loan request is denied
