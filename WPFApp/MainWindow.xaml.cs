using System.Windows;
using System.Windows.Controls;

namespace WPFApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void ButtonHello_Click(object sender, RoutedEventArgs e)
		{
			string message = NameTextBox.Text;
			MessageBox.Show($"hello, {message}");
		}

		private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			NameOutputLabel.Content = $"{NameTextBox.Text} was entered in the same text box";
		}
	}
}
