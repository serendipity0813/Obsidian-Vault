using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAlgorithm
{
    public class LongestIncreasingSubsequence
    {
        public static void Solution()
        {
            int[] num = { 10, 9, 2, 5, 3, 7, 101, 18 };
            //int[] num = { 0, 1, 0, 3, 2, 3};
            //int[] num = { 7, 7, 7, 7, 7, 7};
            //int[] num = { 2, 10, 3, 18, 5, 7, 101, 9 };
            //int[] num = { 46, 1, 99, 23, 18, 94, 26, 48, 87, 51, 65, 90, 88, 15 };

            start(num);
        }

        public static void start(int[] num)
        {

            int key = 0;
            int maxLength = 0;

            for (int j = 0; j < num.Length; j++)
            {
                int min1 = num[j];
                int min2 = num[j];

                int length = 1;
                if (num.Length - j <= maxLength)
                    break;

                for (int i = j + 1; i < num.Length; i++)
                {
                    key++;
                    if (num[i] < min2 && num[i] > min1)
                    {
                        min2 = num[i];

                    }
                    else if (num[i] > min2)
                    {
                        length++;
                        min1 = min2;
                        min2 = num[i];
                    }

                }

                if (length > maxLength)
                    maxLength = length;

            }

            Console.WriteLine($"가장 긴 길이 : {maxLength}");
            Console.WriteLine($"횟수 : {key}");

        }
    
    }
}
