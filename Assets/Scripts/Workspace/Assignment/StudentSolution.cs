using UnityEngine;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        #region Lecture
        public int[] LCT01_SelectionSortAscending(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j] < numbers[minIndex])
                    {
                        minIndex = j;
                    }
                }
                //int temp = numbers[minIndex];
                //numbers[minIndex] = numbers[i];
                //numbers[i] = temp;
                (numbers[i], numbers[minIndex]) = (numbers[minIndex], numbers[i]);
            }
            foreach (var n_ in numbers)
            {
                Debug.Log(n_);
            }
            return numbers;
        }

        public int[] LCT02_BubbleSortAscending(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
            foreach (var n_ in numbers)
            {
                Debug.Log(n_);
            }
            return numbers;
        }

        public int[] LCT03_InsertionSortAscending(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n; i++)
            {
                int key = numbers[i];
                int j = i - 1;
                while (j >= 0 && numbers[j] > key)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }
                numbers[j + 1] = key;
            }
            foreach (var n_ in numbers)
            {
                Debug.Log(n_);
            }
            return numbers;
        }

        #endregion

        #region Assignment

        public int[] AS01_SelectionSortDescending(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return numbers;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    // หาค่ามากที่สุดในส่วนที่เหลือ
                    if (numbers[j] > numbers[maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                // สลับค่ามากที่สุดมาไว้ที่ตำแหน่งปัจจุบัน
                int temp = numbers[i];
                numbers[i] = numbers[maxIndex];
                numbers[maxIndex] = temp;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Debug.Log(numbers[i]);
            }
            return numbers;
        }

        public int[] AS02_BubbleSortDescending(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return numbers;

            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // สลับถ้าตัวซ้ายน้อยกว่าตัวขวา (ดันค่ามากไปทางซ้าย)
                    if (numbers[j] < numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Debug.Log(numbers[i]);
            }
            return numbers;
        }

        public int[] AS03_InsertionSortDescending(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return numbers;

            for (int i = 1; i < numbers.Length; i++)
            {
                int key = numbers[i];
                int j = i - 1;

                // เลื่อนตัวเลขที่น้อยกว่า key ไปทางขวา
                while (j >= 0 && numbers[j] < key)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }
                numbers[j + 1] = key;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Debug.Log(numbers[i]);
            }
            return numbers;
        }

        public int AS04_FindTheSecondLargestNumber(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return 0;

            // เรียงลำดับจากมาก -> น้อย
            Array.Sort(numbers);
            Array.Reverse(numbers);

            int maxVal = numbers[0];
            int secondLargest = maxVal;
            bool found = false;

            // ลูปหาค่าแรกที่น้อยกว่าค่าสูงสุด
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < maxVal)
                {
                    secondLargest = numbers[i];
                    found = true;
                    break;
                }
            }

            int result = found ? secondLargest : maxVal;
            Debug.Log(result);
            return result;
        }

        #endregion

        #region Extra

        public int EX01_FindLongestConsecutiveSequence(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("The longest consecutive sequence is: 0");
                return 0;
            }

            // เรียงข้อมูลจากน้อย -> มาก
            Array.Sort(numbers);

            int maxStreak = 1;
            int currentStreak = 1;

            for (int i = 1; i < numbers.Length; i++)
            {
                // ข้ามค่าซ้ำ
                if (numbers[i] == numbers[i - 1])
                {
                    continue;
                }

                // ถ้าตัวถัดไปมากกว่าตัวก่อนหน้าอยู่ 1 แสดงว่าต่อเนื่องกัน
                if (numbers[i] == numbers[i - 1] + 1)
                {
                    currentStreak++;
                }
                else
                {
                    if (currentStreak > maxStreak)
                    {
                        maxStreak = currentStreak;
                    }
                    currentStreak = 1; // รีเซ็ต
                }
            }

            if (currentStreak > maxStreak)
            {
                maxStreak = currentStreak;
            }

            Debug.Log($"The longest consecutive sequence is: {maxStreak}");
            return maxStreak;
        }

        #endregion
    }
}