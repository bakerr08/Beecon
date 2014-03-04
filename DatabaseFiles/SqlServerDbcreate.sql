if OBJECT_ID('BeeconDB') is not null
drop Database  BeeconDB;
go
create database BeeconDB;
go
use BeeconDB;
CREATE  TABLE tblUser (
  UserID INT NOT NULL IDENTITY,
  Email VARCHAR(45) NULL ,
  FirstName VARCHAR(45) NULL ,
  LastName VARCHAR(45) NULL ,
  ZipCode VARCHAR(45) NULL ,
  Dob VARCHAR(45) NULL ,
  PasswordHashed VARCHAR(45) NULL ,
  TagsFound INT NULL ,
  TagsPosted INT NULL ,
  Gender VARCHAR(10) NULL ,
  PRIMARY KEY (UserID) )
  
  CREATE  TABLE tblTagPrivacyType (
  PrivacyTypeID INT NOT NULL IDENTITY,
  PrivacyDescription VARCHAR(45) NULL ,
  PRIMARY KEY (PrivacyTypeID) )



CREATE  TABLE tblTag (
  TagID INT NOT NULL IDENTITY,
  TagLongitude VARCHAR(45) NULL ,
  TagLatitude VARCHAR(45) NULL ,
  TagDescription VARCHAR(45) NULL ,
  TagDateCreated DATETIME NULL ,
  TagExpired DATETIME NULL ,
  UserID INT NOT NULL ,
  TagContent_URL VARCHAR(45) NULL ,
  PrivacyTypeID INT NOT NULL ,
  PRIMARY KEY (TagID) ,
  CONSTRAINT fk_tblTag_tblUser1
    FOREIGN KEY (UserID )
    REFERENCES tblUser (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_tblTag_tblTagPrivacyType1
    FOREIGN KEY (PrivacyTypeID )
    REFERENCES tblTagPrivacyType (PrivacyTypeID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)


-- -----------------------------------------------------
-- Table mydb.tblTagRating
-- -----------------------------------------------------
CREATE  TABLE tblTagRating (
  RatingID INT NOT NULL IDENTITY,
  Rate INT NULL ,
  TagID INT NOT NULL ,
  UserID INT NOT NULL ,
  PRIMARY KEY (RatingID) ,
  CONSTRAINT fk_tblTagRating_tblTag1
    FOREIGN KEY (TagID )
    REFERENCES tblTag (TagID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_tblTagRating_tblUser1
    FOREIGN KEY (UserID )
    REFERENCES tblUser (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)



-- -----------------------------------------------------
-- Table mydb.tblCategory
-- -----------------------------------------------------
CREATE  TABLE tblCategory (
  CategoryID INT NOT NULL IDENTITY,
  Category VARCHAR(45) NULL ,
  PRIMARY KEY (CategoryID) )



-- -----------------------------------------------------
-- Table mydb.tblTagCategory
-- -----------------------------------------------------
CREATE  TABLE tblTagCategory (
  TagID INT NOT NULL ,
  CategoryID INT NOT NULL ,
  PRIMARY KEY (TagID, CategoryID) ,

  CONSTRAINT fk_TagCategory_tblTag
    FOREIGN KEY (TagID )
    REFERENCES tblTag (TagID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_TagCategory_tblCategory1
    FOREIGN KEY (CategoryID )
    REFERENCES tblCategory (CategoryID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)



-- -----------------------------------------------------
-- Table mydb.tblFriendList
-- -----------------------------------------------------
CREATE  TABLE tblFriendList (
  UserID INT NOT NULL ,
  Created DATETIME NOT NULL ,
  UserIDRequested INT NOT NULL ,
  FriendID INT NOT NULL ,
  PRIMARY KEY (FriendID) ,
  CONSTRAINT fk_tblFriendList_tblUser1
    FOREIGN KEY (UserID )
    REFERENCES tblUser (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_tblFriendList_tblUser2
    FOREIGN KEY (UserIDRequested )
    REFERENCES tblUser (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)



-- -----------------------------------------------------
-- Table mydb.tblTagVisited
-- -----------------------------------------------------
CREATE  TABLE tblTagVisited (
  VisitID INT NOT NULL IDENTITY,
  UserID INT NOT NULL ,
  TagID INT NOT NULL ,
  VisitTime DATETIME NULL ,
  PRIMARY KEY (VisitID) ,
  CONSTRAINT fk_tblTagVisited_tblUser1
    FOREIGN KEY (UserID )
    REFERENCES tblUser (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_tblTagVisited_tblTag1
    FOREIGN KEY (TagID )
    REFERENCES tblTag (TagID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)



-- -----------------------------------------------------
-- Table mydb.tblInvites
-- -----------------------------------------------------
CREATE  TABLE tblInvites (
  InviteID INT NOT NULL IDENTITY,
  UserID INT NOT NULL ,
  UserIDSentTo INT NOT NULL ,
  Accepted bit   NOT NULL ,
  Rejected bit   NOT NULL ,
  Created DATETIME NULL ,
  PRIMARY KEY (InviteID) ,

  CONSTRAINT fk_UserID
    FOREIGN KEY (UserID )
    REFERENCES tblUser (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT tblUser_UserID_Sent_To
    FOREIGN KEY (UserIDSentTo )
    REFERENCES tblUser (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)