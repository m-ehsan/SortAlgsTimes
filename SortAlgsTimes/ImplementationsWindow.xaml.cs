using System.Windows;
using System.Windows.Controls;

namespace SortAlgsTimes
{
	/// <summary>
	/// Interaction logic for Implementations.xaml
	/// </summary>
	public partial class ImplementationsWindow : Window
	{
		public ImplementationsWindow(SortAlgsEnum alg)
		{
			InitializeComponent();
			sortAlgsComboBox.SelectedIndex = (int)alg;
		}

		private void sortAlgsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			foreach (TextBlock item in sortImplementationsStackPanel.Children)
			{
				item.Visibility = Visibility.Collapsed;
			}
			sortImplementationsStackPanel.Children[sortAlgsComboBox.SelectedIndex].Visibility = Visibility.Visible;
		}
	}
}
