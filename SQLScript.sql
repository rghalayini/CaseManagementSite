Create table Customers
(
	Id int primary Key identity (1,1),
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Email nvarchar(50),
	AddressLine nvarchar(50),
	PostalCode nvarchar(50),
	City nvarchar(50),
	Phone nvarchar(50)
)
Create table CaseWorkers
(
	Id int primary Key identity (1,1),
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Email nvarchar(50),
	Phone nvarchar(50)
)
Create table CaseStatus
(
	Id int primary Key identity (1,1),
	Status nvarchar(50)
)
Create table Cases
(
	Id int primary Key identity (1,1),
	CaseWorkerId int,
	CustomerId int,
	CaseStatusId int,
	Title nvarchar(50),
	Description nvarchar(max),
	Created datetime,
	Modified datetime
)
Create table Comments
(
	Id int primary Key identity (1,1),
	CaseId int,
	CustomerId int,
	CaseWorkerId int,
	Description nvarchar(max),
	Created datetime
)

--add foreign keys
alter table Cases
add foreign key (CaseWorkerId) REFERENCES CaseWorkers(Id);
add foreign key (CustomerId) REFERENCES Customers(Id);
add foreign key (CaseStatusId) REFERENCES CaseStatus(Id);


alter table Comments
add foreign key (CaseId) REFERENCES CaseWorkers(Id);
add foreign key (CustomerId) REFERENCES Customers(Id);
add foreign key (CaseWorkerId) REFERENCES CaseStatus(Id);
