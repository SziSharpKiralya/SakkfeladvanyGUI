using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SakkfeladvanyGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		int rows;
		int columns;

		public MainWindow()
        {
            InitializeComponent();
			List<int> nums = new List<int> { 3, 4, 5, 6, 7, 8, 9, 10 };

			cb_row.ItemsSource = nums;
			cb_col.ItemsSource = nums;

			cb_row.SelectedItem = 8;
			cb_col.SelectedItem = 8;
		}

		private void CheckCells()
		{
			int checkedCount = 0;
			int sz = 0;

			foreach (var item in grid_tabla.Children)
			{
				if (item is CheckBox)
				{
					CheckBox checkbox = (CheckBox)item;
					if (checkbox.IsChecked == true)
					{
						checkedCount++;
						sz++;
					}
				}
				if (sz == columns)
				{
					sz = 0;
				}
			}

			if (checkedCount == rows)
			{
				lbl_info.Content = "Feladvány megoldva!";
			}
			else
			{
				lbl_info.Content = "Minden sorban helyezzen el egy királynőt!";
			}
		}

		private void DeleteAllCells()
		{
			(grid_tabla.Children).Clear();
		}

		private void CreateCells()
		{
			rows = (int)cb_row.SelectedItem;
			columns = (int)cb_col.SelectedItem;
			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < columns; c++)
				{
					CheckBox checkbox = new CheckBox();
					Grid.SetRow(checkbox, r);
					Grid.SetColumn(checkbox, c);
					checkbox.IsChecked = false;
					checkbox.VerticalAlignment = VerticalAlignment.Center;
					checkbox.HorizontalAlignment = HorizontalAlignment.Center;
					checkbox.VerticalContentAlignment = VerticalAlignment.Center;
					checkbox.HorizontalContentAlignment = HorizontalAlignment.Center;
					grid_tabla.Children.Add(checkbox);
					checkbox.Checked += checkbox_Check;
					checkbox.Unchecked += checkbox_Check;
				}
			}
		}

		private void checkbox_Check(object sender, RoutedEventArgs e)
		{
			CheckCells();
		}

		private void background_Drag(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
            Close();
		}

		private void btnCreate_Click(object sender, RoutedEventArgs e)
		{
			DeleteAllCells();
			CreateCells();
			CheckCells();
		}
	}
}