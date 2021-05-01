using Microsoft.Win32;
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
using Word = Microsoft.Office.Interop.Word;

namespace Lab7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Word.Application word = new Word.Application();

        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Нажатие кнопки создания файла по шаблону
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                // Открытие файла
                Word.Document Doc = word.Documents.Add(dialog.FileName);
                // Замена шаблона на свои данные
                Doc.Bookmarks["Kafedra"].Range.Text = KafedraTextBox.Text;
                Doc.Bookmarks["LabNumber"].Range.Text = LabNumberTextBox.Text;
                Doc.Bookmarks["LabTitle"].Range.Text = LabTitleTextBox.Text;
                Doc.Bookmarks["Subject"].Range.Text = SubjectTextBox.Text;
                Doc.Bookmarks["Students"].Range.Text = StudentsTextBox.Text;
                Doc.Bookmarks["Direction"].Range.Text = DirectionTextBox.Text;
                Doc.Bookmarks["Group"].Range.Text = GroupTextBox.Text;
                Doc.Bookmarks["Teacher"].Range.Text = TeacherTextBox.Text;
                Doc.Bookmarks["Year"].Range.Text = YearTextBox.Text;
                // Сохранение нового файла
                Doc.SaveAs2(FileName: Environment.CurrentDirectory + "\\Lab" + LabNumberTextBox.Text + "_" + GroupTextBox.Text + ".docx");
                Doc.Close();
            }
        }
    }
}
