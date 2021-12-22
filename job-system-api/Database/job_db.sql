CREATE TABLE Jobs(JobNumber int IDENTITY(1,1) NOT NULL PRIMARY KEY, Address varchar(100),Description varchar(500), JobType varchar(50), JobStatus varchar(50), StartDate datetime,CompletionDate datetime,HourEffort decimal(4,2),LastModified datetime)

CREATE TABLE Profiles(Id int IDENTITY(1,1) NOT NULL PRIMARY KEY, Name varchar(50),UserId INT, PhoneNumber varchar(50), EmailAddress varchar(50))