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

-- -----------------------------------------------------
-- Table mydb.tblTagVisited
-- -----------------------------------------------------
CREATE  TABLE TagVisited (
  VisitID INT NOT NULL IDENTITY,
  UserID INT NOT NULL ,
  TagID INT NOT NULL ,
  VisitTime DATETIME NULL ,




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
