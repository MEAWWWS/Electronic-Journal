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
	/// Логика взаимодействия для AddTeacherWin.xaml
	/// </summary>
	public partial class AddTeacherWin : Window
	{
		ElectJournalEntities journalEntities = new ElectJournalEntities();
		public AddTeacherWin()
		{
			InitializeComponent();
			dataGrid.ItemsSource = journalEntities.Teacher.ToList();
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
					idRole = 2
				};
				journalEntities.User.Add(user);
				journalEntities.SaveChanges();
				var id = journalEntities.User.Where(m => m.login == loginTxt.Text && m.pass == passTxt.Text).Single();
				var idc = journalEntities.Discipline.Where(k => k.nameDiscipline == DiscTxt.Text).Single();
				Teacher teacher = new Teacher()
				{
					nameTeacher = nameTxt.Text,
					srnameTeacher = surnameTxt.Text,
					middleNameTeacher = middleName.Text,
					idUser = id.idUser,
					idDiscipline = idc.idDiscipline,
				};
				journalEntities.Teacher.Add(teacher);
				journalEntities.SaveChanges();
			}
			catch
			{
				MessageBox.Show("Не все данные были введены корректно");
			}
			dataGrid.ItemsSource = journalEntities.Teacher.ToList();
		}

		private void EditBt_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var x = dataGrid.SelectedItem as Teacher;
				var id = journalEntities.User.Where(m => m.login == loginTxt.Text && m.pass == passTxt.Text).Single();
				var idc = journalEntities.Discipline.Where(k => k.nameDiscipline == DiscTxt.Text).Single();
				x.nameTeacher = nameTxt.Text;
				x.srnameTeacher = surnameTxt.Text;
				x.middleNameTeacher = middleName.Text;
				x.idUser = id.idUser;
				x.idDiscipline = idc.idDiscipline;
				journalEntities.SaveChanges();
			}
			catch
			{
				MessageBox.Show("Не все данные были введены корректно");
			}
			dataGrid.ItemsSource = journalEntities.Teacher.ToList();
		}

		private void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
		{
			try
			{
				var x = dataGrid.SelectedItem as Teacher;
				nameTxt.Text = x.nameTeacher;
				surnameTxt.Text = x.srnameTeacher;
				middleName.Text = x.middleNameTeacher;
				DiscTxt.Text = x.Discipline.nameDiscipline;
				loginTxt.Text = x.User.login;
				passTxt.Text = x.User.pass;
			}
			catch
			{ }
		}
	}
}
