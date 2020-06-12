using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz;
using Xunit;

namespace Quiz.Tests
{
    public class DatabaseTests
    {
        [Fact]
        public void AddQuestionToList_ShouldWork()
        {
            Question question = new Question { Content = "content", CorrectAnswer = 0, Answer1 = "A", Answer2 = "B", Answer3 = "C" };
            List<Question> questions = new List<Question>();

            Database.db.AddQuestionToList(questions, question);

            Assert.Contains<Question>(question, questions);
            Assert.True(questions.Count == 1);
        }

        [Fact]
        public void AddQuestionToList_ShouldFail()
        {
            Question question = new Question { Content = "content", CorrectAnswer = 0, Answer1 = "", Answer2 = "", Answer3 = "C" };
            List<Question> questions = new List<Question>();

            Assert.Throws<ArgumentException>(() => Database.db.AddQuestionToList(questions, question));
        }

        [Fact]
        public void GetCopyOfDB_Test()
        {
            List<Question> questions = new List<Question>();
            List<Question> CopiedQuestions = new List<Question>();

            Database.db.AddQuestionToList(questions, new Question { Content = "content", CorrectAnswer = 0, Answer1 = "A", Answer2 = "B", Answer3 = "C" });
            Database.db.AddQuestionToList(questions, new Question { Content = "content1", CorrectAnswer = 1, Answer1 = "A", Answer2 = "B", Answer3 = "C" });
            Database.db.AddQuestionToList(questions, new Question { Content = "content2", CorrectAnswer = 2, Answer1 = "A", Answer2 = "B", Answer3 = "C" });
            Database.db.AddQuestionToList(questions, new Question { Content = "content3", CorrectAnswer = 0, Answer1 = "A", Answer2 = "B", Answer3 = "C" });
            Database.db.AddQuestionToList(questions, new Question { Content = "content4", CorrectAnswer = 1, Answer1 = "A", Answer2 = "B", Answer3 = "C" });

            Database.db.GetCopyOfDB(questions, CopiedQuestions);

            Assert.Equal(questions, CopiedQuestions);
        }

        [Fact]
        public void CheckAnswers_ShouldReturnCorrectValue()
        {
            List<Question> questions = new List<Question>();
            List<Answers> answers = new List<Answers>();

            Database.db.AddQuestionToList(questions, new Question { Content = "content", CorrectAnswer = 0, Answer1 = "A", Answer2 = "B", Answer3 = "C" });
            Database.db.AddQuestionToList(questions, new Question { Content = "content1", CorrectAnswer = 1, Answer1 = "A", Answer2 = "B", Answer3 = "C" });
            Database.db.AddQuestionToList(questions, new Question { Content = "content2", CorrectAnswer = 2, Answer1 = "A", Answer2 = "B", Answer3 = "C" });
            Database.db.AddQuestionToList(questions, new Question { Content = "content3", CorrectAnswer = 0, Answer1 = "A", Answer2 = "B", Answer3 = "C" });
            Database.db.AddQuestionToList(questions, new Question { Content = "content4", CorrectAnswer = 1, Answer1 = "A", Answer2 = "B", Answer3 = "C" });

            answers.Add(new Answers { AnswerID = questions[0].Id, QuestionsAnswered = 0 });
            answers.Add(new Answers { AnswerID = questions[1].Id, QuestionsAnswered = 1 });
            answers.Add(new Answers { AnswerID = questions[2].Id, QuestionsAnswered = 1 });
            answers.Add(new Answers { AnswerID = questions[3].Id, QuestionsAnswered = 0 });
            answers.Add(new Answers { AnswerID = questions[4].Id, QuestionsAnswered = 1 });

            Assert.Equal(4, Database.db.CheckAnswers(answers, questions));
        }
    }
}
