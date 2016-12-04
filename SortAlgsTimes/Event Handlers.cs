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
					arraySizeTextBox.MaxLength = 8;
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
			topGrid.Height -= 90;
			arrayContentScrollViewer.Visibility = Visibility.Hidden;
			proceedDisplayingArrayButton.Visibility = Visibility.Hidden;
			arrayContentTextBlock.Text = "[EMPTY]";
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
			proceedDisplayingSortedArrayButton.Visibility = Visibility.Hidden;
			sortedArrayContentScrollViewer.Visibility = Visibility.Hidden;
			sortedArrayContentTextBlock.Text = "[EMPTY]";
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

		private void bubbleSortButton_Click(object sender, RoutedEventArgs e)
		{
			SortAlgs.comparisonCount = 0;
			if (_lastUsedSortOrder != (sortOrderComboBox.SelectedIndex == 0) ? true : false)
			{
				sortedArrayContentTextBlock.Text = "[EMPTY]";
				showSortedArrayCheckBox.IsChecked = false;
				showSortedArrayCheckBox.IsEnabled = false;
			}
			_lastUsedSortOrder = (sortOrderComboBox.SelectedIndex == 0) ? true : false;

			switch (arrayTypesComboBox.SelectedIndex)
			{
				case 0:
					_sortedByteArray = new byte[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedByteArray[i] = _byteArray[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.BubbleSort(_sortedByteArray, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				case 1:
					_sortedInt16Array = new short[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt16Array[i] = _Int16Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.BubbleSort(_sortedInt16Array, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				case 2:
					_sortedInt32Array = new int[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt32Array[i] = _Int32Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.BubbleSort(_sortedInt32Array, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				case 3:
					_sortedInt64Array = new long[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt64Array[i] = _Int64Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.BubbleSort(_sortedInt64Array, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				case 4:
					_sortedStringArray = new string[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedStringArray[i] = _stringArray[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.BubbleSort(_sortedStringArray, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				default:
					break;
			}
			bubbleSortTime.Text = timeSpanToText(watch.Elapsed) + "  |  " + SortAlgs.comparisonCount + " comparisons";
			enableShowSortedArrayCheckBox();
		}

		private void insertionSortButton_Click(object sender, RoutedEventArgs e)
		{
			SortAlgs.comparisonCount = 0;
			if (_lastUsedSortOrder != (sortOrderComboBox.SelectedIndex == 0) ? true : false)
			{
				sortedArrayContentTextBlock.Text = "[EMPTY]";
				showSortedArrayCheckBox.IsChecked = false;
				showSortedArrayCheckBox.IsEnabled = false;
			}
			_lastUsedSortOrder = (sortOrderComboBox.SelectedIndex == 0) ? true : false;

			switch (arrayTypesComboBox.SelectedIndex)
			{
				case 0:
					_sortedByteArray = new byte[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedByteArray[i] = _byteArray[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.InsertionSort(_sortedByteArray, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				case 1:
					_sortedInt16Array = new short[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt16Array[i] = _Int16Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.InsertionSort(_sortedInt16Array, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				case 2:
					_sortedInt32Array = new int[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt32Array[i] = _Int32Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.InsertionSort(_sortedInt32Array, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				case 3:
					_sortedInt64Array = new long[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt64Array[i] = _Int64Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.InsertionSort(_sortedInt64Array, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				case 4:
					_sortedStringArray = new string[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedStringArray[i] = _stringArray[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.InsertionSort(_sortedStringArray, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				default:
					break;
			}
			insertionSortTime.Text = timeSpanToText(watch.Elapsed) + "  |  " + SortAlgs.comparisonCount + " comparisons";
			enableShowSortedArrayCheckBox();
		}

		private void quickSortButton_Click(object sender, RoutedEventArgs e)
		{
			SortAlgs.comparisonCount = 0;
			if (_lastUsedSortOrder != (sortOrderComboBox.SelectedIndex == 0) ? true : false)
			{
				sortedArrayContentTextBlock.Text = "[EMPTY]";
				showSortedArrayCheckBox.IsChecked = false;
				showSortedArrayCheckBox.IsEnabled = false;
			}
			_lastUsedSortOrder = (sortOrderComboBox.SelectedIndex == 0) ? true : false;

			switch (arrayTypesComboBox.SelectedIndex)
			{
				case 0:
					_sortedByteArray = new byte[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedByteArray[i] = _byteArray[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.QuickSort(_sortedByteArray, 0, _sortedByteArray.Length - 1, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				case 1:
					_sortedInt16Array = new short[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt16Array[i] = _Int16Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.QuickSort(_sortedInt16Array, 0, _sortedInt16Array.Length - 1, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				case 2:
					_sortedInt32Array = new int[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt32Array[i] = _Int32Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.QuickSort(_sortedInt32Array, 0, _sortedInt32Array.Length - 1, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				case 3:
					_sortedInt64Array = new long[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt64Array[i] = _Int64Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.QuickSort(_sortedInt64Array, 0, _sortedInt64Array.Length - 1, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				case 4:
					_sortedStringArray = new string[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedStringArray[i] = _stringArray[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.QuickSort(_sortedStringArray, 0, _sortedStringArray.Length - 1, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				default:
					break;
			}
			quickSortTime.Text = timeSpanToText(watch.Elapsed) + "  |  " + SortAlgs.comparisonCount + " comparisons";
			enableShowSortedArrayCheckBox();
		}

		private void mergeSortButton_Click(object sender, RoutedEventArgs e)
		{
			SortAlgs.comparisonCount = 0;
			if (_lastUsedSortOrder != (sortOrderComboBox.SelectedIndex == 0) ? true : false)
			{
				sortedArrayContentTextBlock.Text = "[EMPTY]";
				showSortedArrayCheckBox.IsChecked = false;
				showSortedArrayCheckBox.IsEnabled = false;
			}
			_lastUsedSortOrder = (sortOrderComboBox.SelectedIndex == 0) ? true : false;

			switch (arrayTypesComboBox.SelectedIndex)
			{
				case 0:
					_sortedByteArray = new byte[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedByteArray[i] = _byteArray[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.MergeSort(_sortedByteArray, 0, _sortedByteArray.Length - 1, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				case 1:
					_sortedInt16Array = new short[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt16Array[i] = _Int16Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.MergeSort(_sortedInt16Array, 0, _sortedInt16Array.Length - 1, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				case 2:
					_sortedInt32Array = new int[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt32Array[i] = _Int32Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.MergeSort(_sortedInt32Array, 0, _sortedInt32Array.Length - 1, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				case 3:
					_sortedInt64Array = new long[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt64Array[i] = _Int64Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.MergeSort(_sortedInt64Array, 0, _sortedInt64Array.Length - 1, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				case 4:
					_sortedStringArray = new string[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedStringArray[i] = _stringArray[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.MergeSort(_sortedStringArray, 0, _sortedStringArray.Length - 1, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				default:
					break;
			}
			mergeSortTime.Text = timeSpanToText(watch.Elapsed) + "  |  " + SortAlgs.comparisonCount + " comparisons";
			enableShowSortedArrayCheckBox();
		}

		private void heapSortButton_Click(object sender, RoutedEventArgs e)
		{
			SortAlgs.comparisonCount = 0;
			if (_lastUsedSortOrder != (sortOrderComboBox.SelectedIndex == 0) ? true : false)
			{
				sortedArrayContentTextBlock.Text = "[EMPTY]";
				showSortedArrayCheckBox.IsChecked = false;
				showSortedArrayCheckBox.IsEnabled = false;
			}
			_lastUsedSortOrder = (sortOrderComboBox.SelectedIndex == 0) ? true : false;

			switch (arrayTypesComboBox.SelectedIndex)
			{
				case 0:
					_sortedByteArray = new byte[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedByteArray[i] = _byteArray[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.HeapSort(_sortedByteArray, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				case 1:
					_sortedInt16Array = new short[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt16Array[i] = _Int16Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.HeapSort(_sortedInt16Array, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				case 2:
					_sortedInt32Array = new int[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt32Array[i] = _Int32Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.HeapSort(_sortedInt32Array, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				case 3:
					_sortedInt64Array = new long[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt64Array[i] = _Int64Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.HeapSort(_sortedInt64Array, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				case 4:
					_sortedStringArray = new string[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedStringArray[i] = _stringArray[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.HeapSort(_sortedStringArray, (sortOrderComboBox.SelectedIndex == 0) ? true : false);
					watch.Stop();
					break;
				default:
					break;
			}
			heapSortTime.Text = timeSpanToText(watch.Elapsed) + "  |  " + SortAlgs.comparisonCount + " comparisons";
			enableShowSortedArrayCheckBox();
		}
	}
}