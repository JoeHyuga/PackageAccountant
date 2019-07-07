USE PackageDB
GO

CREATE TABLE IncomeExpenseDetails
(
	PTime datetime not null,
	PType varchar(10) not null,
	AccountItermId varchar(10) not null,
	Amount float not null,
	AccountTypeId varchar(10) not null,
	Comments varchar(max) null,
	Id int identity(1,1) primary key
)

GO