using System;

namespace SortAlgsTimes
{
	public enum SortAlgsEnum { BUBBLE_SORT, INSERTION_SORT, MERGE_SORT, QUICK_SORT, HEAP_SORT, PIGEON_SORT, COUNT_SORT, RADIX_SORT, SHELL_SORT, BINARY_INSERTION_SORT };

	public static class SortAlgs
	{
		public static ulong comparisonsCount; // Number of comparisons(between array elements) done by sort algorithms

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
				for (long i = 0; i < array.Length - 1; i++)
				{
					for (long j = 0; j < array.Length - i - 1; j++)
					{
						comparisonsCount++;
						if (array[j].CompareTo(array[j + 1]) > 0)
						{
							swap(ref array[j], ref array[j + 1]);
						}
					}
				}
			}
			else
			{
				for (long i = 0; i < array.Length - 1; i++)
				{
					for (long j = 0; j < array.Length - i - 1; j++)
					{
						comparisonsCount++;
						if (array[j].CompareTo(array[j + 1]) < 0)
						{
							swap(ref array[j], ref array[j + 1]);
						}
					}
				}
			}
		}

		// Insertion Sort algorithm
		public static void InsertionSort<T>(T[] array, bool asc) where T : IComparable<T>
		{
			T temp;
			long j;

			if (asc)
			{
				for (long i = 1; i < array.Length; i++)
				{
					temp = array[i];
					for (j = i - 1; j >= 0 && array[j].CompareTo(temp) > 0; j--)
					{
						comparisonsCount++;
						array[j + 1] = array[j];
					}
					comparisonsCount++;
					array[j + 1] = temp;
				}
			}
			else
			{
				for (long i = 1; i < array.Length; i++)
				{
					temp = array[i];
					for (j = i - 1; j >= 0 && array[j].CompareTo(temp) < 0; j--)
					{
						comparisonsCount++;
						array[j + 1] = array[j];
					}
					comparisonsCount++;
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
						comparisonsCount++;
					} while (array[i].CompareTo(pivot) < 0);

					do
					{
						j--;
						comparisonsCount++;
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
						comparisonsCount++;
					} while (array[i].CompareTo(pivot) > 0);

					do
					{
						j--;
						comparisonsCount++;
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
				MergeSort(array, mid + 1, right, asc);
				DoMerge(array, left, mid + 1, right, asc);
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
					comparisonsCount++;
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
					comparisonsCount++;
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
			int start = (array.Length - 2) / 2;

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
				int _swap = root;

				if (asc)
				{
					comparisonsCount++;
					if (array[_swap].CompareTo(array[child]) < 0)
					{
						_swap = child;
					}
					comparisonsCount++;
					if ((child + 1 <= end) && (array[_swap].CompareTo(array[child + 1]) < 0))
					{
						_swap = child + 1;
					}
				}
				else
				{
					comparisonsCount++;
					if (array[_swap].CompareTo(array[child]) > 0)
					{
						_swap = child;
					}
					comparisonsCount++;
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

		// Pigeonhole Sort algorithm (byte)
		public static void PigeonholeSort(byte[] array, bool asc)
		{
			byte min = array[0];
			byte max = array[0];

			foreach (byte item in array)
			{
				if (item < min)
				{
					min = item;
				}
				if (item > max)
				{
					max = item;
				}
				comparisonsCount += 2;
			}

			short size = (short)(max - min + 1);

			int[] holes = new int[size];

			foreach (byte item in array)
			{
				holes[item - min]++;
			}

			if (asc)
			{
				int i = 0;
				for (short j = 0; j < size; j++)
				{
					while (holes[j]-- > 0)
					{
						array[i++] = (byte)(j + min);
					}
				}
			}
			else
			{
				int i = 0;
				for (short j = (byte)(size - 1); j >= 0; j--)
				{
					while (holes[j]-- > 0)
					{
						array[i++] = (byte)(j + min);
					}
				}
			}
		}

		// Pigeonhole Sort algorithm (short)
		public static void PigeonholeSort(short[] array, bool asc)
		{
			short min = array[0];
			short max = array[0];

			foreach (short item in array)
			{
				if (item < min)
				{
					min = item;
				}
				if (item > max)
				{
					max = item;
				}
				comparisonsCount += 2;
			}

			int size = max - min + 1;

			int[] holes = new int[size];

			foreach (short item in array)
			{
				holes[item - min]++;
			}

			if (asc)
			{
				int i = 0;
				for (int j = 0; j < size; j++)
				{
					while (holes[j]-- > 0)
					{
						array[i++] = (short)(j + min);
					}
				}
			}
			else
			{
				int i = 0;
				for (int j = size - 1; j >= 0; j--)
				{
					while (holes[j]-- > 0)
					{
						array[i++] = (short)(j + min);
					}
				}
			}
		}

		// Counting Sort algorithm (byte)
		public static void CountingSort(byte[] array, bool asc)
		{
			byte min = array[0];
			byte max = array[0];

			foreach (byte item in array)
			{
				if (item < min)
				{
					min = item;
				}
				if (item > max)
				{
					max = item;
				}
				comparisonsCount += 2;
			}

			int[] counts = new int[max - min + 1];

			foreach (byte item in array)
			{
				counts[item - min]++;
			}

			counts[0]--;
			for (short i = 1; i < counts.Length; i++)
			{
				counts[i] = counts[i] + counts[i - 1];
			}

			byte[] sortedArray = new byte[array.Length];

			for (int i = array.Length - 1; i >= 0; i--)
			{
				sortedArray[counts[array[i] - min]--] = array[i];
			}

			if (asc)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = sortedArray[i];
				}
			}
			else
			{
				for (int i = 0, j = array.Length - 1; i < array.Length; i++, j--)
				{
					array[j] = sortedArray[i];
				}
			}
		}

		// Counting Sort algorithm (short)
		public static void CountingSort(short[] array, bool asc)
		{
			short min = array[0];
			short max = array[0];

			foreach (short item in array)
			{
				if (item < min)
				{
					min = item;
				}
				if (item > max)
				{
					max = item;
				}
				comparisonsCount += 2;
			}

			int[] counts = new int[max - min + 1];

			foreach (short item in array)
			{
				counts[item - min]++;
			}

			counts[0]--;
			for (int i = 1; i < counts.Length; i++)
			{
				counts[i] = counts[i] + counts[i - 1];
			}

			short[] sortedArray = new short[array.Length];

			for (int i = array.Length - 1; i >= 0; i--)
			{
				sortedArray[counts[array[i] - min]--] = array[i];
			}


			if (asc)
			{
				Array.Copy(sortedArray, array, array.Length);
			}
			else
			{
				for (int i = 0, j = array.Length - 1; i < array.Length; i++, j--)
				{
					array[j] = sortedArray[i];
				}
			}
		}

		// Radix Sort algorithm (byte)
		public static void RadixSort(byte[] array, bool asc)
		{
			int i, j;
			byte[] tmp = new byte[array.Length];
			for (int shift = 31; shift > -1; shift--)
			{
				j = 0;
				for (i = 0; i < array.Length; i++)
				{
					comparisonsCount += 2;
					bool move = (array[i] << shift) >= 0;
					if (shift == 0 ? !move : move)
						array[i - j] = array[i];
					else
						tmp[j++] = array[i];
				}
				Array.Copy(tmp, 0, array, array.Length - j, j);
			}

			if (!asc)
			{
				Array.Reverse(array);
			}
		}

		// Radix Sort algorithm (short)
		public static void RadixSort(short[] array, bool asc)
		{
			int i, j;
			short[] tmp = new short[array.Length];
			for (int shift = 31; shift > -1; shift--)
			{
				j = 0;
				for (i = 0; i < array.Length; i++)
				{
					comparisonsCount += 2;
					bool move = (array[i] << shift) >= 0;
					if (shift == 0 ? !move : move)
						array[i - j] = array[i];
					else
						tmp[j++] = array[i];
				}
				Array.Copy(tmp, 0, array, array.Length - j, j);
			}

			if (!asc)
			{
				Array.Reverse(array);
			}
		}

		// Radix Sort algorithm (int)
		public static void RadixSort(int[] array, bool asc)
		{
			int i, j;
			int[] tmp = new int[array.Length];
			for (int shift = 31; shift > -1; shift--)
			{
				j = 0;
				for (i = 0; i < array.Length; i++)
				{
					comparisonsCount += 2;
					bool move = (array[i] << shift) >= 0;
					if (shift == 0 ? !move : move)
						array[i - j] = array[i];
					else
						tmp[j++] = array[i];
				}
				Array.Copy(tmp, 0, array, array.Length - j, j);
			}

			if (!asc)
			{
				Array.Reverse(array);
			}
		}

		// Radix Sort algorithm (long)
		public static void RadixSort(long[] array, bool asc)
		{
			long i, j;
			long[] tmp = new long[array.Length];
			for (int shift = 31; shift > -1; shift--)
			{
				j = 0;
				for (i = 0; i < array.Length; i++)
				{
					comparisonsCount += 2;
					bool move = (array[i] << shift) >= 0;
					if (shift == 0 ? !move : move)
						array[i - j] = array[i];
					else
						tmp[j++] = array[i];
				}
				Array.Copy(tmp, 0, array, array.Length - j, j);
			}

			if (!asc)
			{
				Array.Reverse(array);
			}
		}

		// Shell Sort algorithm
		public static void ShellSort<T>(T[] array, bool asc) where T : IComparable<T>
		{
			int gap = array.Length / 2;
			T temp;

			while (gap > 0)
			{
				for (int i = 0; i + gap < array.Length; i++)
				{
					comparisonsCount++;
					int j = i + gap;
					temp = array[j];

					if (asc)
					{
						while (j - gap >= 0 && temp.CompareTo(array[j - gap]) < 0)
						{
							comparisonsCount++;
							array[j] = array[j - gap];
							j = j - gap;
						}
					}
					else
					{
						while (j - gap >= 0 && temp.CompareTo(array[j - gap]) > 0)
						{
							comparisonsCount++;
							array[j] = array[j - gap];
							j = j - gap;
						}
					}
					comparisonsCount++;
					array[j] = temp;
				}
				comparisonsCount++;
				gap = gap / 2;
			}
		}

		// Binary Insertion Sort algorithm
		public static void BinaryInsertionSort<T>(T[] array, bool asc) where T : IComparable<T>
		{
			for (int i = 1; i < array.Length; i++)
			{
				int low = 0;
				int high = i - 1;
				T temp = array[i];

				while (low <= high)
				{
					comparisonsCount++;
					int mid = (low + high) / 2;

					comparisonsCount++;
					if (asc)
					{
						if (temp.CompareTo(array[mid]) < 0)
							high = mid - 1;
						else
							low = mid + 1;
					}
					else
					{
						if (temp.CompareTo(array[mid]) > 0)
							high = mid - 1;
						else
							low = mid + 1;
					}
				}
				comparisonsCount++;

				for (int j = i - 1; j >= low; j--)
					array[j + 1] = array[j];

				array[low] = temp;
			}
		}
	}
}