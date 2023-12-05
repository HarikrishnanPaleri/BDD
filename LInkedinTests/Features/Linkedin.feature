Feature: Login
User logs in with valid credentials (username, password)
the homepage will load after successful login

A short summary of the feature
Background:
    Given User will be on the login page

@positive
Scenario Outline: Login with valid credentials
	
	When User will enter username '<UserName>'
	And User will enter password '<Password>'
	And User will click on login button
	Then User will be redirected to homepage
Examples: 
    | UserName    | Password |
    | abc@xyz.com | 122345   |
    | def@xyx.com | 98765    |
@negative
Scenario Outline: Login with Invalid credentials
	
	When User will enter username '<UserName>'
	And User will enter password '<Password>'
	And User will click on login button
	Then Error message for Password Lenth should be thrown
	Examples: 
    | UserName    | Password |
    | abc@xyz.com | 122345   |
    | def@xyx.com | 98765    |

@regression
Scenario Outline: Check For Password Hidden Display
	
	When User will enter password '<Password>'
	And User will click on show link in the password textbox
	Then The Password Characters Should Be Shown
Examples: 
    | Password |
    | 12334    |

	@regression
Scenario Outline: Check For Password show Display 
	
	When User will enter password '<Password>'
	And User will click on show link in the password textbox
	And User will click on Hide link in the password textbox
	Then The Password Characters Should not Be Shown
Examples: 
    | Password |
    | 12345    |