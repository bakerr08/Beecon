
create proc spGetTagByID
 @UserID INT NOT = NULL ,
 
as
select * 
from Tag;
where  UserID = @UserID

go
create proc spGetUsersByID
@UserID INT NOT = NULL ,
as
select * 
from Users;
where  UserID = @UserID
go
create proc spGetTagRatingByID
@RatingID INT NOT = NULL ,
as
select * 
from TagRating;
where  RatingID = @RatingID

go
create proc spGetCategoryByID
@CategoryID INT NOT = NULL ,
as
select * 
from Category;
where  CategoryID = @CategoryID

go
create proc spGetCategoryByTagID
@TagID INT NOT = NULL ,
as
select * 
from Category c
join TagCategory tc on
c.CategoryID = tc.CategoryID
where  tc.TagID = @TagID

go
create proc spGetTagCategoryByTagID
@TagID INT NOT = NULL ,
as
select * 
from TagCategory;
where  TagID = @TagID

go
create proc spGetFriendListByID
@FriendID INT NOT = NULL ,
as
select * 
from FriendList;
where  FriendID = @FriendID

go
create proc spGetFriendListByUserID
@UserID INT NOT = NULL ,
as
select * 
from FriendList;
where  UserID = @UserID

go
create proc spGetTagVisitedByUserID
@UserID INT NOT = NULL ,
as
select * 
from TagVisited;
where  UserID = @UserID

go
create proc spGetTagVisitedByVisitID
@VisitID INT NOT = NULL ,
as
select * 
from TagVisited;
where  VisitID = @VisitID

go
create proc spGetInvitesByInviteID
@InviteID INT NOT = NULL ,
as
select * 
from Invites;
where  InviteID = @InviteID

go
create proc spGetInvitesByUserID
@UserID INT NOT = NULL ,
as
select * 
from Invites;
where  UserID = @UserID

go


