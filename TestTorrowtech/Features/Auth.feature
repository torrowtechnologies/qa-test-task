Feature: Auth in Torrowtech

Scenario: Succsessful auth
	Given go to the site torrow
	When enter phone number 9312679911 and wait 5 sec
	And enter code of phone message from number 79312679911
	Then auth succsess

Scenario: Auth with wrong code entered one or 3 times
	Given go to the site torrow
	When enter phone number 9312679911 and wait 5 sec
	And enter wrong code 3 times for 79312679911
	Then go to login page

Scenario: Long wait code
	Given go to the site torrow
	When enter phone number 9312679911 and wait 5 sec
	And wait 40 second
	Then go to login page

Scenario: Auth with EN language
	Given go to the site torrow
	When change language en
	When enter phone number 9312679911 and wait 5 sec
	And enter code of phone message from number 79312679911
	Then auth succsess
