------------------------------------------ MST_User TABLE ------------------------------------------
-------------- USER TABLE INSERT --------------
CREATE PROCEDURE PR_MST_User_INSERT
    @UserName NVARCHAR(100),
    @Password NVARCHAR(100),
    @Email NVARCHAR(100) ,
    @Mobile NVARCHAR(100)
AS
BEGIN
INSERT INTO [dbo].[MST_User](UserName, Password, Email, Mobile,Modified)
			VALUES ( @UserName, @Password, @Email, @Mobile,GETDATE());
END;
GO

EXEC PR_MST_User_INSERT 'Nandan', 'Popat', 'HELLO@GMAIL.COM',7048470585
SELECT * FROM [dbo].[MST_User]

-------------- MST_User TABLE UPDATE --------------
CREATE PROCEDURE PR_MST_User_UPDATE
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
GO
EXEC PR_MST_User_UPDATE 3 ,'Nandan', 'Popat', 'nandan@GMAIL.COM',7048470585
SELECT * FROM [dbo].[MST_User]

-------------- MST_User TABLE DELETE --------------
CREATE PROCEDURE PR_MST_User_DELETE
	@UserID INT
AS
BEGIN
DELETE [dbo].[MST_User]
WHERE UserID = @UserID
END;
GO

EXEC PR_MST_User_DELETE 3
SELECT * FROM [dbo].[MST_User]

-------------- MST_User TABLE SelectAll --------------
CREATE PROCEDURE PR_MST_User_SelectAll
AS
BEGIN
SELECT * FROM [dbo].[MST_User]
END;
GO

EXEC PR_MST_User_SelectAll
SELECT * FROM [dbo].[MST_User]

-------------- MST_User TABLE SelectByID --------------
CREATE PROCEDURE PR_MST_User_SelectByID
	@UserID INT
AS
BEGIN
SELECT * FROM [dbo].[MST_User]
WHERE UserID = @UserID
END;
GO

EXEC PR_MST_User_SelectByID 5
SELECT * FROM [dbo].[MST_User]

-------------- MST_User TABLE SelectUsernameANDPassword --------------

CREATE PROCEDURE PR_MST_User_SelectUsernameANDPassword
	@UserName NVARCHAR(100),
	@Password NVARCHAR(100)
AS
BEGIN
SELECT * FROM [dbo].[MST_User]
WHERE	(UserName = @UserName OR Email = @UserName OR Mobile = @UserName)
		AND Password = @Password
END;
GO

EXEC PR_MST_User_SelectUsernameANDPassword '7048470585', 'Popat'
SELECT * FROM [dbo].[MST_User]


-- this is for filling all quizes
CREATE PROCEDURE DROPDOEN
AS
BEGIN
	select quizid,quizname,
	from mstquiz
	order by quizname
END;
