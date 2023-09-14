-------Instructions to build----------
Update CORS policy in Program.cs as per need. Currently open for every origin
LoonsTimetableContext in asssettings.json use the default database provided. All the exam schedules will be saved there.
Migrations are in place. Use Nuget Package Manager console and type 'update-database' to run migrations and create database.
Swagger is used and after building the solution 'LoonsTimetable' all the endpoints will be viewed.
Endpoints in the ExamSchedule have the required tasks. 
	Getting all exam schedules
	Getting specific exam Schedule
	Generating exam schedules
	Saving chosen exam Schedule
Endpoints in the Exam are there, but not in need.

Unit Tests can be found in 'LoonTimetable.Test' solution.
Start of controller unit tests and services unit tests are written.


-------Discussion of Technologies---------
.NET core 6 with Entity Framework Core.
Swagger to display endpoints more desciptively.
Use of dependancy Injection in controllers from services.
Interface classes and implementation in services but in the same file.

Xunit for testing with fakeiteasy for fake data.

React for the frontend application with vite.


