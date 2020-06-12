using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Database
    {
        public static Database db = new Database();
        #region Fields and Properties
        public List<Question> Questions;
        private List<Question> questions;
        public List<Answers> Answer;
        #endregion
        #region Constructor
        public Database()
        {
            Questions = new List<Question>();
            Answer = new List<Answers>();
            LoadDB();
            questions = new List<Question>();
        }
        #endregion
        #region Methods
        /// <summary>
        /// Add new question to database
        /// </summary>
        /// <param name="content"></param>
        /// <param name="correct"></param>
        /// <param name="answers"></param>
        public void AddNewQuestion(string content,int correct,string[] answers)
        {
            Question question = new Question { Content = content, CorrectAnswer = correct, Answer1 = answers[0], Answer2 = answers[1], Answer3 = answers[2] };
            AddQuestionToList(Questions, question);
            SaveToXml();
        }
        /// <summary>
        /// Adding question to list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="question"></param>
        public void AddQuestionToList(List<Question> list,Question question)
        {
            if(String.IsNullOrWhiteSpace(question.Content) || String.IsNullOrWhiteSpace(question.Answer1) || String.IsNullOrWhiteSpace(question.Answer2)
                || String.IsNullOrWhiteSpace(question.Answer3) || !(question.CorrectAnswer >= 0 && question.CorrectAnswer <= 2))
            {
                throw new ArgumentException();
            }
            else
            {
                list.Add(question);
            }
            
        }
        /// <summary>
        /// Sum correct answers after quiz
        /// </summary>
        /// <returns>Int</returns>
        public int CheckAnswers(List<Answers> answers,List<Question> questions)
        {
            int count = 0;
            foreach(Answers ans in answers)
            {
                if (ans.QuestionsAnswered == (from x in questions where x.Id == ans.AnswerID select x).First().CorrectAnswer) count++;
            }

            return count;
        }
        /// <summary>
        /// Get 10 random question from database
        /// </summary>
        /// <returns></returns>
        public List<Question> GetQuestions()
        {
            GetCopyOfDB(Questions,questions);
            List<Question> temp = questions;
            temp = Random(temp);
            List<Question> ReturnList = new List<Question>();
            Random rnd = new Random();
            int counter = 0;
            while(counter<temp.Count && counter < 10)
            {
                int index = rnd.Next(0, temp.Count);
                ReturnList.Add(temp[index]);
                temp.RemoveAt(index);
                counter++;
            }

            return ReturnList;
        }
        /// <summary>
        /// Get questions
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        private static List<T> Random<T>(List<T> list)
        {
            List<T> List = new List<T>();
            Random rnd = new Random();
            while (list.Count > 0)
            {
                int index = rnd.Next(0, list.Count);
                List.Add(list[index]);
                list.RemoveAt(index);
            }
            return List;
        }
        /// <summary>
        /// Method loading database of questions
        /// </summary>
        private void LoadDB()
        {
            if (System.IO.File.Exists("QuestionDB.xml"))
            {
                LoadFromXml();
            }
            else
            {
                Questions = new List<Question>();
            }
        }
        /// <summary>
        /// Getting copy of main list Questions
        /// </summary>
        public void GetCopyOfDB(List<Question> listFrom,List<Question> listTo)
        {
            foreach (Question q in listFrom)
            {
                listTo.Add(q);
            }
        }
        #endregion
        #region Serialize
        /// <summary>
        /// Serialize questions
        /// </summary>
        private void SaveToXml()
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(List<Question>));

            FileStream file = System.IO.File.Create("QuestionDB.xml");
            writer.Serialize(file, Questions);
            file.Close();
        }
        /// <summary>
        /// Deserialize question
        /// </summary>
        public void LoadFromXml()
        {
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(List<Question>));
            System.IO.StreamReader file = new StreamReader("QuestionDB.xml");
            Questions = reader.Deserialize(file) as List<Question>;
            file.Close();
        }
        #endregion
    }
}
