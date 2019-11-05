
create table Designation(

	DesignationID int,
	DesignationName varchar(60),
	Isdeleted boolean,
	IsActive boolean,
	LogInfo  varchar(20),
	
	constraint Designationpk primary key(DesignationID)
	
);



create table StaffMember(

	StaffID int auto_increment ,
	StaffName varchar(60),
	EmpNo varchar(60) UNIQUE,
	JoinDate Date,
	Dob Date,
	Emailaddress varchar(60),
	Address varchar(80),
	Isdeleted boolean,
	IsActive boolean,
	LogInfo  varchar(20),
	LibraryId int,
	DesignationID int,
	constraint Staffpk primary key(StaffID),
	constraint fk_DesignationID FOREIGN KEY (DesignationID) references Designation(DesignationID)
)
