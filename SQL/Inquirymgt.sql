create table Inquiry(

	InquiryID int auto_increment,
	InquiryDes varchar(100),
	InquiryResp varchar(100),
	AssignedEmpNo varchar(60),
	MemberId varchar(60),
	Isdeleted boolean,
	IsActive boolean,
	LogInfo  varchar(20),
	LastModifiedDateTime DATETIME,
	
	constraint Inquirypk primary key(InquiryID)
	
);

INSERT INTO Inquiry (InquiryDes, InquiryResp, AssignedEmpNo,MemberId,Isdeleted,IsActive,LogInfo)
VALUES (@InquiryDes, @InquiryResp, @AssignedEmpNo,@MemberId,@Isdeleted,@IsActive,@LogInfo);

UPDATE Inquiry SET InquiryResp=@InquiryResp WHERE InquiryID=@InquiryID