Feature: ZipCodeRequest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@api
Scenario: US zip code 90210 returns expected place name
	Given Alice wants to learn the places associated with us zip code 90210
	When she consults the Zippopotam.us API
	Then she learns that the associated place name is Beverly Hills
