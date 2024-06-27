using ElectronicJournal.DB;
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

namespace ElectronicJournal.Views
{
	/// <summary>
	/// Логика взаимодействия для AdminWin.xaml
	/// </summary>
	public partial class AdminWin : Window
	{
		ElectJournalEntities journalEntities = new ElectJournalEntities();
		public AdminWin()
		{
			InitializeComponent();
			dataGrid.ItemsSource = journalEntities.Schedule.ToList();
			
		}
		private void AddTeacherBt_Click(object sender, RoutedEventArgs e)
		{
			AddTeacherWin addTeacherWin = new AddTeacherWin();
			addTeacherWin.ShowDialog();
		}
		private void SheduleBt_Click(object sender, RoutedEventArgs e)
		{
			ScheduleWin scheduleWin = new ScheduleWin();
			scheduleWin.ShowDialog();
		}
		private void ListSheduleBt_Click(object sender, RoutedEventArgs e)
		{
			dataGrid.ItemsSource = journalEntities.Schedule.Where(m => m.Class.nameClass == klassTxt.Text).ToList();
		}
		private void AddStudentBt_Click(object sender, RoutedEventArgs e)
		{
			AddStudent addStudent = new AddStudent();
			addStudent.ShowDialog();
		}

		private void AddGroupBt_Click(object sender, RoutedEventArgs e)
		{
			AddGroup addGroup = new AddGroup();
			addGroup.ShowDialog();
		}

		private void AddDiscBt_Click(object sender, RoutedEventArgs e)
		{
			AddDiscipline addDiscipline = new AddDiscipline();
			addDiscipline.ShowDialog();
		}

		private void Back_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			Close();
			mainWindow.Show();
		}
	}
}
