using NUnit.Framework;
using Quiz;
using System.Collections.Generic;
using Xunit;

namespace QuizTest
{
    class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
            List<Question> insertList = new List<Question>();
            insertList.Add(new Question { Content = "Test1", Answer1 = "A", Answer2 = "B", Answer3 = "C", CorrectAnswer = 0 });
            insertList.Add(new Question { Content = "Test2", Answer1 = "A", Answer2 = "B", Answer3 = "C", CorrectAnswer = 1 });
            insertList.Add(new Question { Content = "Test3", Answer1 = "A", Answer2 = "B", Answer3 = "C", CorrectAnswer = 2 });
            insertList.Add(new Question { Content = "Test4", Answer1 = "A", Answer2 = "B", Answer3 = "C", CorrectAnswer = 0 });
            insertList.Add(new Question { Content = "Test5", Answer1 = "A", Answer2 = "B", Answer3 = "C", CorrectAnswer = 1 });
            insertList.Add(new Question { Content = "Test6", Answer1 = "A", Answer2 = "B", Answer3 = "C", CorrectAnswer = 2 });
            insertList.Add(new Question { Content = "Test7", Answer1 = "A", Answer2 = "B", Answer3 = "C", CorrectAnswer = 0 });
            insertList.Add(new Question { Content = "Test8", Answer1 = "A", Answer2 = "B", Answer3 = "C", CorrectAnswer = 1 });
            insertList.Add(new Question { Content = "Test9", Answer1 = "A", Answer2 = "B", Answer3 = "C", CorrectAnswer = 2 });
            insertList.Add(new Question { Content = "Test10", Answer1 = "A", Answer2 = "B", Answer3 = "C", CorrectAnswer = 0 });
            Quiz.Database.db.Questions = insertList;
        }

        [Test]
        public void CheckCountOfList()
        {
            Xunit.Assert.Equal(10, Quiz.Database.db.Questions.Count);

            Database.db.Questions.RemoveRange(5, 5);

            Xunit.Assert.Equal(5, Quiz.Database.db.Questions.Count);
        }

        [Test]
        public void CheckAdding()
        {
            Database.db.Questions = new List<Question>();
            Database.db.AddNewTestQuestion("Test1", 0, new string[] { "a", "b", "c" });
            Question question = new Question("Test1", 0, new string[] { "a", "b", "c" });
            Xunit.Assert.Equal(question.Content, Database.db.Questions[0].Content);
        }
    }
}
