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
				_arraySize = uint.Parse(arraySizeTextBox.Text);
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
			stringSpecsGrid.Visibility = Visibility.Collapsed;

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
					stringSpecsGrid.Visibility = Visibility.Visible;
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
				invalidSizeTextBlock.Visibility = Visibility.Collapsed;
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
			arrayContentScrollViewer.Visibility = Visibility.Collapsed;
			proceedDisplayingArrayButton.Visibility = Visibility.Collapsed;
			arrayContentTextBlock.Text = "[EMPTY]";
		}

		private void showSortedArrayCheckBox_Checked(object sender, RoutedEventArgs e)
		{
			if (sortedArrayContentTextBlock.Text == "[EMPTY]")
			{
				UpdateSortedArrayTextBlock();
			}
			sortedArrayContentScrollViewer.Visibility = Visibility.Visible;
		}

		private void UpdateSortedArrayTextBlock()
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

		private void showSortedArrayCheckBox_Unchecked(object sender, RoutedEventArgs e)
		{
			proceedDisplayingSortedArrayButton.Visibility = Visibility.Collapsed;
			sortedArrayContentScrollViewer.Visibility = Visibility.Collapsed;
			sortedArrayContentTextBlock.Text = "[EMPTY]";
		}

		private void proceedDisplayingArray_Click(object sender, RoutedEventArgs e)
		{
			proceedDisplayingArrayButton.IsEnabled = false;
			proceedDisplayingArrayButton.Visibility = Visibility.Collapsed;
			copyArrayItemsToDisplay(ref arrayContentTextBlock);
		}

		private void proceedDisplayingSortedArray_Click(object sender, RoutedEventArgs e)
		{
			proceedDisplayingSortedArrayButton.IsEnabled = false;
			proceedDisplayingSortedArrayButton.Visibility = Visibility.Collapsed;
			copySortedArrayItemsToDisplay(ref sortedArrayContentTextBlock);
		}

		private void PerformSort()
		{
			switch (arrayTypesComboBox.SelectedIndex)
			{
				case 0:
					switch ((SortAlgsEnum)sortAlgComboBox.SelectedIndex)
					{
						case SortAlgsEnum.BUBBLE_SORT:
							SortAlgs.BubbleSort(_sortedByteArray, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.INSERTION_SORT:
							SortAlgs.InsertionSort(_sortedByteArray, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.QUICK_SORT:
							SortAlgs.QuickSort(_sortedByteArray, 0, _sortedByteArray.Length - 1, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.MERGE_SORT:
							SortAlgs.MergeSort(_sortedByteArray, 0, _sortedByteArray.Length - 1, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.HEAP_SORT:
							SortAlgs.HeapSort(_sortedByteArray, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.PIGEON_SORT:
							SortAlgs.PigeonholeSort(_sortedByteArray, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.COUNT_SORT:
							SortAlgs.CountingSort(_sortedByteArray, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.RADIX_SORT:
							SortAlgs.RadixSort(_sortedByteArray, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.SHELL_SORT:
							SortAlgs.ShellSort(_sortedByteArray, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.BINARY_INSERTION_SORT:
							SortAlgs.BinaryInsertionSort(_sortedByteArray, (sortOrderComboBox.SelectedIndex == 0));
							break;
						default:
							break;
					}
					break;
				case 1:
					switch ((SortAlgsEnum)sortAlgComboBox.SelectedIndex)
					{
						case SortAlgsEnum.BUBBLE_SORT:
							SortAlgs.BubbleSort(_sortedInt16Array, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.INSERTION_SORT:
							SortAlgs.InsertionSort(_sortedInt16Array, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.QUICK_SORT:
							SortAlgs.QuickSort(_sortedInt16Array, 0, _sortedInt16Array.Length - 1, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.MERGE_SORT:
							SortAlgs.MergeSort(_sortedInt16Array, 0, _sortedInt16Array.Length - 1, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.HEAP_SORT:
							SortAlgs.HeapSort(_sortedInt16Array, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.PIGEON_SORT:
							SortAlgs.PigeonholeSort(_sortedInt16Array, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.COUNT_SORT:
							SortAlgs.CountingSort(_sortedInt16Array, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.RADIX_SORT:
							SortAlgs.RadixSort(_sortedInt16Array, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.SHELL_SORT:
							SortAlgs.ShellSort(_sortedInt16Array, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.BINARY_INSERTION_SORT:
							SortAlgs.BinaryInsertionSort(_sortedInt16Array, (sortOrderComboBox.SelectedIndex == 0));
							break;
						default:
							break;
					}
					break;
				case 2:
					switch ((SortAlgsEnum)sortAlgComboBox.SelectedIndex)
					{
						case SortAlgsEnum.BUBBLE_SORT:
							SortAlgs.BubbleSort(_sortedInt32Array, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.INSERTION_SORT:
							SortAlgs.InsertionSort(_sortedInt32Array, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.QUICK_SORT:
							SortAlgs.QuickSort(_sortedInt32Array, 0, _sortedInt32Array.Length - 1, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.MERGE_SORT:
							SortAlgs.MergeSort(_sortedInt32Array, 0, _sortedInt32Array.Length - 1, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.HEAP_SORT:
							SortAlgs.HeapSort(_sortedInt32Array, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.PIGEON_SORT:
							sortResultTextBlock.Text = "This algorithm does not support whole range of Int32 numbers.";
							break;
						case SortAlgsEnum.COUNT_SORT:
							sortResultTextBlock.Text = "This algorithm does not support whole range of Int32 numbers.";
							error = true;
							break;
						case SortAlgsEnum.RADIX_SORT:
							SortAlgs.RadixSort(_sortedInt32Array, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.SHELL_SORT:
							SortAlgs.ShellSort(_sortedInt32Array, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.BINARY_INSERTION_SORT:
							SortAlgs.BinaryInsertionSort(_sortedInt32Array, (sortOrderComboBox.SelectedIndex == 0));
							break;
						default:
							break;
					}
					break;
				case 3:
					switch ((SortAlgsEnum)sortAlgComboBox.SelectedIndex)
					{
						case SortAlgsEnum.BUBBLE_SORT:
							SortAlgs.BubbleSort(_sortedInt64Array, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.INSERTION_SORT:
							SortAlgs.InsertionSort(_sortedInt64Array, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.QUICK_SORT:
							SortAlgs.QuickSort(_sortedInt64Array, 0, _sortedInt64Array.Length - 1, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.MERGE_SORT:
							SortAlgs.MergeSort(_sortedInt64Array, 0, _sortedInt64Array.Length - 1, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.HEAP_SORT:
							SortAlgs.HeapSort(_sortedInt64Array, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.PIGEON_SORT:
							sortResultTextBlock.Text = "This algorithm does not support whole range of Int64 numbers.";
							error = true;
							break;
						case SortAlgsEnum.COUNT_SORT:
							sortResultTextBlock.Text = "This algorithm does not support whole range of Int64 numbers.";
							error = true;
							break;
						case SortAlgsEnum.RADIX_SORT:
							SortAlgs.RadixSort(_sortedInt64Array, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.SHELL_SORT:
							SortAlgs.ShellSort(_sortedInt64Array, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.BINARY_INSERTION_SORT:
							SortAlgs.BinaryInsertionSort(_sortedInt64Array, (sortOrderComboBox.SelectedIndex == 0));
							break;
						default:
							break;
					}
					break;
				case 4:
					switch ((SortAlgsEnum)sortAlgComboBox.SelectedIndex)
					{
						case SortAlgsEnum.BUBBLE_SORT:
							SortAlgs.BubbleSort(_sortedStringArray, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.INSERTION_SORT:
							SortAlgs.InsertionSort(_sortedStringArray, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.QUICK_SORT:
							SortAlgs.QuickSort(_sortedStringArray, 0, _sortedStringArray.Length - 1, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.MERGE_SORT:
							SortAlgs.MergeSort(_sortedStringArray, 0, _sortedStringArray.Length - 1, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.HEAP_SORT:
							SortAlgs.HeapSort(_sortedStringArray, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.PIGEON_SORT:
							sortResultTextBlock.Text = "This algorithm is not suitable for strings.";
							error = true;
							break;
						case SortAlgsEnum.COUNT_SORT:
							sortResultTextBlock.Text = "This algorithm is not suitable for strings.";
							error = true;
							break;
						case SortAlgsEnum.RADIX_SORT:
							sortResultTextBlock.Text = "Type string is not supported for this algorithm yet...";
							error = true;
							break;
						case SortAlgsEnum.SHELL_SORT:
							SortAlgs.ShellSort(_sortedStringArray, (sortOrderComboBox.SelectedIndex == 0));
							break;
						case SortAlgsEnum.BINARY_INSERTION_SORT:
							SortAlgs.BinaryInsertionSort(_sortedStringArray, (sortOrderComboBox.SelectedIndex == 0));
							break;
						default:
							break;
					}
					break;
			}
		}

		private void sortButton_Click(object sender, RoutedEventArgs e)
		{
			SortAlgs.comparisonsCount = 0;
			error = false;

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
					PerformSort();
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
					PerformSort();
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
					PerformSort();
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
					PerformSort();
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
					PerformSort();
					watch.Stop();
					break;
				default:
					break;
			}

			if (_lastUsedSortOrder != (sortOrderComboBox.SelectedIndex == 0))
			{
				UpdateSortedArrayTextBlock();
			}
			_lastUsedSortOrder = (sortOrderComboBox.SelectedIndex == 0);

			if (!error)
			{
				sortResultTextBlock.Text = timeSpanToText(watch.Elapsed) + "  |  " + SortAlgs.comparisonsCount + " comparisons";
				enableShowSortedArrayCheckBox();
			}
			else
			{
				disableShowSortedArrayCheckBox();
			}
		}

		private void sortAlgComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			sortResultTextBlock.Text = "";
		}

		private void displaySortAlgButton_Click(object sender, RoutedEventArgs e)
		{
			if (implementationsWindow == null)
			{
				implementationsWindow = new ImplementationsWindow((SortAlgsEnum)sortAlgComboBox.SelectedIndex);
				implementationsWindow.Closed += (s, ev) =>
				{
					implementationsWindow = null;
				};
				implementationsWindow.Show();
			}
		}
	}
}