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
    /// Interaction logic for DatabaseWindow.xaml
    /// </summary>
    public partial class DatabaseWindow : Window
    {
        #region Constructor
        public DatabaseWindow()
        {
            InitializeComponent();
            this.CloseBtn.Click += (s, e) => this.Close();
            this.Exit.Click += (s, e) => this.Close();
        }
        #endregion

        #region Events
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            int correctAnswer = (A.IsChecked) == true ? 0 : (B.IsChecked) == true ? 1 : 2;

            if(QuestionContentText.Text!=String.Empty && AnswerA.Text != String.Empty && AnswerB.Text != String.Empty && AnswerC.Text != String.Empty)
            {
                Database.db.AddNewQuestion(QuestionContentText.Text, correctAnswer, new string[] { AnswerA.Text, AnswerB.Text, AnswerC.Text });
                MessageBox.Show("Question added!");
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
            
        }

        private void CheckUniqueAnswer(object sender,RoutedEventArgs e)
        {
            IEnumerable<TextBox> TextBoxList = MainGrid.Children.OfType<TextBox>();
            foreach(Control box in TextBoxList)
            {
                if(box != (sender as TextBox) && box != QuestionContentText)
                {
                    if((sender as TextBox).Text == ((TextBox)box).Text && (sender as TextBox).Text != String.Empty)
                    {
                        (sender as TextBox).Text = String.Empty;
                        MessageBox.Show("You already typed same answer!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;
                    }
                }
            }
        }
        #endregion
    }
}
