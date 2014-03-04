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
insert into tblUser
values (@Email, @FirstName, @LastName, @ZipCode, @Dob, @PasswordHashed, @TagsFound, @TagsPosted, @Gender);
return @@IDENTITY;