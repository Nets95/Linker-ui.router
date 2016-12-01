
CREATE PROCEDURE [dbo].[spGetAll]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Link;
END
GO

CREATE PROCEDURE [dbo].[spInsert]
	@LinkTitle nvarchar(50),
	@CurrentDate nvarchar(25) 
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Link
	(LinkTitle, CurrentDate)
	VALUES
	(@LinkTitle, @CurrentDate)
END
GO


CREATE PROCEDURE [dbo].[spRemooveLink]
	@LinkTitle nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM Link
	WHERE LinkTitle = @LinkTitle;
END
GO


CREATE PROCEDURE [dbo].[spUpdateLink] 
	@LinkTitle nvarchar(50),
	@UpdatedLinkTitle nvarchar(50)
AS
BEGIN
	
	SET NOCOUNT ON;
	UPDATE Link
	SET LinkTitle = @UpdatedLinkTitle
	WHERE LinkTitle = @LinkTitle;
END
GO
