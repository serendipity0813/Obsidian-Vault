using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAlgorithm
{
    public class LargestRectangleInHistogram
    {
        public static void Solution()
        {
            int[] height = { 2, 1, 5, 6, 2, 3 };
            int max = 0;
            int maxValue = 0;
            int answer = 0;
            int square = 0;
            bool exist = false;


            for (int i = 0; i < height.Length; i++)
            {
                if (height[i] > max)
                {
                    maxValue = height[i];
                    max = i;
                }
            }

            while (true)
            {
                square = 0;
                for (int i = 0; i < height.Length; i++)
                {
                    if (height[i] == maxValue)
                    {
                        exist = true;
                        max = i;
                    }
                }

                if (exist)
                {
                    square += maxValue;

                    if (max > 0)
                    {
                        for (int j = max - 1; j > 0; j--)
                        {
                            if (height[j] >= maxValue)
                                square += maxValue;
                            else
                                break;
                        }
                    }


                    if (max < height.Length)
                    {
                        for (int j = max + 1; j < height.Length; j++)
                        {
                            if (height[j] >= maxValue)
                                square += maxValue;
                            else
                                break;
                        }
                    }

                    if (square > answer)
                        answer = square;

                    exist = false;
                    Console.WriteLine($"현재 높이 : {maxValue}, 현재 크기 : {square}");
                    maxValue--;

                }
                else
                {
                    maxValue--;
                }

                if (maxValue == 0)
                    break;
            }

            Console.WriteLine("최종결과값");
            Console.WriteLine(answer);
        }
    }
}
