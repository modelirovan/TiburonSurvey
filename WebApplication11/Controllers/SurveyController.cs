using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication.DAL.Repositories;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IInterviewRepository _interviewRepository;


        public SurveyController(IQuestionRepository questionRepository,
            IAnswerRepository answerRepository,
            IInterviewRepository interviewRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _interviewRepository = interviewRepository;
        }

        [HttpPost("write-answer")]
        public WriteAnswerToQuestionResponse WriteAnswerToQuestion([FromBody]WriteAnswerToQuestionRequest request)
        {
            var nextQuestionResponse = new WriteAnswerToQuestionResponse();

            var interview = _interviewRepository.GetInterviewByIdAsync(request.CurrentIterviewId).Result;

            if (interview == null)
            {
                interview = _interviewRepository.CreateInterviewAsync(request.CurrentSurveyId, request.CurrentSurveyId, request.CurrentQuestionId, request.CurrentAnswerId).Result;
            }
            else
            {
                interview = _interviewRepository.UpdateInterviewAsync(request.CurrentIterviewId, request.CurrentSurveyId, request.CurrentQuestionId, request.CurrentAnswerId).Result;
            }

            var questionsAndAnswersWithIndex = GetQuestionsAndAnswersModels(request.CurrentSurveyId);
            var currentQuestionAndAnswer = questionsAndAnswersWithIndex.Where(x => x.QuestionId == request.CurrentQuestionId).FirstOrDefault();
            var nextQuestinoNumber = ++currentQuestionAndAnswer.QuestionNumber;
            var nextQuestionAndAnswers = questionsAndAnswersWithIndex.Where(x => x.QuestionNumber == nextQuestinoNumber).FirstOrDefault();

            if (nextQuestionAndAnswers != null)
            {
                nextQuestionResponse.NextQuestionId = nextQuestionAndAnswers.QuestionId;
                nextQuestionResponse.InterviewId = interview.InterviewId;
                nextQuestionResponse.NextQuestionNumber = nextQuestinoNumber;
                nextQuestionResponse.SurveyId = request.CurrentSurveyId;
            }

            return nextQuestionResponse;

        }

        [HttpPost("get-questions-and-answers")]
        public GetQuestionsAndAnswersResponse GetQuestionsAndAnswers([FromBody]GetQuestionsAndAnswersRequest request)
        {
            var response = new GetQuestionsAndAnswersResponse();

            if (request == null)
            {
                return response;
            }

            var questionsAndAnswersWithIndex = GetQuestionsAndAnswersModels(request.SurveyId);

            var question = questionsAndAnswersWithIndex.Where(x => x.QuestionNumber == request.QuestionNumber).FirstOrDefault();

            return new GetQuestionsAndAnswersResponse
            {
                QuestionId = question.QuestionId,
                QuestionNumber = question.QuestionNumber,
                QuestionText = question.QuestionText
                //QuestionsAndAnswers = questionsAndAnswersWithIndex
            };
        }

        private List<QuestionsAndAnswersModel> GetQuestionsAndAnswersModels(int surveyId)
        {
            var questionsAndAnswersWithIndex = new List<QuestionsAndAnswersModel>();

            var questions = _questionRepository.GetAllQuestionBySurveyIdAsync(surveyId).Result.ToList();

            if (questions.Count == 0)
            {
                return questionsAndAnswersWithIndex;
            }

            var questionIds = questions.Select(x => x.QuestionId).ToList();

            var answers = _answerRepository.GetAnswersByQuestionIdsAsync(questionIds).Result.ToList();

            if (answers.Count == 0)
            {
                return questionsAndAnswersWithIndex;
            }

            var questionsAndAnswers = (from a in answers
                                       join b in questions on a.QuestionId equals b.QuestionId
                                       group a by new { b.QuestionId, b.QuestionText } into grouped
                                       select new QuestionsAndAnswersModel
                                       {
                                           QuestionId = grouped.Key.QuestionId,
                                           QuestionText = grouped.Key.QuestionText,
                                           Answers = (from c in grouped
                                                      select new AnswerModel
                                                      {
                                                          AnswerId = c.AnswerId,
                                                          AnswerText = c.AnswerText,
                                                          QuestionId = c.QuestionId
                                                      }).ToList()
                                       }).ToList();

            questionsAndAnswersWithIndex = questionsAndAnswers.Select((o, i) => { o.QuestionNumber = i; return o; }).ToList();

            return questionsAndAnswersWithIndex;
        }



        // GET: api/Survey/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Survey
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Survey/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
