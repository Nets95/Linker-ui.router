
CREATE DATABASE LinksDB;
GO

USE LinksDB 
GO

CREATE TABLE Link
(
	Id int NOT NULL IDENTITY(1,1),
	LinkTitle nvarchar(50) NOT NULL,
	CurrentDate nvarchar(25) NOT NULL,
	PRIMARY KEY (Id)
);
GO