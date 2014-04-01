create proc spGetAllTag
as
select * 
from Tag;
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