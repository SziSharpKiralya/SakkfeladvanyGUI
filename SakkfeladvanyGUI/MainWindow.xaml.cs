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
			int rows = (int)cb_col.SelectedItem;
			int columns = (int)cb_row.SelectedItem;
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

			lbl_info.Content = $"Checked: {checkedCount} / {columns}";
		}

		private void DeleteAllCells()
		{
			for (int i = 0; i < grid_tabla.Children.Count; i++)
			{
				if (grid_tabla.Children[i] is TextBox)
				{
					grid_tabla.Children.Remove(grid_tabla.Children[i] as TextBox);
				}
			}
		}

		private void CreateCells()
		{
			int rowCount = (int)cb_row.SelectedItem;
			int colCount = (int)cb_col.SelectedItem;
			for (int r = 0; r < rowCount; r++)
			{
				for (int c = 0; c < colCount; c++)
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
		}
	}
}