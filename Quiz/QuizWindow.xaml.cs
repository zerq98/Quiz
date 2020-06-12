using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Quiz
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        #region Variables
        List<Question> questions;
        int counter;
        #endregion
        #region Constructor
        public QuizWindow(List<Question> questions)
        {
            InitializeComponent();

            this.CloseBtn.Click += (s, e) => this.Close();

            counter = 0;
            this.questions = questions;
            SetNextQuestion();
            Backward.IsEnabled = false;
        }
        #endregion
        #region Events
        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            if (A.IsChecked == true || B.IsChecked == true || C.IsChecked == true)
            {
                if (Database.db.Answer.Count>counter)
                {
                    Database.db.Answer[counter].QuestionsAnswered = A.IsChecked == true ? 0 : B.IsChecked == true ? 1 : 2;
                }
                else
                {
                    Database.db.Answer.Add(new Answers { AnswerID = questions[counter].Id, QuestionsAnswered = A.IsChecked == true ? 0 : B.IsChecked == true ? 1 : 2 });
                }
                if (counter < questions.Count - 1)
                {
                    counter++;
                    SetNextQuestion();
                    CheckNumber();
                }
                else
                {
                    MessageBox.Show("Score: " + Database.db.CheckAnswers(Database.db.Answer,Database.db.Questions) + "/10", "Your score!", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("You must answer the question!");
            }
            
        }

        private void Backward_Click(object sender, RoutedEventArgs e)
        {
            counter--;

            SetNextQuestion();

            switch (Database.db.Answer[counter].QuestionsAnswered)
            {
                case 0:
                    A.IsChecked = true;
                    break;
                case 1:
                    B.IsChecked = true;
                    break;
                case 2:
                    C.IsChecked = true;
                    break;
            }

            CheckNumber();
        }
        #endregion
        #region Methods
        /// <summary>
        /// Checking number of question (if 0 set backward button IsEnabled to false)
        /// </summary>
        private void CheckNumber()
        {
            if (counter == 0)
            {
                Backward.IsEnabled = false;
                
            }
            else
            {
                Backward.IsEnabled = true;
            }
        }
        /// <summary>
        /// Set next question content
        /// </summary>
        private void SetNextQuestion()
        {
            this.QuestionBox.Header = "Question " + (counter + 1);
            this.Content.Text = questions[counter].Content;
            this.AnswerA.Text = questions[counter].Answer1;
            this.AnswerB.Text = questions[counter].Answer2;
            this.AnswerC.Text = questions[counter].Answer3;
            A.IsChecked = false;
            B.IsChecked = false;
            C.IsChecked = false;
        }
        #endregion
    }
}
