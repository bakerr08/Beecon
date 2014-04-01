use BeeconDB;
GO
create proc spUPDATEUser
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
set Email = @Email, FirstName = @FirstName,  LastName = @LastName, ZipCode  = @ZipCode,
 Dob  = @Dob, PasswordHashed  = @PasswordHashed, TagsFound  = @TagsFound,
 TagsPosted  = @TagsPosted, Gender = @Gender
 where UserID = @UserID;
GO
use BeeconDB;
GO
CREATE  proc spInsertTag 

  @TagLongitude VARCHAR(45) = NULL,
  @TagLatitude VARCHAR(45) = NULL,
  @TagDescription VARCHAR(45) = NULL,
  @TagDateCreated DATETIME = NULL,
  @TagExpired DATETIME = NULL,
  @UserID INT,
  @TagContent_URL VARCHAR(70) = NULL,
  @PrivacyTypeID INT
  AS
insert into Tag
values (@TagLongitude, @TagLatitude, @TagDescription, @TagDateCreated, @TagExpired, @UserID, @TagContent_URL, @PrivacyTypeID);
return @@IDENTITY; 
  GO
  
  CREATE  proc spInsertTagRating 
  @Rate INT = NULL,
  @TagID INT,
  @UserID INT
  as
insert into TagRating
values (@Rate, @TagID, @UserID);
return @@IDENTITY; 

GO

-- -----------------------------------------------------
-- proc spInsertmydb.tblCategory
-- -----------------------------------------------------
CREATE  proc spInsertCategory 
  @Category VARCHAR(45) = NULL
as
insert into Category
values (@Category);
return @@IDENTITY; 
GO


-- -----------------------------------------------------
-- proc spInsertmydb.tblTagCategory
-- -----------------------------------------------------
CREATE  proc spInsertTagCategory 
  @TagID INT,
  @CategoryID INT
  as
insert into TagCategory
values (@TagID, @CategoryID);
return @@IDENTITY; 
GO


-- -----------------------------------------------------
-- proc spInsertmydb.tblFriendList
-- -----------------------------------------------------
CREATE  proc spInsertFriendList 
  @UserID INT,
  @Created DATETIME,
  @UserIDRequested INT
as
insert into FriendList
values (@UserID, @Created, @UserIDRequested);
return @@IDENTITY; 
GO
-- -----------------------------------------------------
-- proc spInsertmydb.tblTagVisited
-- -----------------------------------------------------
CREATE  proc spInsertTagVisited 
  @UserID INT,
  @TagID INT,
  @VisitTime DATETIME = NULL
as
insert into TagVisited
values (@UserID, @TagID, @VisitTime);
return @@IDENTITY; 

GO

-- -----------------------------------------------------
-- proc spInsertmydb.tblInvites
-- -----------------------------------------------------
CREATE  proc spInsertInvites 
  @UserID INT,
  @UserIDSentTo INT,
  @Accepted bit,  
  @Rejected bit,
  @Created DATETIME = NULL
as
insert into Invites
values (@UserID, @UserIDSentTo, @Accepted, @Rejected, @Created);
return @@IDENTITY; 