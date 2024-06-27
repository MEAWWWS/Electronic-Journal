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
	/// Логика взаимодействия для AddDiscipline.xaml
	/// </summary>
	public partial class AddDiscipline : Window
	{
		ElectJournalEntities journalEntities = new ElectJournalEntities();
		public AddDiscipline()
		{
			InitializeComponent();
			dataGrid.ItemsSource = journalEntities.Discipline.ToList();
		}

		private void EditBt_Click(object sender, RoutedEventArgs e)
		{
			var x = dataGrid.SelectedItem as Discipline;
			x.nameDiscipline = discTxt.Text;
			journalEntities.SaveChanges();
			dataGrid.ItemsSource = journalEntities.Discipline.ToList();

		}

		private void AddBt_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Discipline discipline = new Discipline()
				{
					nameDiscipline = discTxt.Text
				};
				journalEntities.Discipline.Add(discipline);
				journalEntities.SaveChanges();
			}
			catch
			{
				MessageBox.Show("Не все данные были введены корректно");
			}
			dataGrid.ItemsSource = journalEntities.Discipline.ToList();

		}

		private void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
		{
			try
			{
				var x = dataGrid.SelectedItem as Discipline;
				discTxt.Text = x.nameDiscipline;
			}
			catch
			{ }
		}
	}
}
