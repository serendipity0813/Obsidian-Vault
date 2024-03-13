using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAlgorithm
{
    public class Floodfill
    {


        static int[,] arr2 = new int[50, 50];
        static int[,] arr = new int[3, 3]
            {
                {1, 1, 0 },
                {0, 1, 0 },
                {1, 0, 1 }
            };

        static int stop = 0;
        static int sr = 1;
        static int sc = 1;
        static int color = 2;
        static int oldcolor = arr[sr,sc];

        public static void Solution()
        {


            flood(arr, sr, sc, color);
            arr2[sr, sc] = 10;

            while (true)
            {
                stop = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (arr2[i, j] > 0 && arr2[i, j] < 10)
                        {
                            flood(arr, i, j, color);
                            arr2[i, j] = 10;
                        }
                        else
                            stop++;

                    }
                }

                if (stop == 9)
                    break;
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j]);

                }
            }


        }

        static void flood(int[,] arr, int sr, int sc, int color)
        {

            if (sr + 1 < arr.GetLength(0))
            {
                if (arr[sr + 1, sc] == oldcolor)
                {
                    arr[sr + 1, sc] = color;
                    arr2[sr + 1, sc]++;
                }
            }

            if (sr - 1 >= 0)
            {
                if (arr[sr - 1, sc] == oldcolor)
                {
                    arr[sr - 1, sc] = color;
                    arr2[sr - 1, sc]++;
                }
            }

            if (sc + 1 < arr.GetLength(1))
            {
                if (arr[sr, sc + 1] == oldcolor)
                {
                    arr[sr, sc + 1] = color;
                    arr2[sr, sc + 1]++;
                }
            }

            if (sc - 1 >= 0)
            {
                if (arr[sr, sc - 1] == oldcolor)
                {
                    arr[sr, sc - 1] = color;
                    arr2[sr, sc - 1]++;
                }
            }

        }

    }
}
