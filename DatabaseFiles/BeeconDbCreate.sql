if db_id('BeeconDB') is not null
   drop Database  BeeconDB;
go
create database BeeconDB;
go
use BeeconDB;

if not exists(select * from sys.database_principals where name = 'db_user')
BEGIN
	CREATE LOGIN db_user WITH PASSWORD = 'test!234'

	IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'db_user')
	BEGIN
		CREATE USER [db_user] FOR LOGIN [db_user]
		EXEC sp_addrolemember N'db_owner', N'db_user'
	END;
END;
GO
CREATE  TABLE Users (
  UserID INT NOT NULL IDENTITY,
  Email VARCHAR(45) NULL ,
  FirstName VARCHAR(45) NULL ,
  LastName VARCHAR(45) NULL ,
  ZipCode VARCHAR(45) NULL ,
  Dob DATETIME NULL ,
  PasswordHashed VARCHAR(45) NULL ,
  TagsFound INT NULL ,
  TagsPosted INT NULL ,
  Gender VARCHAR(10) NULL ,
  PRIMARY KEY (UserID) )
  
  CREATE  TABLE TagPrivacyType (
  PrivacyTypeID INT NOT NULL IDENTITY,
  PrivacyDescription VARCHAR(45) NULL ,
  PRIMARY KEY (PrivacyTypeID) )



