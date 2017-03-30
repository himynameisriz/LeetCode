using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var sw = new Stopwatch();
            

            // Still understanding
            #region Hamming
            //sw.Reset();
            //var i = HammingDistance(1, 4);
            #endregion


            // Understand
            #region AddSum

            sw.Reset();
            AddSum(38);
            var x = Congruence_AddSum(65536);
            Console.WriteLine(x);

            #endregion

            #region Two sums
            //sw.Reset();

            //sw.Start();
            //var twoSum = TwoSum_InProgress(new int[] { 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789 }, 542);
            //sw.Stop();
            //Console.WriteLine($"Two sums O(log n) - Total time: {sw.ElapsedMilliseconds}ms; Answer = {twoSum[0]}, {twoSum[1]}");

            //sw.Reset();

            //sw.Start();
            //var twoSum_On = TwoSum_Works(new int[] { 230,863,916,585,981,404,316,785,88,12,70,435,384,778,887,755,740,337,86,92,325,422,815,650,920,125,277,336,221,847,168,23,677,61,400,136,874,363,394,199,863,997,794,587,124,321,212,957,764,173,314,422,927,783,930,282,306,506,44,926,691,568,68,730,933,737,531,180,414,751,28,546,60,371,493,370,527,387,43,541,13,457,328,227,652,365,430,803,59,858,538,427,583,368,375,173,809,896,370,789 }, 542);
            //sw.Stop();
            //Console.WriteLine($"Two sums O(n) - Total time: {sw.ElapsedMilliseconds}ms;  Answer = {twoSum_On[0]}, {twoSum_On[1]}"); 
            #endregion
        }

        #region AddSum
        public static int AddSum(int num)
        {
            var x = 0;
            var y = 0;
            if (num < 10) return num;
            while ((num / 10) > 0)
            {
                x = num / 10;
                y = num % 10;
                if (x + y < 10) return x + y;
                else num = x + y;
            }

            return x + y;
        }
        public static int Congruence_AddSum(int num)
        {
            return 1 + (num - 1) % 9;
        } 
        #endregion

        public static int HammingDistance(int x, int y)
        {
            int count = 0;
            // bitwise xor
            int diff = x ^ y;
            while (diff != 0)
            {
                count++;
                // int-32 
                diff = diff & (diff - 1);
            }
            return count;
        }


        public static int[] TwoSum_InProgress(int[] nums, int target)
        {
            /*Given nums = [2, 7, 11, 15], target = 9,

            Because nums[0] + nums[1] = 2 + 7 = 9,
            return [0, 1].
            */

            var sortedNums = new int[nums.Length];
            Array.Copy(nums, sortedNums, nums.Length);
            Array.Sort(sortedNums);

            var result = new int[] { 0, 0 };
            var i = 0;
            var j = nums.Length - 1;

            while (i < j)
            {
                var sum = sortedNums[i] + sortedNums[j];

                if (sum < target)
                    i++;
                else if (sum > target)
                    j--;
                else if (sum == target)
                {
                    result[0] = Array.IndexOf(nums, sortedNums[i]);
                    result[1] = Array.IndexOf(nums, sortedNums[j]);
                    return result;
                }
            }

            return result;
        }
        public static int[] TwoSum_Works(int[] nums, int target)
        {
            /*Given nums = [2, 7, 11, 15], target = 9,

            Because nums[0] + nums[1] = 2 + 7 = 9,
            return [0, 1].
            */


            var result = new int[] { 0, 0 };
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    result[0] = dict[nums[i]];
                    result[1] = i;
                    return result;
                }
                else
                    if (!dict.ContainsKey(target - nums[i]))
                    dict.Add(target - nums[i], i);
            }
            return result;
        }

    }
}