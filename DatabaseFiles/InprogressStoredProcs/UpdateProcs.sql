create proc spUpdateUser
 @UserID VARCHAR(45) = NULL,
  @Email VARCHAR(45) = NULL,
  @FirstName VARCHAR(45) = NULL,
  @LastName VARCHAR(45) = NULL,
  @ZipCode VARCHAR(45) = NULL,
  @Dob VARCHAR(45) = NULL,
  @PasswordHashed VARCHAR(45) = NULL,
  @TagsFound INT = NULL,
  @TagsPosted INT = NULL,
  @Gender VARCHAR(10) = NULL
as
UPDATE  Users
set Email = @Email, 
FirstName = @FirstName,  
LastName = @LastName, 
ZipCode  = @ZipCode,
 Dob  = @Dob,
 PasswordHashed  = @PasswordHashed, 
 TagsFound  = @TagsFound,
 TagsPosted  = @TagsPosted, 
 Gender = @Gender
 where UserID = @UserID;
 GO
  
 CREATE  proc spUpdateTagPrivacyType
 @PrivacyTypeID INT,
  @PrivacyDescription VARCHAR(45) = NULL
  
  as
update  TagPrivacyType
set PrivacyDescription = @PrivacyDescription
where PrivacyTypeID = @PrivacyTypeID;
GO
CREATE  proc spUpdateTag 

  @TagID INT,
  @TagLongitude VARCHAR(45) = NULL,
  @TagLatitude VARCHAR(45) = NULL,
  @TagDescription VARCHAR(45) = NULL,
  @TagDateCreated DATETIME = NULL,
  @TagExpired DATETIME = NULL,
  @UserID INT,
  @TagContent_URL VARCHAR(70) = NULL,
  @PrivacyTypeID INT
  AS
update Tag
set TagLongitude = @TagLongitude, 
TagLatitude = @TagLatitude, 
TagDescription = @TagDescription, 
TagDateCreated = @TagDateCreated, 
TagExpired = @TagExpired, 
UserID = @UserID, 
TagContent_URL = @TagContent_URL, 
PrivacyTypeID = @PrivacyTypeID
where TagID = @TagID;
  GO
  
CREATE  proc spUpdateTagRating 
  @RatingID INT,
  @Rate INT = NULL,
  @TagID INT,
  @UserID INT
  as
update TagRating
set Rate = @Rate, TagID = @TagID, UserID = @UserID
where RatingID =  @RatingID


GO

-- -----------------------------------------------------
-- proc spInsertmydb.tblCategory
-- -----------------------------------------------------
CREATE  proc spUpdateCategory 
  @CategoryID INT ,
  @Category VARCHAR(45) = NULL
as
update Category
set Category  = @Category
where CategoryID = @CategoryID;
GO


-- -----------------------------------------------------
-- proc spInsertmydb.tblTagCategory
-- -----------------------------------------------------
CREATE  proc spUpdateTagCategory 
  @TagID INT,
  @CategoryID INT
  as
update TagCategory
set  CategoryID = @CategoryID
where TagID = @TagID;
GO


-- -----------------------------------------------------
-- proc spUpdatemydb.tblFriendList
-- -----------------------------------------------------
CREATE  proc spUpdateFriendList 
  @FriendID INT ,
  @UserID INT,
  @Created DATETIME,
  @UserIDRequested INT
as
update FriendList
set UserID = @UserID, 
Created = @Created,
UserIDRequested = @UserIDRequested
where FriendID = @FriendID;
GO
-- -----------------------------------------------------
-- proc spUpdatemydb.tblTagVisited
-- -----------------------------------------------------
CREATE  proc spUpdateTagVisited 
  @VisitID INT ,
  @UserID INT,
  @TagID INT,
  @VisitTime DATETIME = NULL
as
update TagVisited
set UserID = @UserID,
 TagID = @TagID,
 VisitTime = @VisitTime
where VisitID = @VisitID;

GO

-- -----------------------------------------------------
-- proc spUpdatemydb.tblInvites
-- -----------------------------------------------------
CREATE  proc spUpdateInvites 
  @InviteID INT ,
  @UserID INT,
  @UserIDSentTo INT,
  @Accepted bit,  
  @Rejected bit,
  @Created DATETIME = NULL
as
update Invites
set UserID = @UserID,
 UserIDSentTo = @UserIDSentTo,
 Accepted = @Accepted,
 Rejected = @Rejected,
 Created = @Created
where InviteID = @InviteID;
go