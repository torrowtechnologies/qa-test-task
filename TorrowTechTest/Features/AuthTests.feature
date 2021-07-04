Feature: AuthTests
	Authorization on Terrow

@successphone
Scenario: success phone authorization
	Given click on enter
	Then input phone number
	Then click submit button
	Then open new page and get phone code
	Then input code
	Then check link
	
@successemail
Scenario: success email authorization
	Given click on enter
	Then click email link
	Then input email
	Then click submit email button
	Then open new page and get email code
	Then input code
	Then check link 

@wrongemail
Scenario: wrong format email
	Given click on enter
	Then click email link
	Then input wrong email <wrong_email>
	Then click submit email button
	Then check warning message email

Examples: 
|wrong_email|
|wrong		|
|wrong_@	|
|wrong@en	|
|wrong@en.	|
|русла"		|
|русла@аю.рф|

@wrongephone
Scenario: wrong format phone
	Given click on enter
	Then input wrong phone number
	Then click submit button
	Then check warning message phone


@wrongphonecode2
Scenario: input wrong phone code 2
	Given click on enter
	Then input phone number
	Then click submit button
	Then open new page and get phone code
	Then reverse code
	Then input wrong code
	Then wait
	Then input wrong code
	Then check warning message about code

@wrongphonecode3
Scenario: input wrong phone code 3
	Given click on enter
	Then input phone number
	Then click submit button
	Then open new page and get phone code
	Then reverse code
	Then input wrong code
	Then wait
	Then input wrong code
	Then wait
	Then input wrong code
	Then wait
	Then click on enter
	Then check warning message codes

@wrongemailcode2
Scenario: input wrong email code 2
	Given click on enter
	Then click email link
	Then input email
	Then click submit email button
	Then open new page and get email code
	Then reverse code
	Then input wrong code
	Then wait
	Then input wrong code
	Then check warning message about code

@wrongemailcode3
Scenario: input wrong email code 3
	Given click on enter
	Then click email link
	Then input email
	Then click submit email button
	Then open new page and get email code
	Then reverse code
	Then input wrong code
	Then wait
	Then input wrong code
	Then wait
	Then input wrong code
	Then wait
	Then check warning message codes

@longtimeforphone
Scenario: wait 1 minute for phone code
	Given click on enter
	Then input phone number
	Then click submit button
	Then wait minute
	Then wait
	Then click on enter
	Then check warning message code limit time

@longtimeforemail
Scenario: wait 1 minute for email code
	Given click on enter
	Then click email link
	Then input email
	Then click submit email button
	Then wait minute
	Then wait
	Then check warning message code limit time


