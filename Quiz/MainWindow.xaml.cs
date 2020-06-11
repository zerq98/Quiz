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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            this.CloseBtn.Click += (s, e) => this.Close();
            this.Exit.Click += (s, e) => this.Close();
            this.MinimizeBtn.Click += (s, e) => this.WindowState = WindowState.Minimized;
        }
        #endregion
        #region Events
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            DatabaseWindow window = new DatabaseWindow();
            window.ShowDialog();
            
        }

        private void StartQuiz_Click(object sender, RoutedEventArgs e)
        {
            Database.db.Answer = new List<Answers>();
            List<Question> SelectedQuestions = Database.db.GetQuestions();
            QuizWindow window = new QuizWindow(SelectedQuestions);
            window.ShowDialog();
        }
        #endregion
    }
}
