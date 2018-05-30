declare @res INT;
declare @message VARCHAR(100);
exec dbo.pc_checkBadgeAccess 5, 8, '123456', @Result = @res output, @SysMessage = @message output;
print @res;
print @message;
select * from Logtabelle;

exec dbo.closeDoor 1;
select * from Tuerschliesssysteme;

exec dbo.openDoor 1;
select * from Tuerschliesssysteme;

declare @badgeId int;
declare @errorCode int;
exec dbo.createBadge 1, 'abc', 'abc', '2018-12-10', 'sdfjhj', @BadgeId = @badgeId output;
exec dbo.createBadgeDoorRelations @badgeId, '1,2,3,5,6,7,9', @ErrorCode = @errorCode output;
print 'Badge ID: ' + Convert(varchar(max), @badgeId);
select * from Badge;
select * from Badge_Tuerschliesssysteme where BadgeId = @badgeId;