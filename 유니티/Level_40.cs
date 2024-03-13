using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKata13
{
    internal class Level_40
    {
        public static string Solution31(int n)
        {
            string answer = "";
            string clap = "수박";
            string halfClap = "수";

            for (int i = 0; i < n / 2; i++)
            {
                answer += clap;
            }

            if (n % 2 == 1)
            {
                answer += halfClap;
            }

            Console.WriteLine(answer);

            return answer;
        }

        public static int Solution32(int[] a, int[] b)
        {
            int answer = 0;

            for (int i = 0; i < a.Length; i++)
            {
                answer += a[i] * b[i];
            }


            Console.WriteLine(answer);
            return answer;

        }

        public static int Solution33(int left, int right)
        {
            int answer = 0;
            int count = 0;


            for (int i = left; i <= right; i++)
            {
                count = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                        count++;

                }
                if (count % 2 == 0)
                    answer += i;
                else if (count % 2 == 1)
                    answer -= i;


            }


            Console.WriteLine(answer);
            return answer;

        }

        public static string Solution34(string s)
        {
            string answer = "";
            char[] word = s.ToCharArray();

       
            Array.Sort(word);
            Array.Reverse(word);

            for (int i = 0; i < s.Length; i++)
            {
                answer += word[i];
            }


            Console.WriteLine(answer);
            return answer;

        }


        public static long Solution35(int price, int money, int count)
        {
            long answer = 0;
            long sum = 0;

            for (int i = 1; i <= count; i++)
            {
                sum += price * i;
            }

            if (sum > money)
                answer = -(money - sum);
            else
                answer = 0;

            Console.WriteLine(answer);
            return answer;
        }


        public static bool Solution36(string s)
        {
            bool answer = true;
            int result = 0;
            string word = "";

            for (int i = 0; i < s.Length; i++)
            {
                word = s.Substring(i, 1);
                if (int.TryParse(word, out result) == false)
                {
                    answer = false;
                }
            }

            if (s.Length != 4 && s.Length != 6)
                answer = false;


            Console.WriteLine(answer);
            return answer;

        }

        public static int[,] Solution37(int[,] arr1, int[,] arr2)
        {
            int row = arr1.GetLength(0);
            int col = arr1.GetLength(1);
            int[,] answer = new int[row, col];

            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    answer[i,j] = arr1[i, j] + arr2[i,j];
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(answer[j,i]);
                }
                Console.WriteLine();
            }

            return answer;


        }

        public static void Solution38()
        {
            string[] input = new string[2];

            input = Console.ReadLine().Split(' ');
            int row = Int32.Parse(input[0]);
            int col = Int32.Parse(input[1]);

            for(int i = 0; i < col;i++)
            {
                for(int j = 0; j < row; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public static int[] Solution39(int n, int m)
        {
            int[] answer = new int[2];
            int small = 0;
            int mul = n * m;
            int min = 0;

            if(n<m)
            {
                small = n;
                min = m;
            }
            else
            {
                small = n;
                min = n;
            }


            for(int i = 1; i <= small; i++)
            {
                if(n%i == 0 && m%i ==0)
                {
                    answer[0] = i;
                }
            }

            for (int i = mul; i >= min; i--)
            {
                if (i % n == 0 && i % m == 0)
                {
                    answer[1] = i;
                }
            }


            Console.WriteLine($"최대공약수 : {answer[0]}, 최소공배수 : {answer[1]}");
            return answer;
        }

        public static int Solution40(int n)
        {
            int answer = 0;
            int count = 0;
            int temp = n;

            while(temp > 0)
            {
                temp = temp / 3;
                count++;
            }

            int[] arr = new int[count];

            for(int i=0; i<count; i++)
            {
                arr[i] = n % 3;
                n = n / 3;
            }


            temp = 1;

            for (int i = count-1; i >= 0; i--)
            {
                answer += arr[i] * temp;
                temp = temp * 3;
            }


            Console.WriteLine(answer);
            return answer;

        }



    }

}
