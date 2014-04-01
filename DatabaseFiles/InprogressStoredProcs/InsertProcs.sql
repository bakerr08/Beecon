create proc spInsertUser
  @Email VARCHAR(45) = NULL ,
  @FirstName VARCHAR(45) = NULL ,
  @LastName VARCHAR(45) = NULL ,
  @ZipCode VARCHAR(45) = NULL ,
  @Dob VARCHAR(45) = NULL ,
  @PasswordHashed VARCHAR(45) = NULL ,
  @TagsFound INT = NULL ,
  @TagsPosted INT = NULL ,
  @Gender VARCHAR(10) = NULL
as
insert into Users
values (@Email, @FirstName, @LastName, @ZipCode, @Dob, @PasswordHashed, @TagsFound, @TagsPosted, @Gender);
return @@IDENTITY;

CREATE  proc spInsertTag (

  @TagLongitude VARCHAR(45) = NULL ,
  @TagLatitude VARCHAR(45) = NULL ,
  @TagDescription VARCHAR(45) = NULL ,
  @TagDateCreated DATETIME = NULL ,
  @TagExpired DATETIME = NULL ,
  @UserID INT NOT = NULL ,
  @TagContent_URL VARCHAR(70) = NULL ,
  @PrivacyTypeID INT NOT = NULL ,
 as
insert into Tag
values (@TagLongitude, @TagLatitude, @TagDescription, @TagDateCreated, @TagExpired, @UserID, @TagContent_URL, @PrivacyTypeID);
return @@IDENTITY; 
  
  
  CREATE  proc spInsertTagRating (
  @Rate INT = NULL ,
  @TagID INT NOT = NULL ,
  @UserID INT NOT = NULL ,
  as
insert into TagRating
values (@Rate, @TagID, @UserID);
return @@IDENTITY; 



-- -----------------------------------------------------
-- proc spInsertmydb.tblCategory
-- -----------------------------------------------------
CREATE  proc spInsertCategory (
  @Category VARCHAR(45) = NULL ,
as
insert into Category
values (@Category);
return @@IDENTITY; 



-- -----------------------------------------------------
-- proc spInsertmydb.tblTagCategory
-- -----------------------------------------------------
CREATE  proc spInsertTagCategory (
  @TagID INT NOT = NULL ,
  @CategoryID INT NOT = NULL ,
  as
insert into TagCategory
values (@TagID, @CategoryID);
return @@IDENTITY; 



-- -----------------------------------------------------
-- proc spInsertmydb.tblFriendList
-- -----------------------------------------------------
CREATE  proc spInsertFriendList (
  @UserID INT NOT = NULL ,
  @Created DATETIME NOT = NULL ,
  @UserIDRequested INT NOT = NULL ,
as
insert into FriendList
values (@UserID, @Created, @UserIDRequested, @FriendID);
return @@IDENTITY; 
-- -----------------------------------------------------
-- proc spInsertmydb.tblTagVisited
-- -----------------------------------------------------
CREATE  proc spInsertTagVisited (
  @UserID INT NOT = NULL ,
  @TagID INT NOT = NULL ,
  @VisitTime DATETIME = NULL ,
as
insert into TagVisited
values (@UserID, @TagID, @VisitTime);
return @@IDENTITY; 



-- -----------------------------------------------------
-- proc spInsertmydb.tblInvites
-- -----------------------------------------------------
CREATE  proc spInsertInvites (
  @UserID INT NOT = NULL ,
  @UserIDSentTo INT NOT = NULL ,
  @Accepted bit   NOT = NULL ,
  @Rejected bit   NOT = NULL ,
  @Created DATETIME = NULL ,
as
insert into Invites
values (@UserID, @UserIDSentTo, @Accepted, @Rejected, @Created);
return @@IDENTITY; 