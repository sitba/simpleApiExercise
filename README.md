Recruiting test:

Build a simple api:

Build a simple application to manage providers. 
This application should be able to :
- import a list of providers
- retrieve a provider information

Requirements :
-  The application should be an API built in C#
-  You can apply any clean architecture to make it maintenable
-  You should add all necessary automated tests.
-  You can use any local storage systems for providers data (file, localdb, etc..)
-  The API should respect the described behaviors shown the examples below :  

Examples :

1) POST /providers/import 
Request :

[
  {
	  "provider_id": 1,
	  "name": "Alex",
	  "postal_address" : "2 rue des invalides, Paris",
	  "created_at": "2022-01-30T12:21:26Z",
	  "type" : "domestic"
  },
  {
	  "provider_id":2,
	  "name": "Alex",
	  "postal_address" : "1 rue de la paix, Paris",
	  "created_at": "2023-01-30T12:21:26Z",
	  "type" : "roadside"
  }
]
  
Repsonse :
 
 - 200 OK
     {
       "provider_id":"1",
       "name": "Alex",
     } 
 
 - 400 Bad Request
     {
	   "errorCode": "Bad Request",
       "errorDescription": "{error message here}"	   
	 }   
	 
 - 500 InternalServerError when something goes wrong
     {
	   "errorCode": "InternalServerError",
       "errorDescription": "An error server occured."	   
	 }

2) GET /providers/{provider_id} 
 '{provider_id}' is the Id of the provider to retrieve from the local storage.

Request :

For provider_id = 1

GET /providers/1
 
Response :
- 200 OK :
	 {
	  "provider_id":1,
	  "name": "Alex",
	  "postal_address" : "2 rue des invalides, Paris",
	  "created_at": "2022-01-30T12:21:26Z"
	 }

- 400 BadRequest
     {
	   "errorCode": "Bad Request",
       "errorDescription": "{error message here}"	   
	 }   
	 
	 
- 401 Not Found : When the provider does not exist in the local storage
  For provider_id = 5
     {
	   "errorCode": "NotFound",
       "errorDescription": "The provider '5' not found."	   
	 }