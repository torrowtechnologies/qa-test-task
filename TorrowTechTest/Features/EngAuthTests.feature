Feature: EngAuthTests
	all test on en

@successphoneen
Scenario: success phone authorization en
	Given change langugae
	Then click on enter
	Then input phone number
	Then click submit button
	Then open new page and get phone code
	Then input code
	Then check link
	
@successemailen
Scenario: success email authorization en
	Given change langugae
	Then click on enter
	Then click email link
	Then input email
	Then click submit email button
	Then open new page and get email code
	Then input code
	Then check link 

@wrongemailen
Scenario: wrong format email en
	Given change langugae
	Then click on enter
	Then click email link
	Then input wrong email <wrong_email>
	Then click submit email button
	Then check warning message email

Examples: 
|wrong_email|
|wrong		|
|wrong_@	|
|wrong@en	|
|wrong@en	|
|wrong@en.	|
|русла"		|
|русла@аю.рф|

@wrongephoneen
Scenario: wrong format phone en
	Given change langugae
	Then click on enter
	Then input wrong phone number
	Then click submit button
	Then check warning message phone


@wrongphonecode2en
Scenario: input wrong phone code 2 en
	Given change langugae
	Then click on enter
	Then input phone number
	Then click submit button
	Then open new page and get phone code
	Then reverse code
	Then input wrong code
	Then wait
	Then input wrong code
	Then check warning message about code

@wrongphonecode3en
Scenario: input wrong phone code 3 en
	Given change langugae
	Then click on enter
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

@wrongemailcode2en
Scenario: input wrong email code 2 en
	Given change langugae
	Then click on enter
	Then click email link
	Then input email
	Then click submit email button
	Then open new page and get email code
	Then reverse code
	Then input wrong code
	Then wait
	Then input wrong code
	Then check warning message about code

@wrongemailcode3en
Scenario: input wrong email code 3 en
	Given change langugae
	Then click on enter
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

@longtimeforphoneen
Scenario: wait 1 minute for phone code en
	Given change langugae
	Then click on enter
	Then input phone number
	Then click submit button
	Then wait minute
	Then wait
	Then click on enter
	Then check warning message code limit time

@longtimeforemailen
Scenario: wait 1 minute for email code en
	Given change langugae
	Then click on enter
	Then click email link
	Then input email
	Then click submit email button
	Then wait minute
	Then wait
	Then check warning message code limit time