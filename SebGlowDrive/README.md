SebGlowDrive (the nearest street api)
====================

The project is as simple as in can be, thats why:

* no unit tests
* no logging
* no security
* no database
* no auto mappers etc.

## Limitations
No advanced algorithms, so the closest street is calculated as a closest straight line that contains a street segment.

## To run:
Hit F5 in Visual Studio (2017 or newer) or use a dotnet run command in .Net Core Cli.

## To test
The root folder of the solution contains Postman collection file (SebGlow.postman_collection.json) with two folders:

* InputStreets - used to initialize street data in the app (needs to be runned first)
* TestCases - a set of queries returning one or more results (or none if input streets are missing)

The collection file needs to be imported into Postman.