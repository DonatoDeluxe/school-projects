CREATE PROCEDURE dbo.pc_checkBadgeAccess(@BadgeId INT, @ObjektId INT, @PINCode VARCHAR(6), @Result BIT OUTPUT, @SysMessage VARCHAR(100) OUTPUT)
AS
	BEGIN TRANSACTION;
	SAVE TRANSACTION savePoint;
	BEGIN TRY
		SET @Result = 0;
		SET @SysMessage = 'Zugriff erfolgreich';
		IF exists (SELECT * FROM Badge WHERE BadgeId = @BadgeId)
			IF exists (SELECT * FROM Badge WHERE BadgeId = @BadgeId and GueltigBis >= GETDATE())
				IF exists (SELECT * FROM Badge WHERE BadgeId = @BadgeId and ErrorCounter < 3)
					IF exists (SELECT * FROM Badge b inner join Badgetypen bt ON b.BadgetypId = bt.BadgetypId WHERE BadgeId = @BadgeId and bt.Title = 'Admin')
					or exists (SELECT * FROM Badge_Tuerschliesssysteme WHERE BadgeId = @BadgeId and ObjektId = @ObjektId)
						IF exists (SELECT * FROM Badge WHERE BadgeId = @BadgeId and PINCode = @PINCode)
							BEGIN
								SET @Result = 1;
								UPDATE Badge SET ErrorCounter = 0 WHERE BadgeId = @BadgeId;
								UPDATE Tuerschliesssysteme SET StatusId = (SELECT StatusId FROM Statustypen WHERE Title = 'frei') WHERE ObjektId = @ObjektId;
							END
						ELSE
							BEGIN
								SET @SysMessage = 'Falscher PIN-Code';
								UPDATE Badge SET ErrorCounter = ErrorCounter+1 WHERE BadgeId = @BadgeId;
							END
					ELSE
						BEGIN
							SET @SysMessage = 'Badge nicht zugewiesen';
						END
				ELSE
					BEGIN
						SET @SysMessage = 'Badge gesperrt';
					END
			ELSE
				BEGIN
					SET @SysMessage = 'Badge abgelaufen';
				END
		ELSE
			BEGIN
				SET @SysMessage = 'ungültige BadgeID!';
			END
		
		DECLARE @accessMessage VARCHAR(20);
		SET @accessMessage = 'Access denied';
		IF @Result = 1
			SET @accessMessage = 'Access granted';
		ELSE
			
		INSERT INTO Logtabelle (BadgeId, ObjektId, Title, Erfolgsstatus) VALUES (@BadgeId, @ObjektId, @SysMessage, @accessMessage);

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION savePoint;
		END
	END CATCH
GO

CREATE PROCEDURE dbo.closeDoor(@ObjektId INT)
AS
	UPDATE Tuerschliesssysteme SET StatusId = (SELECT StatusId FROM Statustypen WHERE Title = 'gesperrt') WHERE ObjektId = @ObjektId;
GO

CREATE PROCEDURE dbo.openDoor(@ObjektId INT)
AS
	UPDATE Tuerschliesssysteme SET StatusId = (SELECT StatusId FROM Statustypen WHERE Title = 'frei') WHERE ObjektId = @ObjektId;
GO

CREATE PROCEDURE dbo.createBadge(@BadgetypId INT, @Vorname VARCHAR(20), @Nachname VARCHAR(20), @GueltigBis DATE, @PINCode VARCHAR(6), @BadgeId INT OUTPUT)
AS
	INSERT INTO Badge (BadgetypId, Vorname, Nachname, GueltigBis, ErrorCounter, PINCode)
	VALUES	(@BadgetypId, @Vorname, @Nachname, @GueltigBis, 0, @PINCode);

	SET @BadgeId = SCOPE_IDENTITY();
GO

CREATE PROCEDURE dbo.createBadgeDoorRelations(@BadgeId INT, @IDsString VARCHAR(MAX), @ErrorCode INT OUTPUT)
AS
	SET @ErrorCode = 0;
	IF exists (SELECT * FROM Badge WHERE BadgeId = @BadgeId)
	BEGIN
		DECLARE @ObjectId INT;
		DECLARE @getObjectId CURSOR;
		SET @getObjectId = CURSOR FOR SELECT CONVERT(INT, value) FROM STRING_SPLIT ( @IDsString , ',' );

		OPEN @getObjectId
		FETCH NEXT FROM @getObjectId INTO @ObjectId
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF exists (SELECT * FROM Tuerschliesssysteme WHERE ObjektId = @ObjectId)
				INSERT INTO Badge_Tuerschliesssysteme (BadgeId, ObjektId)
					VALUES (@BadgeId, @ObjectId);
			FETCH NEXT FROM @getObjectId INTO @ObjectId
		END

		CLOSE @getObjectId
		DEALLOCATE @getObjectId
	END
	ELSE
		SET @ErrorCode = 1;
GO