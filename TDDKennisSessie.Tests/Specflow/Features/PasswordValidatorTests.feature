Feature: PasswordValidatorTests
	In order to avoid a silly password
	As a user
	I want to be told if my password is not safe enough

@mytag
Scenario: Given a valid password when validated the password should be valid
	Given a valid password
	When I validate that password
	Then the password validation result should be valid

Scenario: Given a invalid password when validated the password should be invalid
	Given a invalid password
	When I validate that password
	Then the password validation result should be invalid

Scenario: Given a password with seven characters the password should be invalid
	Given the password 1234567
	When I validate that password
	Then the password validation result should be invalid

Scenario: Given a password with seven characters the error message should be: Password must contain between 8-15 characters.
	Given the password 123ABCa
	When I validate that password
	Then the error message should be: Password must contain between 8-15 characters.

Scenario: Given a password without a number the error message should be: Password must at least contain one number.
	Given the password ABCDabcd
	When I validate that password
	Then the error message should be: Password must at least contain one number.

Scenario: Given a password without a capital letter the error message should be: Password must at least contain one capital letter.
	Given the password 123abcdefg
	When I validate that password
	Then the error message should be: Password must at least contain one capital letter.

Scenario: Given a password without a lowercase letter the error message should be: Password must at least contain one lowercase letter.
	Given the password 12334567A
	When I validate that password
	Then the error message should be: Password must at least contain one lowercase letter.

Scenario: Given a password with length longer than 15 the error message should be: Password must contain between 8-15 characters.
	Given the password 1233456789101234Aa
	When I validate that password
	Then the error message should be: Password must contain between 8-15 characters.