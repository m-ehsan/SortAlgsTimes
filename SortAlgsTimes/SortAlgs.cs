using System;

namespace SortAlgsTimes
{
	public static class SortAlgs
	{
		public static ulong comparisonCount;

		private static void swap<T>(ref T lhs, ref T rhs)
		{
			T temp;
			temp = lhs;
			lhs = rhs;
			rhs = temp;
		}

		public static void BubbleSort<T>(T[] array, bool asc) where T : IComparable<T>
		{
			comparisonCount = 0;

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

		public static void InsertionSort<T>(T[] array, bool asc) where T :IComparable<T>
		{
			comparisonCount = 0;
			T temp;
			long j;

			if (asc)
			{
				for (long i = 1; i < array.Length; i++)
				{
					temp = array[i];
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
					for (j = i - 1; j >= 0 && array[j].CompareTo(temp) < 0; j--)
					{
						comparisonCount++;
						array[j + 1] = array[j];
					}
					array[j + 1] = temp;
				}
			}
		}
		
		public static void MergeSort<T>(T[] array, int left, int right, bool asc) where T : IComparable<T>
		{
			comparisonCount = 0;
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
	}
}