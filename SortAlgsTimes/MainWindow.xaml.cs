using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace SortAlgsTimes
{
	public partial class MainWindow : Window
	{
		private byte[] _byteArray;
		private short[] _Int16Array;
		private int[] _Int32Array;
		private long[] _Int64Array;
		private string[] _stringArray;

		private byte[] _sortedByteArray;
		private short[] _sortedInt16Array;
		private int[] _sortedInt32Array;
		private long[] _sortedInt64Array;
		private string[] _sortedStringArray;

		private short _maxStringLengthBound = 50;
		private uint _arraySize;
		private short _minStringLength;
		private short _maxStringLength;
		private Random rnd;
		private Stopwatch watch = new Stopwatch();

		public MainWindow()
		{
			InitializeComponent();
			arrayTypesComboBox.SelectedIndex = 0;
			initSringLengthBoundsComboBoxes();
			stringLengthBoundComboBox1.SelectedIndex = 9;
			stringLengthBoundComboBox2.SelectedIndex = 19;
			rnd = new Random();
		}

		private void createByteArray()
		{
			_byteArray = new byte[_arraySize];

			for (uint i = 0; i < _arraySize; i++)
			{
				_byteArray[i] = (byte)rnd.Next(byte.MinValue, byte.MaxValue + 1);
			}
		}

		private void createInt16Array()
		{
			_Int16Array = new short[_arraySize];

			for (uint i = 0; i < _arraySize; i++)
			{
				_Int16Array[i] = (short)rnd.Next(short.MinValue, short.MaxValue + 1);
			}
		}

		private void createInt32Array()
		{
			_Int32Array = new int[_arraySize];

			for (uint i = 0; i < _arraySize; i++)
			{
				_Int32Array[i] = rnd.Next(int.MinValue, int.MaxValue);
			}
		}

		private void createInt64Array()
		{
			_Int64Array = new long[_arraySize];

			for (uint i = 0; i < _arraySize; i++)
			{
				_Int64Array[i] = (long)(long.MinValue + (rnd.NextDouble() * (ulong.MaxValue)));
			}
		}

		private void createStringArray()
		{
			_stringArray = new string[_arraySize];
			string s;

			if (_minStringLength != _maxStringLength)
			{
				for (uint i = 0; i < _arraySize; i++)
				{
					s = "";
					for (short j = 0; j < rnd.Next(_minStringLength, _maxStringLength + 1); j++)
					{
						s += (char)(rnd.Next(97, 123));
					}
					_stringArray[i] = s;
				}
			}
			else
			{
				for (uint i = 0; i < _arraySize; i++)
				{
					s = "";
					for (short j = 0; j < _minStringLength; j++)
					{
						s += (char)(rnd.Next(97, 123));
					}
					_stringArray[i] = s;
				}
			}

		}

		private void initSringLengthBoundsComboBoxes()
		{
			stringLengthBoundComboBox1.Items.Clear();
			stringLengthBoundComboBox2.Items.Clear();

			for (short i = 0; i < _maxStringLengthBound; i++)
			{
				stringLengthBoundComboBox1.Items.Add(i + 1);
				stringLengthBoundComboBox2.Items.Add(i + 1);
			}
		}

		private void copyArrayItemsToDisplay(ref TextBlock dest)
		{
			dest.Text = "{";

			switch (arrayTypesComboBox.SelectedIndex)
			{
				case 0:
					for (uint i = 0; i < _arraySize; i++)
					{
						dest.Text += " " + _byteArray[i];
						if (i != _arraySize - 1)
						{
							dest.Text += ",";
						}
					}
					break;
				case 1:
					for (uint i = 0; i < _arraySize; i++)
					{
						dest.Text += " " + _Int16Array[i];
						if (i != _arraySize - 1)
						{
							dest.Text += ",";
						}
					}
					break;
				case 2:
					for (uint i = 0; i < _arraySize; i++)
					{
						dest.Text += " " + _Int32Array[i];
						if (i != _arraySize - 1)
						{
							dest.Text += ",";
						}
					}
					break;
				case 3:
					for (uint i = 0; i < _arraySize; i++)
					{
						dest.Text += " " + _Int64Array[i];
						if (i != _arraySize - 1)
						{
							dest.Text += ",";
						}
					}
					break;
				case 4:
					for (uint i = 0; i < _arraySize; i++)
					{
						dest.Text += " " + _stringArray[i];
						if (i != _arraySize - 1)
						{
							dest.Text += ",";
						}
					}
					break;
				default:
					break;
			}

			dest.Text += " }";
		}

		private void copySortedArrayItemsToDisplay(ref TextBlock dest)
		{
			dest.Text = "{";

			switch (arrayTypesComboBox.SelectedIndex)
			{
				case 0:
					for (uint i = 0; i < _arraySize; i++)
					{
						dest.Text += " " + _sortedByteArray[i];
						if (i != _arraySize - 1)
						{
							dest.Text += ",";
						}
					}
					break;
				case 1:
					for (uint i = 0; i < _arraySize; i++)
					{
						dest.Text += " " + _sortedInt16Array[i];
						if (i != _arraySize - 1)
						{
							dest.Text += ",";
						}
					}
					break;
				case 2:
					for (uint i = 0; i < _arraySize; i++)
					{
						dest.Text += " " + _sortedInt32Array[i];
						if (i != _arraySize - 1)
						{
							dest.Text += ",";
						}
					}
					break;
				case 3:
					for (uint i = 0; i < _arraySize; i++)
					{
						dest.Text += " " + _sortedInt64Array[i];
						if (i != _arraySize - 1)
						{
							dest.Text += ",";
						}
					}
					break;
				case 4:
					for (uint i = 0; i < _arraySize; i++)
					{
						dest.Text += " " + _sortedStringArray[i];
						if (i != _arraySize - 1)
						{
							dest.Text += ",";
						}
					}
					break;
				default:
					break;
			}

			dest.Text += " }";
		}

		private void hideArrayContent()
		{
			showArrayCheckBox.IsChecked = false;
			showSortedArrayCheckBox.IsChecked = false;
		}

		private void disableControls()
		{
			showArrayCheckBox.IsEnabled = false;
			showSortedArrayCheckBox.IsEnabled = false;
			bubbleSortButton.IsEnabled = false;
			insertionSortButton.IsEnabled = false;
			mergeSortButton.IsEnabled = false;
		}

		private void enableControls()
		{
			showArrayCheckBox.IsEnabled = true;
			bubbleSortButton.IsEnabled = true;
			insertionSortButton.IsEnabled = true;
			mergeSortButton.IsEnabled = true;
		}

		private void enableShowSorteArrayCheckBox()
		{
			showSortedArrayCheckBox.IsEnabled = true;
		}

		private void clearUserData()
		{
			_byteArray = null;
			_Int16Array = null;
			_Int32Array = null;
			_Int64Array = null;
			_stringArray = null;
			_sortedByteArray = null;
			_sortedInt16Array = null;
			_sortedInt32Array = null;
			_sortedInt64Array = null;
			_sortedStringArray = null;
			_arraySize = 0;
			_minStringLength = 0;
			_maxStringLength = 0;
			hideArrayContent();
			disableControls();
			arrayContentTextBlock.Text = "[EMPTY]";
			sortedArrayContentTextBlock.Text = "[EMPTY]";
			bubbleSortTime.Text = "";
			insertionSortTime.Text = "";
			mergeSortTime.Text = "";
		}

		private void swap<T>(ref T lhs, ref T rhs)
		{
			T temp;
			temp = lhs;
			lhs = rhs;
			rhs = temp;
		}

		private string timeSpanToText(TimeSpan t)
		{
			string result = "";
			//result += (int)t.TotalSeconds;
			//result += ".";
			//result += (t.Milliseconds < 10) ? ("00" + t.Milliseconds) : (t.Milliseconds < 100) ? ("0" + t.Milliseconds) : t.Milliseconds.ToString();
			//result += "  seconds";

			result = t.TotalMilliseconds.ToString();
			short i;
			char temp;
			List<char> m = new List<char>();
			for (i = 0; i < result.Length; i++)
			{
				m.Add(result[i]);
			}
			for (i = 0; i < m.Count; i++)
			{
				if (m[i] == '.')
				{
					break;
				}
			}
			for (byte j = 0; j < 3; j++)
			{
				if (m[0] == '.')
				{
					m.Insert(0, '0');
					i++;
				}
				temp = m[i];
				m[i] = m[i - 1];
				m[i - 1] = temp;
				i--;
			}
			if (m[0] == '.')
			{
				m.Insert(0, '0');
			}
			result = "";
			for (i = 0; i < m.Count; i++)
			{
				result += m[i];
			}
			result += "  seconds";
			return result;
		}

		private void bubbleSortButton_Click(object sender, RoutedEventArgs e)
		{
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
					SortAlgs.BubbleSort(_sortedByteArray);
					watch.Stop();
					bubbleSortTime.Text = timeSpanToText(watch.Elapsed);
					break;
				case 1:
					_sortedInt16Array = new short[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt16Array[i] = _Int16Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.BubbleSort(_sortedInt16Array);
					watch.Stop();
					bubbleSortTime.Text = timeSpanToText(watch.Elapsed);
					break;
				case 2:
					_sortedInt32Array = new int[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt32Array[i] = _Int32Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.BubbleSort(_sortedInt32Array);
					watch.Stop();
					bubbleSortTime.Text = timeSpanToText(watch.Elapsed);
					break;
				case 3:
					_sortedInt64Array = new long[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt64Array[i] = _Int64Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.BubbleSort(_sortedInt64Array);
					watch.Stop();
					bubbleSortTime.Text = timeSpanToText(watch.Elapsed);
					break;
				case 4:
					_sortedStringArray = new string[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedStringArray[i] = _stringArray[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.BubbleSort(_sortedStringArray);
					watch.Stop();
					bubbleSortTime.Text = timeSpanToText(watch.Elapsed);
					break;
				default:
					break;
			}
			enableShowSorteArrayCheckBox();
		}

		private void insertionSortButton_Click(object sender, RoutedEventArgs e)
		{
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
					SortAlgs.InsertionSort(_sortedByteArray);
					watch.Stop();
					insertionSortTime.Text = timeSpanToText(watch.Elapsed);
					break;
				case 1:
					_sortedInt16Array = new short[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt16Array[i] = _Int16Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.InsertionSort(_sortedInt16Array);
					watch.Stop();
					insertionSortTime.Text = timeSpanToText(watch.Elapsed);
					break;
				case 2:
					_sortedInt32Array = new int[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt32Array[i] = _Int32Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.InsertionSort(_sortedInt32Array);
					watch.Stop();
					insertionSortTime.Text = timeSpanToText(watch.Elapsed);
					break;
				case 3:
					_sortedInt64Array = new long[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt64Array[i] = _Int64Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.InsertionSort(_sortedInt64Array);
					watch.Stop();
					insertionSortTime.Text = timeSpanToText(watch.Elapsed);
					break;
				case 4:
					_sortedStringArray = new string[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedStringArray[i] = _stringArray[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.InsertionSort(_sortedStringArray);
					watch.Stop();
					insertionSortTime.Text = timeSpanToText(watch.Elapsed);
					break;
				default:
					break;
			}
			enableShowSorteArrayCheckBox();
		}

		private void mergeSortButton_Click(object sender, RoutedEventArgs e)
		{
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
					SortAlgs.MergeSort(_sortedByteArray, 0 ,_sortedByteArray.Length - 1);
					watch.Stop();
					mergeSortTime.Text = timeSpanToText(watch.Elapsed);
					break;
				case 1:
					_sortedInt16Array = new short[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt16Array[i] = _Int16Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.MergeSort(_sortedInt16Array, 0, _sortedInt16Array.Length - 1);
					watch.Stop();
					mergeSortTime.Text = timeSpanToText(watch.Elapsed);
					break;
				case 2:
					_sortedInt32Array = new int[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt32Array[i] = _Int32Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.MergeSort(_sortedInt32Array, 0, _sortedInt32Array.Length - 1);
					watch.Stop();
					mergeSortTime.Text = timeSpanToText(watch.Elapsed);
					break;
				case 3:
					_sortedInt64Array = new long[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedInt64Array[i] = _Int64Array[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.MergeSort(_sortedInt64Array, 0, _sortedInt64Array.Length - 1);
					watch.Stop();
					mergeSortTime.Text = timeSpanToText(watch.Elapsed);
					break;
				case 4:
					_sortedStringArray = new string[_arraySize];
					for (uint i = 0; i < _arraySize; i++)
					{
						_sortedStringArray[i] = _stringArray[i];
					}
					watch.Reset();
					watch.Start();
					SortAlgs.MergeSort(_sortedStringArray, 0, _sortedStringArray.Length - 1);
					watch.Stop();
					mergeSortTime.Text = timeSpanToText(watch.Elapsed);
					break;
				default:
					break;
			}
			enableShowSorteArrayCheckBox();
		}
	}
}