Feature: Status of APIs
		In order to check the status code of the api

@Api
Scenario Outline: Status Code of API Request
Given The credentials for post type are "<Username>", "<Password>" and "<Grant_Type>"
And I want to know the Status Code of the api with "<type>" and "<url>"
When I hit the request on the api
Then the system should return <status_code>
Examples:
	| type | url                                                                   | status_code | Username                           | Password         | Grant_Type | param |
	| Post | https://harmandealersdev.azurewebsites.net/api/v1/users/authenticate  | 200         | sandeep.vijayakumar@harman.com     | QWRpdGkwMSo=     | password   |       |
	| Post | https://harmandealersdev.azurewebsites.net/api/v1/users/authenticate  | 200         | Sonal.Tantuvay@harman.com          | QWRpdGkwMSo=     | password   |       |
	| Post | https://harmandealersdev.azurewebsites.net/api/v1/users/authenticate  | 200         | Seema.Joshi6@harman.com            | QWRpdGkwMSo=     | password   |       |
	| Post | https://harmandealersdev.azurewebsites.net/api/v1/users/authenticate  | 200         | Mahalakshmi.Subramanian@harman.com | QWRpdGkwMSo=     | password   |       |
	| Post | https://harmandealersdev.azurewebsites.net/api/v1/users/authenticate  | 200         | Saifulla.Moka@harman.com           | SGFybWFuQDEyMw== | password   |       |
	| Get  | http://harmandealershipadminservices.azurewebsites.net/api/v1/Dealers | 200         |                                    |                  |            |       |