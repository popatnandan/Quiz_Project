------------------------------------------ MST_QuestionLevel TABLE ------------------------------------------
-------------- MST_QuestionLevel TABLE INSERT --------------
CREATE PROCEDURE PR_MST_QuestionLevel_INSERT
    @QuizName NVARCHAR(100),
    @TotalQuestions INT,
	@QuizDate DATETIME,
    @UserID INT
AS
BEGIN
INSERT INTO [dbo].[MST_QuestionLevel](QuizName, TotalQuestions, QuizDate, UserID,Modified)
			VALUES ( @QuizName, @TotalQuestions, @QuizDate , @UserID,GETDATE());
END;
GO

EXEC PR_MST_QuestionLevel_INSERT 'DOTNET', 10,'2025-01-24', 3
SELECT * FROM [dbo].[MST_QuestionLevel]

-------------- MST_QuestionLevel TABLE UPDATE --------------
CREATE PROCEDURE PR_MST_QuestionLevel_UPDATE
	@QuizID INT,
    @QuizName NVARCHAR(100),
    @TotalQuestions INT,
	@QuizDate DATETIME,
    @UserID INT
AS
BEGIN
UPDATE [dbo].[MST_QuestionLevel]
SET
	QuizName = @QuizName,
	TotalQuestions = @TotalQuestions,
	QuizDate = @QuizDate,
	UserID = @UserID
WHERE QuizID = @QuizID
END;
GO
EXEC PR_MST_QuestionLevel_UPDATE 1 ,'DBMS', 50, '2025-01-31',4
SELECT * FROM [dbo].[MST_QuestionLevel]

-------------- MST_QuestionLevel TABLE DELETE --------------
CREATE PROCEDURE PR_MST_QuestionLevel_DELETE
	@QuizID INT
AS
BEGIN
DELETE [dbo].[MST_QuestionLevel]
WHERE QuizID = @QuizID
END;
GO

EXEC PR_MST_QuestionLevel_DELETE 1
SELECT * FROM [dbo].[MST_QuestionLevel]

-------------- MST_QuestionLevel TABLE SelectAll --------------
CREATE PROCEDURE PR_MST_QuestionLevel_SelectAll
AS
BEGIN
SELECT * FROM [dbo].[MST_QuestionLevel]
END;
GO

EXEC PR_MST_QuestionLevel_SelectAll
SELECT * FROM [dbo].[MST_QuestionLevel]

-------------- MST_QuestionLevel TABLE SelectByID --------------
CREATE PROCEDURE PR_MST_QuestionLevel_SelectByID
	@QuizID INT
AS
BEGIN
SELECT * FROM [dbo].[MST_QuestionLevel]
WHERE QuizID = @QuizID
END;
GO

EXEC PR_MST_QuestionLevel_SelectByID 1
SELECT * FROM [dbo].[MST_QuestionLevel]