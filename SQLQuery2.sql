select Question.QuestionText,Answer.AnswerText, Interview.UserName
FROM Question INNER JOIN 
Interview_Question_Answer ON Question.QuestionId = Interview_Question_Answer.QuestionId
INNER JOIN Answer ON Interview_Question_Answer.AnswerId = Answer.AnswerId
INNER JOIN Interview ON Interview.InterviewId = Interview_Question_Answer.InterviewId
WHERE Interview.InterviewId = 1