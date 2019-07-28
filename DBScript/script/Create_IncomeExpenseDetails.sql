USE PackageDB
GO

--this table use for showing the details of income or expense, the data will have show two different type from income or expense
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