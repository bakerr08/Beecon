create database BeeconDB;
go
use BeeconDB;
CREATE  TABLE tblUser (
  UserID INT NOT NULL ,
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
  PrivacyTypeID INT NOT NULL ,
  PrivacyDescription VARCHAR(45) NULL ,
  PRIMARY KEY (PrivacyTypeID) )



CREATE  TABLE tblTag (
  TagID INT NOT NULL ,
  TagLongitude VARCHAR(45) NULL ,
  TagLatitude VARCHAR(45) NULL ,
  TagDescription VARCHAR(45) NULL ,
  TagDateCreated DATETIME NULL ,
  TagExpired DATETIME NULL ,
  UserID INT NOT NULL ,
  TagContent_URL VARCHAR(45) NULL ,
  PrivacyTypeID INT NOT NULL ,
  PRIMARY KEY (TagID) ,
  INDEX fk_tblTag_tblUser1_idx (UserID ASC) ,
  INDEX fk_tblTag_tblTagPrivacyType1_idx (PrivacyTypeID ASC) ,
  CONSTRAINT fk_tblTag_tblUser1
    FOREIGN KEY (UserID )
    REFERENCES mydb.tblUser (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_tblTag_tblTagPrivacyType1
    FOREIGN KEY (PrivacyTypeID )
    REFERENCES mydb.tblTagPrivacyType (PrivacyTypeID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)


-- -----------------------------------------------------
-- Table mydb.tblTagRating
-- -----------------------------------------------------
CREATE  TABLE tblTagRating (
  RatingID INT NOT NULL ,
  Rate INT NULL ,
  TagID INT NOT NULL ,
  UserID INT NOT NULL ,
  PRIMARY KEY (RatingID) ,
  INDEX fk_tblTagRating_tblTag1_idx (TagID ASC) ,
  INDEX fk_tblTagRating_tblUser1_idx (UserID ASC) ,
  CONSTRAINT fk_tblTagRating_tblTag1
    FOREIGN KEY (TagID )
    REFERENCES mydb.tblTag (TagID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_tblTagRating_tblUser1
    FOREIGN KEY (UserID )
    REFERENCES mydb.tblUser (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)



-- -----------------------------------------------------
-- Table mydb.tblCategory
-- -----------------------------------------------------
CREATE  TABLE tblCategory (
  CategoryID INT NOT NULL ,
  Category VARCHAR(45) NULL ,
  PRIMARY KEY (CategoryID) )



-- -----------------------------------------------------
-- Table mydb.tblTagCategory
-- -----------------------------------------------------
CREATE  TABLE tblTagCategory (
  TagID INT NOT NULL ,
  CategoryID INT NOT NULL ,
  PRIMARY KEY (TagID, CategoryID) ,
  INDEX fk_TagCategory_tblCategory1_idx (CategoryID ASC) ,
  CONSTRAINT fk_TagCategory_tblTag
    FOREIGN KEY (TagID )
    REFERENCES mydb.tblTag (TagID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_TagCategory_tblCategory1
    FOREIGN KEY (CategoryID )
    REFERENCES mydb.tblCategory (CategoryID )
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
  INDEX fk_tblFriendList_tblUser2_idx (UserIDRequested ASC) ,
  PRIMARY KEY (FriendID) ,
  CONSTRAINT fk_tblFriendList_tblUser1
    FOREIGN KEY (UserID )
    REFERENCES mydb.tblUser (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_tblFriendList_tblUser2
    FOREIGN KEY (UserIDRequested )
    REFERENCES mydb.tblUser (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)



-- -----------------------------------------------------
-- Table mydb.tblTagVisited
-- -----------------------------------------------------
CREATE  TABLE tblTagVisited (
  VisitID INT NOT NULL ,
  UserID INT NOT NULL ,
  TagID INT NOT NULL ,
  VisitTime  NULL ,
  PRIMARY KEY (VisitID) ,
  INDEX fk_tblTagVisited_tblUser1_idx (UserID ASC) ,
  INDEX fk_tblTagVisited_tblTag1_idx (TagID ASC) ,
  CONSTRAINT fk_tblTagVisited_tblUser1
    FOREIGN KEY (UserID )
    REFERENCES mydb.tblUser (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_tblTagVisited_tblTag1
    FOREIGN KEY (TagID )
    REFERENCES mydb.tblTag (TagID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)



-- -----------------------------------------------------
-- Table mydb.tblInvites
-- -----------------------------------------------------
CREATE  TABLE tblInvites (
  InviteID INT NOT NULL ,
  UserID INT NOT NULL ,
  UserIDSentTo INT NOT NULL ,
  Accepted TINYINT(1)  NULL ,
  Rejected TINYINT(1)  NULL ,
  Created DATETIME NULL ,
  PRIMARY KEY (InviteID) ,
  INDEX fk_UserID (UserID ASC) ,
  INDEX tblUser_UserID_Sent_To (UserIDSentTo ASC) ,
  CONSTRAINT fk_UserID
    FOREIGN KEY (UserID )
    REFERENCES mydb.tblUser (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT tblUser_UserID_Sent_To
    FOREIGN KEY (UserIDSentTo )
    REFERENCES mydb.tblUser (UserID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)