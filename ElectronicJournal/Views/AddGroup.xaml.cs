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
	/// Логика взаимодействия для AddGroup.xaml
	/// </summary>
	public partial class AddGroup : Window
	{
		ElectJournalEntities journalEntities = new ElectJournalEntities();
		public AddGroup()
		{
			InitializeComponent();
			dataGrid.ItemsSource = journalEntities.Class.ToList();
		}

		private void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
		{
			try
			{
				var x = dataGrid.SelectedItem as Class;
				discTxt.Text = x.nameClass;
			}
			catch
			{ }
		}

		private void AddBt_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Class class1 = new Class()
				{
					nameClass = discTxt.Text,
				};
				journalEntities.Class.Add(class1);
				journalEntities.SaveChanges();
			}
			catch
			{
				MessageBox.Show("Не все данные были введены корректно");
			}
			dataGrid.ItemsSource = journalEntities.Class.ToList();

		}
		private void EditBt_Click(object sender, RoutedEventArgs e)
		{
			var x = dataGrid.SelectedItem as Class;
			x.nameClass = discTxt.Text;
			journalEntities.SaveChanges();
			dataGrid.ItemsSource = journalEntities.Class.ToList();

		}
	}
}
