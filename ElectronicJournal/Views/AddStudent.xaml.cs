using ElectronicJournal.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
	/// Логика взаимодействия для AddStudent.xaml
	/// </summary>
	public partial class AddStudent : Window
	{
		ElectJournalEntities journalEntities = new ElectJournalEntities();
		public AddStudent()
		{
			InitializeComponent();
			dataGrid.ItemsSource = journalEntities.Student.ToList();
			dataGrid.IsReadOnly = true;
		}

		private void AddBt_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				User user = new User()
				{
					login = loginTxt.Text,
					pass = passTxt.Text,
					idRole = 3
				};
				journalEntities.User.Add(user);
				journalEntities.SaveChanges();
				var id = journalEntities.User.Where(m => m.login == loginTxt.Text && m.pass == passTxt.Text).Single();
				var idc = journalEntities.Class.Where(k => k.nameClass == klsTxt.Text).Single();
				Student student = new Student()
				{
					nameStudent = nameTxt.Text,
					surnameStudent = surnameTxt.Text,
					middleNameStudent = middleName.Text,
					idUser = id.idUser,
					idClass = idc.idClass,
				};
				journalEntities.Student.Add(student);
				journalEntities.SaveChanges();
			}
			catch
			{
				MessageBox.Show("Не все данные были введены корректно");
			}
			dataGrid.ItemsSource = journalEntities.Student.ToList();
		}

		private void EditBt_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var x = dataGrid.SelectedItem as Student;
				var id = journalEntities.User.Where(m => m.login == loginTxt.Text && m.pass == passTxt.Text).Single();
				var idc = journalEntities.Class.Where(k => k.nameClass == klsTxt.Text).Single();
				x.nameStudent = nameTxt.Text;
				x.surnameStudent = surnameTxt.Text;
				x.middleNameStudent = middleName.Text;
				x.idUser = id.idUser;
				x.idClass = idc.idClass;
				journalEntities.SaveChanges();
			}
			catch
			{
				MessageBox.Show("Не все данные были введены корректно");
			}
			dataGrid.ItemsSource = journalEntities.Student.ToList();
		}

		private void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
		{
			try
			{
				var x = dataGrid.SelectedItem as Student;
				nameTxt.Text = x.nameStudent;
				surnameTxt.Text = x.surnameStudent;
				middleName.Text = x.middleNameStudent;
				klsTxt.Text = x.Class.nameClass;
				loginTxt.Text = x.User.login;
				passTxt.Text = x.User.pass;
			}
			catch
			{}
		}

		private void dataGrid_SelectedCellsChanged_1(object sender, SelectedCellsChangedEventArgs e)
		{

		}
	}
}
