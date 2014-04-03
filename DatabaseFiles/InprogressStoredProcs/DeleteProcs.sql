use BeeconDB
go
create proc spDeleteInvitesByInviteID
@InviteID INT
as
delete from Invites
where  InviteID = @InviteID;
GO

create proc spDeleteTagByUserID
 @UserID INT
as
delete from Tag
where UserID = @UserID;

go
create proc spDeleteTagByID
 @TagID INT
as
delete from TagRating
where  TagID = @TagID;
delete from TagVisited
where  TagID = @TagID;
delete  from Tag
where  TagID = @TagID;
delete from TagCatagory
where  TagID = @TagID;
go
create proc spDeleteUsersByID
@UserID INT
as
delete from TagVisited
where  UserID = @UserID;
delete from FriendList
where  UserIDRequested = @UserID;
delete from FriendList
where  UserID = @UserID;
delete from Invites
where  UserIDSentTo = @UserID;
delete from Invites
where  UserID = @UserID;
delete from Users
where  UserID = @UserID;
go
create proc spDeleteTagRatingByID
@RatingID INT
as
delete from TagRating
where  RatingID = @RatingID;

go
create proc spDeleteCategoryByID
@CategoryID INT
as
delete from TagCategory
where  CategoryID = @CategoryID;
delete from Category
where  CategoryID = @CategoryID;

go
create proc spDeleteTagCategoryByTagID
@TagID INT
as
delete from TagCategory
where  TagID = @TagID;

go
create proc spDeleteFriendListByID
@FriendID INT
as
delete from FriendList
where  FriendID = @FriendID;

go
create proc spDeleteFriendListByUserID
@UserID INT
as
delete from FriendList
where  UserID = @UserID;

go
create proc spDeleteTagVisitedByUserID
@UserID INT
as
delete from TagVisited
where  UserID = @UserID;

go
create proc spDeleteTagVisitedByVisitID
@VisitID INT
as
delete from TagVisited
where  VisitID = @VisitID;
go

create proc spDeleteInvitesByUserID
@UserID INT
as
delete from Invites
where  UserID = @UserID;

go


