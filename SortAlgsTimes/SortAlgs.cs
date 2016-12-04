using System;

namespace SortAlgsTimes
{
	public static class SortAlgs
	{
		public static ulong comparisonCount; // Number of comparisons(between array elements) done by sort algorithms

		private static void swap<T>(ref T lhs, ref T rhs)
		{
			T temp;
			temp = lhs;
			lhs = rhs;
			rhs = temp;
		}

		// Bubble Sort algorithm
		public static void BubbleSort<T>(T[] array, bool asc) where T : IComparable<T>
		{
			if (asc)
			{
				for (uint i = 0; i < array.Length - 1; i++)
				{
					for (uint j = 0; j < array.Length - i - 1; j++)
					{
						comparisonCount++;
						if (array[j].CompareTo(array[j + 1]) > 0)
						{
							swap(ref array[j], ref array[j + 1]);
						}
					}
				}
			}
			else
			{
				for (uint i = 0; i < array.Length - 1; i++)
				{
					for (uint j = 0; j < array.Length - i - 1; j++)
					{
						comparisonCount++;
						if (array[j].CompareTo(array[j + 1]) < 0)
						{
							swap(ref array[j], ref array[j + 1]);
						}
					}
				}
			}
		}

		// Insertion Sort algorithm
		public static void InsertionSort<T>(T[] array, bool asc) where T :IComparable<T>
		{
			T temp;
			long j;

			if (asc)
			{
				for (long i = 1; i < array.Length; i++)
				{
					temp = array[i];
					comparisonCount++;
					for (j = i - 1; j >= 0 && array[j].CompareTo(temp) > 0; j--)
					{
						comparisonCount++;
						array[j + 1] = array[j];
					}
					array[j + 1] = temp;
				}
			}
			else
			{
				for (long i = 1; i < array.Length; i++)
				{
					temp = array[i];
					comparisonCount++;
					for (j = i - 1; j >= 0 && array[j].CompareTo(temp) < 0; j--)
					{
						comparisonCount++;
						array[j + 1] = array[j];
					}
					array[j + 1] = temp;
				}
			}
		}

		// Quick Sort algorithm
		public static void QuickSort<T>(T[] array, int lo, int hi, bool asc) where T : IComparable<T>
		{
			if (lo < hi)
			{
				int p = partition(array, lo, hi, asc);
				QuickSort(array, lo, p, asc);
				QuickSort(array, p + 1, hi, asc);
			}
		}

		private static int partition<T>(T[] array, int lo, int hi, bool asc) where T : IComparable<T>
		{
			T pivot = array[lo];
			int i = lo - 1;
			int j = hi + 1;

			if (asc)
			{
				while (true)
				{
					do
					{
						i++;
						comparisonCount++;
					} while (array[i].CompareTo(pivot) < 0);

					do
					{
						j--;
						comparisonCount++;
					} while (array[j].CompareTo(pivot) > 0);

					if (i >= j)
					{
						return j;
					}
					swap(ref array[i], ref array[j]);
				}
			}
			else
			{
				while (true)
				{
					do
					{
						i++;
						comparisonCount++;
					} while (array[i].CompareTo(pivot) > 0);

					do
					{
						j--;
						comparisonCount++;
					} while (array[j].CompareTo(pivot) < 0);

					if (i >= j)
					{
						return j;
					}
					swap(ref array[i], ref array[j]);
				}
			}
		}

		// Merge Sort algorithm
		public static void MergeSort<T>(T[] array, int left, int right, bool asc) where T : IComparable<T>
		{
			int mid;

			if (right > left)
			{
				mid = (right + left) / 2;

				MergeSort(array, left, mid, asc);
				MergeSort(array, (mid + 1), right, asc);
				DoMerge(array, left, (mid + 1), right, asc);
			}
		}

		private static void DoMerge<T>(T[] array, int left, int mid, int right, bool asc) where T : IComparable<T>
		{
			T[] temp = new T[array.Length];
			int i, left_end, num_elements, tmp_pos;

			left_end = (mid - 1);
			tmp_pos = left;
			num_elements = (right - left + 1);

			if (asc)
			{
				while ((left <= left_end) && (mid <= right))
				{
					comparisonCount++;
					if (array[left].CompareTo(array[mid]) <= 0)
						temp[tmp_pos++] = array[left++];
					else
						temp[tmp_pos++] = array[mid++];
				}
			}
			else
			{
				while ((left <= left_end) && (mid <= right))
				{
					comparisonCount++;
					if (array[left].CompareTo(array[mid]) >= 0)
						temp[tmp_pos++] = array[left++];
					else
						temp[tmp_pos++] = array[mid++];
				}
			}

			while (left <= left_end)
				temp[tmp_pos++] = array[left++];

			while (mid <= right)
				temp[tmp_pos++] = array[mid++];

			for (i = 0; i < num_elements; i++)
			{
				array[right] = temp[right];
				right--;
			}
		}

		// Heap Sort algorithm
		public static void HeapSort<T>(T[] array, bool asc) where T : IComparable<T>
		{
			heapify(array, asc);

			int end = array.Length - 1;

			while (end > 0)
			{
				swap(ref array[end], ref array[0]);
				end--;
				shiftDown(array, 0, end, asc);
			}
		}

		private static void heapify<T>(T[] array, bool asc) where T : IComparable<T>
		{
			int start = (array.Length - 1 - 1) / 2;

			while (start >= 0)
			{
				shiftDown(array, start, array.Length - 1, asc);
				start--;
			}
		}

		private static void shiftDown<T>(T[] array, int start, int end, bool asc) where T : IComparable<T>
		{
			int root = start;

			while (2 * root + 1 <= end)
			{
				int child = 2 * root + 1;
				int _swap= root;

				if (asc)
				{
					comparisonCount++;
					if (array[_swap].CompareTo(array[child]) < 0)
					{
						_swap = child;
					}
					comparisonCount++;
					if ((child + 1 <= end) && (array[_swap].CompareTo(array[child + 1]) < 0))
					{
						_swap = child + 1;
					}
				}
				else
				{
					comparisonCount++;
					if (array[_swap].CompareTo(array[child]) > 0)
					{
						_swap = child;
					}
					comparisonCount++;
					if ((child + 1 <= end) && (array[_swap].CompareTo(array[child + 1]) > 0))
					{
						_swap = child + 1;
					}
				}
				
				if (_swap == root)
				{
					return;
				}
				else
				{
					swap(ref array[root], ref array[_swap]);
					root = _swap;
				}
			}
		}
	}
}