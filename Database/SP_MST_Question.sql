------------------------------------------ MST_Question TABLE ------------------------------------------
-------------- USER TABLE INSERT --------------
CREATE PROCEDURE PR_MST_Question_INSERT
    @QuestionText NVARCHAR(100),
    @QuestionLevelID INT,
    @OptionA NVARCHAR(100),
    @OptionB NVARCHAR(100),
	@OptionC NVARCHAR(100),
    @OptionD NVARCHAR(100),
	@CorrectOption NVARCHAR(100),
	@QuestionMarks INT,
	@UserID INT,
	@Modified DATETIME
AS
BEGIN
INSERT INTO [dbo].[MST_Question](QuestionText, QuestionLevelID, OptionA,OptionB,OptionC,
								 OptionD,CorrectOption,QuestionMarks,UserID,Modified)
			VALUES ( @QuestionText, @QuestionLevelID, @OptionA, @OptionB,@OptionC,
					 @OptionD,@CorrectOption,@QuestionMarks,@UserID,GETDATE());
END;
GO

EXEC PR_MST_Question_INSERT 'Nandan', 'Popat', 'HELLO@GMAIL.COM',7048470585
SELECT * FROM [dbo].[MST_Question]

-------------- MST_Question TABLE UPDATE --------------
CREATE PROCEDURE PR_MST_Question_UPDATE
	@QuestionID INT,
    @QuestionText NVARCHAR(100),
    @QuestionLevelID INT,
    @OptionA NVARCHAR(100),
    @OptionB NVARCHAR(100),
	@OptionC NVARCHAR(100),
    @OptionD NVARCHAR(100),
	@CorrectOption NVARCHAR(100),
	@QuestionMarks INT,
	@UserID INT,
	@Modified DATETIME
AS
BEGIN
UPDATE [dbo].[MST_Question]
SET
	QuestionText = @QuestionText,
	QuestionLevelID = @QuestionLevelID,
	OptionA = @OptionA,
	OptionB = @OptionB,
	OptionC = @OptionC,
	OptionD = @OptionD,
	CorrectOption = @CorrectOption,
	QuestionMarks = @QuestionMarks,
	UserID = @UserID,
	Modified = @Modified
WHERE QuestionID = @QuestionID
END;
GO
EXEC PR_MST_Question_UPDATE 3 ,'Nandan', 'Popat', 'nandan@GMAIL.COM',7048470585
SELECT * FROM [dbo].[MST_Question]

-------------- MST_Question TABLE DELETE --------------
CREATE PROCEDURE PR_MST_Question_DELETE
	@QuestionID INT
AS
BEGIN
DELETE [dbo].[MST_Question]
WHERE QuestionID = @QuestionID
END;
GO

EXEC PR_MST_Question_DELETE 3
SELECT * FROM [dbo].[MST_Question]

-------------- MST_Question TABLE SelectAll --------------
CREATE PROCEDURE PR_MST_Question_SelectAll
AS
BEGIN
SELECT * FROM [dbo].[MST_Question]
END;
GO

EXEC PR_MST_Question_SelectAll
SELECT * FROM [dbo].[MST_Question]

-------------- MST_Question TABLE SelectByID --------------
CREATE PROCEDURE PR_MST_Question_SelectByID
	@QuestionID INT
AS
BEGIN
SELECT * FROM [dbo].[MST_Question]
WHERE QuestionID = @QuestionID
END;
GO

EXEC PR_MST_Question_SelectByID 5
SELECT * FROM [dbo].[MST_Question]



