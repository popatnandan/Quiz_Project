USE [QUIZDB]
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_User_UPDATE]    Script Date: 1/24/2025 12:56:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PR_MST_User_UPDATE]
    @UserID INT,
	@UserName NVARCHAR(100),
    @Password NVARCHAR(100),
    @Email NVARCHAR(100) ,
    @Mobile NVARCHAR(100)
AS
BEGIN
UPDATE [dbo].[MST_User]
SET
	UserName = @UserName,
	Password = @Password,
	Email = @Email,
	Mobile = @Mobile
WHERE UserID = @UserID
END;

Select UserID, Username from MST_User