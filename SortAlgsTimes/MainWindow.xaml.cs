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
		private bool _lastUsedSortOrder; // "true" for ascending and "false" for descending
		private bool error;

		private ImplementationsWindow implementationsWindow;

		private Random rnd;
		private Stopwatch watch = new Stopwatch();

		public MainWindow()
		{
			InitializeComponent();
			arrayTypesComboBox.SelectedIndex = 0;
			arrayInitialOrderComboBox.SelectedIndex = 0;
			sortOrderComboBox.SelectedIndex = 0;
			sortAlgComboBox.SelectedIndex = 0;
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

			if (arrayInitialOrderComboBox.SelectedIndex != 0)
			{
				SortAlgs.HeapSort(_byteArray, (arrayInitialOrderComboBox.SelectedIndex == 1) ? true : false);
			}
		}

		private void createInt16Array()
		{
			_Int16Array = new short[_arraySize];

			for (uint i = 0; i < _arraySize; i++)
			{
				_Int16Array[i] = (short)rnd.Next(short.MinValue, short.MaxValue + 1);
			}

			if (arrayInitialOrderComboBox.SelectedIndex != 0)
			{
				SortAlgs.HeapSort(_Int16Array, (arrayInitialOrderComboBox.SelectedIndex == 1) ? true : false);
			}
		}

		private void createInt32Array()
		{
			_Int32Array = new int[_arraySize];

			for (uint i = 0; i < _arraySize; i++)
			{
				_Int32Array[i] = rnd.Next(int.MinValue, int.MaxValue);
			}

			if (arrayInitialOrderComboBox.SelectedIndex != 0)
			{
				SortAlgs.HeapSort(_Int32Array, (arrayInitialOrderComboBox.SelectedIndex == 1) ? true : false);
			}
		}

		private void createInt64Array()
		{
			_Int64Array = new long[_arraySize];

			for (uint i = 0; i < _arraySize; i++)
			{
				_Int64Array[i] = (long)(long.MinValue + (rnd.NextDouble() * (ulong.MaxValue)));
			}

			if (arrayInitialOrderComboBox.SelectedIndex != 0)
			{
				SortAlgs.HeapSort(_Int64Array, (arrayInitialOrderComboBox.SelectedIndex == 1) ? true : false);
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

			if (arrayInitialOrderComboBox.SelectedIndex != 0)
			{
				SortAlgs.HeapSort(_stringArray, (arrayInitialOrderComboBox.SelectedIndex == 1) ? true : false);
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
			sortButton.IsEnabled = false;
		}

		private void enableControls()
		{
			showArrayCheckBox.IsEnabled = true;
			sortButton.IsEnabled = true;
		}

		private void enableShowSortedArrayCheckBox()
		{
			showSortedArrayCheckBox.IsEnabled = true;
		}

		private void disableShowSortedArrayCheckBox()
		{
			showSortedArrayCheckBox.IsChecked = false;
			showSortedArrayCheckBox.IsEnabled = false;
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
			sortResultTextBlock.Text = "";
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
	}
}