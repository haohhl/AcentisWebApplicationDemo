#### Step 1:
Open Solution in Visual Studio
#### Step 2:
- Modify param (User Id & Password ) ConnectionStrings by your Sql Server Management Studio account.
- This configuration is configured in appsettings.json
#### Step 3: 
- Open Package Manager Console in Visual Studio 
*(Tools -> Nuget Package Manager -> Package Manager Console)*
- Run Command: Update-Database
- Start Solution
#### Step 4: 
- Run API Function: (in a Postman environment)
- **Register:** https://localhost:44308/api/member/register
	*method*: GET
	*param test:*   
` {`
        	`"Name": "haovu",`
        	`"Email": "haovu@gmail.com",`
        	`"password": "123456",`
        	`"MobileNumber": "0999988922",`
        	`"Gender": "Male",`
        	`"DateOfBirth": "05/29/2015 05:50"`
        	`}`

- **Login:** https://localhost:44308/api/member/login
	*method:* POST
	*param test:* 
	`{`
`"Email": "haovu@gmail.com",`
	`"password": "123456"`
	`}`
- **Show Profile:** https://localhost:44308/api/member/profile
*method:* GET
*param test:* 
	`email: haovu@gmail.com`
	`token: (get token in Login API)`

- **Update Member:** https://localhost:44308/api/member/update
*method:* POST
*param test:* 
`{`
    `"id": 1,`
    `"name": "Vu Hao",`
    `"email": "haovu@gmail.com",`
    `"mobileNumber": "88888888",`
    `"Password": "123456",`
    `"gender": "Femail",`
    `"dateOfBirth": "2019-05-29T05:50:00",`
    `"emailOptIn": null`
`}`

**Notice:** Program is not perfect for all test  case like: Check exist user, Show error message, ...
So sorry about this inconvenient I will fix next version. 
Thanks you and Best Regards, 
VDHAO.
