
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
	LibraryId varchar(50),
	DesignationID int,
	constraint Staffpk primary key(StaffID),
	constraint fk_DesignationID FOREIGN KEY (DesignationID) references Designation(DesignationID)
)


DELIMITER $$
DROP PROCEDURE IF EXISTS getStaff $$
CREATE PROCEDURE getStaff(IN parmLibraryId varchar(50))
BEGIN
	select SM.StaffID,SM.StaffName,SM.EmpNo,SM.JoinDate,SM.Emailaddress,SM.Address,D.DesignationName from StaffMember SM, Designation D  where SM.LibraryId= parmLibraryId and D.DesignationID= SM.DesignationID and  SM.Isdeleted=0 and SM.IsActive=1;
	
END $$

DELIMITER ;