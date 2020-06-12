using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    [Serializable()]
    public class Question
    {
        #region Fields and Properties
        Guid id1 = Guid.NewGuid();
        public Guid Id
        {
            get { return id1; }
        }
        public string Content { get; set; }
        public int CorrectAnswer { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        #endregion
        #region Constructor

        /// <summary>
        /// Parameterless xml serializable parameter
        /// </summary>
        public Question()
        {

        }
        /// <summary>
        /// Constructor to create questions
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="Correct"></param>
        /// <param name="Answer1"></param>
        /// <param name="Answer2"></param>
        /// <param name="Answer3"></param>
        public Question(string Content,int Correct,string[] answers)
        {
            this.Content = Content;
            this.CorrectAnswer = Correct;
            this.Answer1 = answers[0];
            this.Answer2 = answers[1];
            this.Answer3 = answers[2];
        }
        #endregion
    }
}
