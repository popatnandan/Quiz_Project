------------------------------------------ MST_QuizWiseQuestions TABLE ------------------------------------------
-------------- MST_QuizWiseQuestions TABLE INSERT --------------
CREATE PROCEDURE PR_MST_QuizWiseQuestions_INSERT
    @QuizID INT	,
    @QuestionID INT,
	@UserID INT,
	@Modified DATETIME
AS
BEGIN
INSERT INTO [dbo].[MST_QuizWiseQuestions](QuizID, QuestionID, UserID, Modified)
			VALUES ( @QuizID, @QuestionID, @UserID,GETDATE());
END;
GO

EXEC PR_MST_QuizWiseQuestions_INSERT 'Nandan', 'Popat', 'HELLO@GMAIL.COM',7048470585
SELECT * FROM [dbo].[MST_QuizWiseQuestions]

-------------- MST_QuizWiseQuestions TABLE UPDATE --------------
CREATE PROCEDURE PR_MST_QuizWiseQuestions_UPDATE
	@QuizWiseQuestionsID INT,
	@QuizID INT	,
    @QuestionID INT,
	@UserID INT,
	@Modified DATETIME
AS
BEGIN
UPDATE [dbo].[MST_QuizWiseQuestions]
SET
	QuizID = @QuizID,
	QuestionID = @QuestionID,
	UserID = @UserID,
	Modified = @Modified
WHERE QuizWiseQuestionsID = QuizWiseQuestionsID
END;
GO
EXEC PR_MST_QuizWiseQuestions_UPDATE 3 ,'Nandan', 'Popat', 'nandan@GMAIL.COM',7048470585
SELECT * FROM [dbo].[MST_QuizWiseQuestions]

-------------- MST_QuizWiseQuestions TABLE DELETE --------------
CREATE PROCEDURE PR_MST_QuizWiseQuestions_DELETE
	@QuizWiseQuestionsID INT
AS
BEGIN
DELETE [dbo].[MST_QuizWiseQuestions]
WHERE QuizWiseQuestionsID = @QuizWiseQuestionsID
END;
GO

EXEC PR_MST_QuizWiseQuestions_DELETE 3
SELECT * FROM [dbo].[MST_QuizWiseQuestions]

-------------- MST_QuizWiseQuestions TABLE SelectAll --------------
CREATE PROCEDURE PR_MST_QuizWiseQuestions_SelectAll
AS
BEGIN
SELECT * FROM [dbo].[MST_QuizWiseQuestions]
END;
GO

EXEC PR_MST_QuizWiseQuestions_SelectAll
SELECT * FROM [dbo].[MST_QuizWiseQuestions]

-------------- MST_QuizWiseQuestions TABLE SelectByID --------------
CREATE PROCEDURE PR_MST_QuizWiseQuestions_SelectByID
	@QuestionID INT
AS
BEGIN
SELECT * FROM [dbo].[MST_QuizWiseQuestions]
WHERE QuestionID = @QuestionID
END;
GO

EXEC PR_MST_QuizWiseQuestions_SelectByID 5
SELECT * FROM [dbo].[MST_QuizWiseQuestions]