CREATE  TABLE Tag (
  TagID INT NOT NULL IDENTITY,
  TagLongitude VARCHAR(45) NULL ,
  TagLatitude VARCHAR(45) NULL ,
  TagDescription VARCHAR(45) NULL ,
  TagDateCreated DATETIME NULL ,
  TagExpired DATETIME NULL ,
  UserID INT NOT NULL ,
  TagContent_URL VARCHAR(70) NULL ,
  PrivacyTypeID INT NOT NULL ,
  PRIMARY KEY (TagID) ,
  CONSTRAINT fk_Tag_Users
    FOREIGN KEY (UserID )
    REFERENCES Users (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_Tag_TagPrivacyType1
    FOREIGN KEY (PrivacyTypeID )
    REFERENCES TagPrivacyType (PrivacyTypeID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)


-- -----------------------------------------------------
-- Table mydb.tblTagRating
-- -----------------------------------------------------
CREATE  TABLE TagRating (
  RatingID INT NOT NULL IDENTITY,
  Rate INT NULL ,
  TagID INT NOT NULL ,
  UserID INT NOT NULL ,
  PRIMARY KEY (RatingID) ,
  CONSTRAINT fk_TagRating_Tag1
    FOREIGN KEY (TagID )
    REFERENCES Tag (TagID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_TagRating_Users
    FOREIGN KEY (UserID )
    REFERENCES Users (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)



-- -----------------------------------------------------
-- Table mydb.tblCategory
-- -----------------------------------------------------
CREATE  TABLE Category (
  CategoryID INT NOT NULL IDENTITY,
  Category VARCHAR(45) NULL ,
  PRIMARY KEY (CategoryID) )



-- -----------------------------------------------------
-- Table mydb.tblTagCategory
-- -----------------------------------------------------
CREATE  TABLE TagCategory (
  TagID INT NOT NULL ,
  CategoryID INT NOT NULL ,
  PRIMARY KEY (TagID, CategoryID) ,

  CONSTRAINT fk_TagCategory_Tag
    FOREIGN KEY (TagID )
    REFERENCES Tag (TagID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_TagCategory_Category1
    FOREIGN KEY (CategoryID )
    REFERENCES Category (CategoryID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)



-- -----------------------------------------------------
-- Table mydb.tblFriendList
-- -----------------------------------------------------
CREATE  TABLE FriendList (
  FriendID INT NOT NULL IDENTITY,
  UserID INT NOT NULL ,
  Created DATETIME NOT NULL ,
  UserIDRequested INT NOT NULL ,
  
  PRIMARY KEY (FriendID) ,
  CONSTRAINT fk_FriendList_Users
    FOREIGN KEY (UserID )
    REFERENCES Users (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_FriendList_User2
    FOREIGN KEY (UserIDRequested )
    REFERENCES Users (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)



-- -----------------------------------------------------
-- Table mydb.tblTagVisited
-- -----------------------------------------------------
CREATE  TABLE TagVisited (
  VisitID INT NOT NULL IDENTITY,
  UserID INT NOT NULL ,
  TagID INT NOT NULL ,
  VisitTime DATETIME NULL ,
  PRIMARY KEY (VisitID) ,
  CONSTRAINT fk_TagVisited_Users
    FOREIGN KEY (UserID )
    REFERENCES Users (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_TagVisited_Tag1
    FOREIGN KEY (TagID )
    REFERENCES Tag (TagID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)



-- -----------------------------------------------------
-- Table mydb.tblInvites
-- -----------------------------------------------------
CREATE  TABLE Invites (
  InviteID INT NOT NULL IDENTITY,
  UserID INT NOT NULL ,
  UserIDSentTo INT NOT NULL ,
  Accepted bit   NOT NULL ,
  Rejected bit   NOT NULL ,
  Created DATETIME NULL ,
  PRIMARY KEY (InviteID) ,

  CONSTRAINT fk_UserID
    FOREIGN KEY (UserID )
    REFERENCES Users (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT User_UserID_Sent_To
    FOREIGN KEY (UserIDSentTo )
    REFERENCES Users (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
go
USE [BeeconDB]
GO
create proc spGetAllTag
as
select * 
from Tag;
GO
create proc spGetAllTagPrivacyType
as
select * 
from TagPrivacyType;
go
create proc spGetAllUsers
as
select * 
from Users;
go
create proc spGetAllTagRating
as
select * 
from TagRating;
go
create proc spGetAllCategory
as
select * 
from Category;
go
create proc spGetAllTagCategory
as
select * 
from TagCategory;
go
create proc spGetAllFriendList
as
select * 
from FriendList;
go
create proc spGetAllTagVisited
as
select * 
from TagVisited;
go
create proc spGetAllInvites
as
select * 
from Invites;
go
use BeeconDB
GO
create proc spGetTagByID
 @TagID INT
as
select * 
from Tag
where  TagID = @TagID;

go
create proc spGetTagPrivacyTypeByID
 @PrivacyTypeID INT
as
select * 
from Tag
where  PrivacyTypeID = @PrivacyTypeID;

go
create proc spGetUsersByID
@UserID INT
as
select * 
from Users
where  UserID = @UserID;
go
create proc spGetTagRatingByID
@RatingID INT
as
select * 
from TagRating
where  RatingID = @RatingID;

go
create proc spGetCategoryByID
@CategoryID INT
as
select * 
from Category
where  CategoryID = @CategoryID;

go
create proc spGetCategoryByTagID
@TagID INT
as
select * 
from Category c
join TagCategory tc on
c.CategoryID = tc.CategoryID
where  tc.TagID = @TagID;

go
create proc spGetTagCategoryByTagID
@TagID INT
as
select * 
from TagCategory
where  TagID = @TagID;

go
create proc spGetFriendListByID
@FriendID INT
as
select * 
from FriendList
where  FriendID = @FriendID;

go
create proc spGetFriendListByUserID
@UserID INT
as
select * 
from FriendList
where  UserID = @UserID;

go
create proc spGetTagVisitedByUserID
@UserID INT
as
select * 
from TagVisited
where  UserID = @UserID;

go
create proc spGetTagVisitedByVisitID
@VisitID INT
as
select * 
from TagVisited
where  VisitID = @VisitID;

go
create proc spGetInvitesByInviteID
@InviteID INT
as
select * 
from Invites
where  InviteID = @InviteID;

go
create proc spGetInvitesByUserID
@UserID INT
as
select * 
from Invites
where  UserID = @UserID;

go

use BeeconDB;
GO
create proc spInsertUser
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
insert into Users
values (@Email, @FirstName, @LastName, @ZipCode, @Dob, @PasswordHashed, @TagsFound, @TagsPosted, @Gender);
return @@IDENTITY;
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
  
  CREATE  proc spInsertTagPrivacyType
  @PrivacyDescription VARCHAR(45) = NULL,
  
  as
insert into TagPrivacyType
values (@PrivacyDescription);
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
use BeeconDB;
GO
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
use BeeconDB;
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