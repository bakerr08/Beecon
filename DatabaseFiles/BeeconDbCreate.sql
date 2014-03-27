if db_id('BeeconDB') is not null
   drop Database  BeeconDB;
go
create database BeeconDB;
go
use BeeconDB;
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
  UserID INT NOT NULL ,
  Created DATETIME NOT NULL ,
  UserIDRequested INT NOT NULL ,
  FriendID INT NOT NULL ,
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
