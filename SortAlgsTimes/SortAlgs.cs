using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgsTimes
{
	public static class SortAlgs
	{
		private static void swap<T>(ref T lhs, ref T rhs)
		{
			T temp;
			temp = lhs;
			lhs = rhs;
			rhs = temp;
		}

		public static void BubbleSort(byte[] array, bool asc)
		{
			if (asc)
			{
				for (uint i = 0; i < array.Length - 1; i++)
				{
					for (uint j = 0; j < array.Length - i - 1; j++)
					{
						if (array[j] > array[j + 1])
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
						if (array[j] < array[j + 1])
						{
							swap(ref array[j], ref array[j + 1]);
						}
					}
				}
			}

		}
		public static void BubbleSort(short[] array, bool asc)
		{
			if (asc)
			{
				for (uint i = 0; i < array.Length - 1; i++)
				{
					for (uint j = 0; j < array.Length - i - 1; j++)
					{
						if (array[j] > array[j + 1])
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
						if (array[j] < array[j + 1])
						{
							swap(ref array[j], ref array[j + 1]);
						}
					}
				}
			}

		}
		public static void BubbleSort(int[] array, bool asc)
		{
			if (asc)
			{
				for (uint i = 0; i < array.Length - 1; i++)
				{
					for (uint j = 0; j < array.Length - i - 1; j++)
					{
						if (array[j] > array[j + 1])
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
						if (array[j] < array[j + 1])
						{
							swap(ref array[j], ref array[j + 1]);
						}
					}
				}
			}

		}
		public static void BubbleSort(long[] array, bool asc)
		{
			if (asc)
			{
				for (uint i = 0; i < array.Length - 1; i++)
				{
					for (uint j = 0; j < array.Length - i - 1; j++)
					{
						if (array[j] > array[j + 1])
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
						if (array[j] < array[j + 1])
						{
							swap(ref array[j], ref array[j + 1]);
						}
					}
				}
			}

		}
		public static void BubbleSort(string[] array, bool asc)
		{
			if (asc)
			{
				for (uint i = 0; i < array.Length - 1; i++)
				{
					for (uint j = 0; j < array.Length - i - 1; j++)
					{
						if (string.CompareOrdinal(array[j], array[j + 1]) > 0)
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
						if (string.CompareOrdinal(array[j], array[j + 1]) < 0)
						{
							swap(ref array[j], ref array[j + 1]);
						}
					}
				}
			}

		}

		public static void InsertionSort(byte[] array, bool asc)
		{
			byte temp;
			long j;
			if (asc)
			{
				for (long i = 1; i < array.Length; i++)
				{
					temp = array[i];
					for (j = i - 1; j >= 0 && array[j] > temp; j--)
					{
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
					for (j = i - 1; j >= 0 && array[j] < temp; j--)
					{
						array[j + 1] = array[j];
					}
					array[j + 1] = temp;
				}
			}
		}
		public static void InsertionSort(short[] array, bool asc)
		{
			short temp;
			long j;
			if (asc)
			{
				for (long i = 1; i < array.Length; i++)
				{
					temp = array[i];
					for (j = i - 1; j >= 0 && array[j] > temp; j--)
					{
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
					for (j = i - 1; j >= 0 && array[j] < temp; j--)
					{
						array[j + 1] = array[j];
					}
					array[j + 1] = temp;
				}
			}
		}
		public static void InsertionSort(int[] array, bool asc)
		{
			int temp;
			long j;
			if (asc)
			{
				for (long i = 1; i < array.Length; i++)
				{
					temp = array[i];
					for (j = i - 1; j >= 0 && array[j] > temp; j--)
					{
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
					for (j = i - 1; j >= 0 && array[j] < temp; j--)
					{
						array[j + 1] = array[j];
					}
					array[j + 1] = temp;
				}
			}
		}
		public static void InsertionSort(long[] array, bool asc)
		{
			long temp;
			long j;
			if (asc)
			{
				for (long i = 1; i < array.Length; i++)
				{
					temp = array[i];
					for (j = i - 1; j >= 0 && array[j] > temp; j--)
					{
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
					for (j = i - 1; j >= 0 && array[j] < temp; j--)
					{
						array[j + 1] = array[j];
					}
					array[j + 1] = temp;
				}
			}
		}
		public static void InsertionSort(string[] array, bool asc)
		{
			string temp;
			long j;
			if (asc)
			{
				for (long i = 1; i < array.Length; i++)
				{
					temp = array[i];
					for (j = i - 1; j >= 0 && (string.CompareOrdinal(array[j], temp) > 0); j--)
					{
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
					for (j = i - 1; j >= 0 && (string.CompareOrdinal(array[j], temp) < 0); j--)
					{
						array[j + 1] = array[j];
					}
					array[j + 1] = temp;
				}
			}
		}

		public static void MergeSort(byte[] array, int left, int right, bool asc)
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
		private static void DoMerge(byte[] array, int left, int mid, int right, bool asc)
		{
			byte[] temp = new byte[array.Length];
			int i, left_end, num_elements, tmp_pos;

			left_end = (mid - 1);
			tmp_pos = left;
			num_elements = (right - left + 1);

			if (asc)
			{
				while ((left <= left_end) && (mid <= right))
				{
					if (array[left] <= array[mid])
						temp[tmp_pos++] = array[left++];
					else
						temp[tmp_pos++] = array[mid++];
				}
			}
			else
			{
				while ((left <= left_end) && (mid <= right))
				{
					if (array[left] >= array[mid])
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
		public static void MergeSort(short[] array, int left, int right, bool asc)
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
		private static void DoMerge(short[] array, int left, int mid, int right, bool asc)
		{
			short[] temp = new short[array.Length];
			int i, left_end, num_elements, tmp_pos;

			left_end = (mid - 1);
			tmp_pos = left;
			num_elements = (right - left + 1);

			if (asc)
			{
				while ((left <= left_end) && (mid <= right))
				{
					if (array[left] <= array[mid])
						temp[tmp_pos++] = array[left++];
					else
						temp[tmp_pos++] = array[mid++];
				}
			}
			else
			{
				while ((left <= left_end) && (mid <= right))
				{
					if (array[left] >= array[mid])
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
		public static void MergeSort(int[] array, int left, int right, bool asc)
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
		private static void DoMerge(int[] array, int left, int mid, int right, bool asc)
		{
			int[] temp = new int[array.Length];
			int i, left_end, num_elements, tmp_pos;

			left_end = (mid - 1);
			tmp_pos = left;
			num_elements = (right - left + 1);

			if (asc)
			{
				while ((left <= left_end) && (mid <= right))
				{
					if (array[left] <= array[mid])
						temp[tmp_pos++] = array[left++];
					else
						temp[tmp_pos++] = array[mid++];
				}
			}
			else
			{
				while ((left <= left_end) && (mid <= right))
				{
					if (array[left] >= array[mid])
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
		public static void MergeSort(long[] array, int left, int right, bool asc)
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
		private static void DoMerge(long[] array, int left, int mid, int right, bool asc)
		{
			long[] temp = new long[array.Length];
			int i, left_end, num_elements, tmp_pos;

			left_end = (mid - 1);
			tmp_pos = left;
			num_elements = (right - left + 1);

			if (asc)
			{
				while ((left <= left_end) && (mid <= right))
				{
					if (array[left] <= array[mid])
						temp[tmp_pos++] = array[left++];
					else
						temp[tmp_pos++] = array[mid++];
				}
			}
			else
			{
				while ((left <= left_end) && (mid <= right))
				{
					if (array[left] >= array[mid])
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
		public static void MergeSort(string[] array, int left, int right, bool asc)
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
		private static void DoMerge(string[] array, int left, int mid, int right, bool asc)
		{
			string[] temp = new string[array.Length];
			int i, left_end, num_elements, tmp_pos;

			left_end = (mid - 1);
			tmp_pos = left;
			num_elements = (right - left + 1);

			if (asc)
			{
				while ((left <= left_end) && (mid <= right))
				{
					if (string.CompareOrdinal(array[left], array[mid]) <= 0)
						temp[tmp_pos++] = array[left++];
					else
						temp[tmp_pos++] = array[mid++];
				}
			}
			else
			{
				while ((left <= left_end) && (mid <= right))
				{
					if (string.CompareOrdinal(array[left], array[mid]) >= 0)
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
