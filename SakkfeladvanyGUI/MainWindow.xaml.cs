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
			List<string> nums = new List<string> { "3", "4", "5", "6", "7", "8", "9", "10" };

			cb_row.ItemsSource = nums;
			cb_col.ItemsSource = nums;

			// 3. Kezdeti érték beállítása
			cb_row.SelectedItem = "8";
			cb_col.SelectedItem = "8";
		}

		private void background_drag(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
            Close();
		}

		private void btnCreate_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}