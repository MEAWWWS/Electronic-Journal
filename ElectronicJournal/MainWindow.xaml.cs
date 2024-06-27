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
using ElectronicJournal.DB;
using ElectronicJournal.Views;

namespace ElectronicJournal
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ElectJournalEntities electronicJournal = new ElectJournalEntities();
		public MainWindow()
		{
			InitializeComponent();
		}
		private void EnterBt_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var id = electronicJournal.User.Where(m=>m.login == loginTxt.Text && m.pass == passwordTxt.Password).Single();
				if (id.idRole == 1)
				{
					AdminWin adminWin = new AdminWin();
					Close();
					adminWin.Show();
				}
				else if(id.idRole == 2)
				{
					var idt = electronicJournal.Teacher.Where(m => m.idUser == id.idUser).Single();
					TeacherWin teacherWin = new TeacherWin(idt.idTeacher, idt.idDiscipline);
					Close();
					teacherWin.Show();
				}
				else if (id.idRole == 3)
				{
					var ids = electronicJournal.Student.Where(m => m.idUser == id.idUser).Single();
					StudentWin studentWin = new StudentWin(ids.idStudent);
					Close();
					studentWin.Show();
				}
			}
			catch
			{
				MessageBox.Show("Не правильный логин или пароль");
			}
		}
	}
}
