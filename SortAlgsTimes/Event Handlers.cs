using System;
using System.Windows;
using System.Windows.Controls;

namespace SortAlgsTimes
{
	public partial class MainWindow
	{
		private void createArrayButton_Click(object sender, RoutedEventArgs e)
		{
			if (validateInput(arraySizeTextBox.Text))
			{
				clearUserData();
				hideArrayContent();
				disableControls();
				arrayContentTextBlock.Text = "[EMPTY]";
				sortedArrayContentTextBlock.Text = "[EMPTY]";
				_arraySize = Convert.ToUInt32(arraySizeTextBox.Text);
				if (arrayTypesComboBox.SelectedIndex == 4)
				{
					_minStringLength = (short)(stringLengthBoundComboBox1.SelectedIndex + 1);
					_maxStringLength = (short)(stringLengthBoundComboBox2.SelectedIndex + 1);
					if (_minStringLength > _maxStringLength)
					{
						swap(ref _minStringLength, ref _maxStringLength);
					}
				}

				switch (arrayTypesComboBox.SelectedIndex)
				{
					case 0:
						createByteArray();
						break;
					case 1:
						createInt16Array();
						break;
					case 2:
						createInt32Array();
						break;
					case 3:
						createInt64Array();
						break;
					case 4:
						createStringArray();
						break;
					default:
						break;
				}
				enableControls();
			}
		}

		private void arrayTypesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			clearUserData();
			arraySizeTextBox.Text = "";
			stringSpecs.Visibility = Visibility.Hidden;

			switch (arrayTypesComboBox.SelectedIndex)
			{
				case 0:
					arraySizeTextBox.MaxLength = 9;
					break;
				case 1:
					arraySizeTextBox.MaxLength = 8;
					break;
				case 2:
					arraySizeTextBox.MaxLength = 8;
					break;
				case 3:
					arraySizeTextBox.MaxLength = 7;
					break;
				case 4:
					stringSpecs.Visibility = Visibility.Visible;
					arraySizeTextBox.MaxLength = 6;
					break;
				default:
					break;
			}
		}

		private void arraySizeTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (validateInput(arraySizeTextBox.Text))
			{
				invalidSizeTextBlock.Visibility = Visibility.Hidden;
				if (arraySizeTextBox.Text != "")
				{
					createArrayButton.IsEnabled = true;
				}
				else
				{
					createArrayButton.IsEnabled = false;
				}
			}
			else
			{
				invalidSizeTextBlock.Visibility = Visibility.Visible;
				createArrayButton.IsEnabled = false;
			}
		}

		private void showArrayCheckBox_Checked(object sender, RoutedEventArgs e)
		{
			if (arrayContentTextBlock.Text == "[EMPTY]")
			{
				if (_arraySize <= 20000)
				{
					copyArrayItemsToDisplay(ref arrayContentTextBlock);
				}
				else
				{
					arrayContentTextBlock.Text = "Dispalying this much data can consume much time.\nDo you wish to continue?";
					proceedDisplayingArrayButton.IsEnabled = true;
					proceedDisplayingArrayButton.Visibility = Visibility.Visible;
				}
			}
			arrayContentScrollViewer.Visibility = Visibility.Visible;
			topGrid.Height += 90;
		}

		private void showArrayCheckBox_Unchecked(object sender, RoutedEventArgs e)
		{
			arrayContentScrollViewer.Visibility = Visibility.Hidden;
			topGrid.Height -= 90;
		}

		private void showSortedArrayCheckBox_Checked(object sender, RoutedEventArgs e)
		{
			if (sortedArrayContentTextBlock.Text == "[EMPTY]")
			{
				if (_arraySize <= 20000)
				{
					copySortedArrayItemsToDisplay(ref sortedArrayContentTextBlock);
				}
				else
				{
					sortedArrayContentTextBlock.Text = "Dispalying this much data can consume much time.\nDo you wish to continue?";
					proceedDisplayingSortedArrayButton.IsEnabled = true;
					proceedDisplayingSortedArrayButton.Visibility = Visibility.Visible;
				}
			}
			sortedArrayContentScrollViewer.Visibility = Visibility.Visible;
		}

		private void showSortedArrayCheckBox_Unchecked(object sender, RoutedEventArgs e)
		{
			sortedArrayContentScrollViewer.Visibility = Visibility.Hidden;
		}

		private void proceedDisplayingArray_Click(object sender, RoutedEventArgs e)
		{
			proceedDisplayingArrayButton.IsEnabled = false;
			proceedDisplayingArrayButton.Visibility = Visibility.Hidden;
			copyArrayItemsToDisplay(ref arrayContentTextBlock);
		}

		private void proceedDisplayingSortedArray_Click(object sender, RoutedEventArgs e)
		{
			proceedDisplayingSortedArrayButton.IsEnabled = false;
			proceedDisplayingSortedArrayButton.Visibility = Visibility.Hidden;
			copySortedArrayItemsToDisplay(ref sortedArrayContentTextBlock);
		}
	}
}