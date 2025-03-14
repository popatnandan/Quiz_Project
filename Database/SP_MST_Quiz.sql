------------------------------------------ MST_Quiz TABLE ------------------------------------------
-------------- USER QUIZ INSERT --------------
CREATE PROCEDURE PR_MST_Quiz_INSERT
    @QuizName NVARCHAR(100),
    @TotalQuestions INT,
	@QuizDate DATETIME,
    @UserID INT
AS
BEGIN
INSERT INTO [dbo].[MST_Quiz](QuizName, TotalQuestions, QuizDate, UserID,Modified)
			VALUES ( @QuizName, @TotalQuestions, @QuizDate , @UserID,GETDATE());
END;
GO

EXEC PR_MST_Quiz_INSERT 'DOTNET', 10,'2025-01-24', 4
SELECT * FROM [dbo].[MST_Quiz]

-------------- MST_Quiz TABLE UPDATE --------------
CREATE PROCEDURE PR_MST_Quiz_UPDATE
	@QuizID INT,
    @QuizName NVARCHAR(100),
    @TotalQuestions INT,
	@QuizDate DATETIME,
    @UserID INT
AS
BEGIN
UPDATE [dbo].[MST_Quiz]
SET
	QuizName = @QuizName,
	TotalQuestions = @TotalQuestions,
	QuizDate = @QuizDate,
	UserID = @UserID
WHERE QuizID = @QuizID
END;
GO
EXEC PR_MST_Quiz_UPDATE 2 ,'DBMS', 50, '2025-01-31',5
SELECT * FROM [dbo].[MST_Quiz]

-------------- MST_Quiz TABLE DELETE --------------
CREATE PROCEDURE PR_MST_Quiz_DELETE
	@QuizID INT
AS
BEGIN
DELETE [dbo].[MST_Quiz]
WHERE QuizID = @QuizID
END;
GO

EXEC PR_MST_Quiz_DELETE 2
SELECT * FROM [dbo].[MST_Quiz]

-------------- MST_Quiz TABLE SelectAll --------------
ALTER PROCEDURE [dbo].[PR_MST_Quiz_SelectAll]
AS
BEGIN
    SELECT 
        [dbo].[MST_Quiz].[QuizID],
        [dbo].[MST_Quiz].[QuizName],
        [dbo].[MST_Quiz].[TotalQuestions],
        [dbo].[MST_Quiz].[QuizDate],
        [dbo].[MST_Quiz].[Created],
        [dbo].[MST_Quiz].[Modified],
        [dbo].[MST_Quiz].[UserID], 
        [dbo].[MST_User].[UserName]
    FROM [dbo].[MST_Quiz]
    INNER JOIN [dbo].[MST_User]
        ON [dbo].[MST_User].[UserID] = [dbo].[MST_Quiz].[UserID]
END;

EXEC PR_MST_Quiz_SelectAll
SELECT * FROM [dbo].[MST_Quiz]

-------------- MST_Quiz TABLE SelectByID --------------
CREATE PROCEDURE PR_MST_Quiz_SelectByID
	@QuizID INT
AS
BEGIN
SELECT * FROM [dbo].[MST_Quiz]
WHERE QuizID = @QuizID
END;
GO

EXEC PR_MST_Quiz_SelectByID 1
SELECT * FROM [dbo].[MST_Quiz]