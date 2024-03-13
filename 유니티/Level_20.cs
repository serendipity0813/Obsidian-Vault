using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.ExceptionServices;

namespace CodeKata13
{
    public class Level_20
    {
        public static string Solution11(int num)
        {
            string answer = "";

            if (num == 0)
                answer = "Even";
            else if (num % 2 == 1 || num % 2 == -1)
                answer = "Odd";
            else if (num % 2 == 0)
                answer = "Even";
            else
                Console.WriteLine("입력값이 잘못되었습니다. int 범위의 정수를 입력해주세요!");

            Console.WriteLine($"1번 문제 : 입력된 정수값 : {num}, 구분 : {answer}");
            return answer;

        }

        public static double Solution12(int[] arr)
        {
            int sum = 0;
            double average = 0;

            if (arr.Length <= 0)
            {
                Console.WriteLine("배열의 크기를 0 이상으로 설정해주세요.");
                return 0;
            }

            else if (arr.Length > 100)
            {
                Console.WriteLine("배열의 크기를 100 이하로 설정해주세요.");
                return 0;
            }

            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    sum += arr[i];
                }

                if (arr.Length != 0)
                    average = (double)sum / arr.Length;


                Console.Write("입력배열 : [ ");
                for (int i = 0; i < arr.Length; i++)
                {

                    Console.Write($" {arr[i]} ");
                }
                Console.Write($" ]");
                Console.WriteLine();
                Console.WriteLine($"평균 : {average}");

                return average;
            }


        }

        public static int Solution13(int num)
        {
            int answer = 0;
            int[] arr = new int[10];


            for(int i=0; i<10; i++)
            {
                arr[i] = num % 10;
                num = num / 10;
                Console.WriteLine(num);
            }


            for(int i=0; i<arr.Length; i++)
            {
                answer += arr[i];
            }

            Console.WriteLine(answer);

            return answer;
        }

        public static int Solution14(int n)
        {
            int answer = 0;

            for(int i=1; i<=n; i++)
            {
                if(n%i == 0)
                {
                    answer += i;
                }
            }

            Console.WriteLine(answer);

            return answer;
        }

        public static int Solution15(int n)
        {
            int answer = 0;

            for (int i = 2; i < n; i++)
            {
                if (n % i == 1)
                {
                    answer = i;
                    break;
                }
            }

            Console.WriteLine(answer);

            return answer;
        }

        public static long[] Solution16(int x, int n)
        {
            long[] answer = new long[n];

            for(int i=1; i <= n; i++)
            {
                answer[i - 1] = x * (long)i;
            }

            for(int j=0; j<n; j++)
            {
                Console.Write(answer[j]);
            }


            return answer;
        }

        public static int[] Solution17(long n)
        {
            int[] check = new int[12];
            int count = 0;

            while(n>0)
            {
                check[count] = (int)(n % 10);
                n = n / 10;
                count++;
            }

            int[] answer = new int[count];

            for (int i=0; i<count; i++)
            {
                answer[i] = check[i];
                Console.WriteLine(answer[i]);
            }


            return answer;
        }

        public static int Solution18(string s)
        {
            int answer = 0;

            answer = Convert.ToInt32(s);


            Console.WriteLine(answer);

            return answer;

        }

     
        public static long Solution19(int n)
        {
            long answer = 0;
            int root = 1;
            long squ = 0;

            while(true)
            {
                squ = (long) root * root;
                if (n ==squ)
                {
                    answer = (long)(root + 1) * (root + 1);
                    break;
                }
                else if(squ>n) 
                {
                    answer = -1;
                    break;
                }
                else
                {
                    root++;
                }

            }

            Console.WriteLine(answer);

            return answer;
        }

        public static long Solution20(long n)
        {
            long answer = 0;
            int count = 0;
            int[] nums = new int[10];

            while(n> 0)
            {
                    nums[count] = (int)(n % 10);
                    n = n / 10;
                    count++;
            }

            for (int i = 0; i < nums.Length; i++)
            {

                Console.Write(nums[i]);
            }

            Console.WriteLine();

            Array.Sort(nums);
            Array.Reverse(nums);

            for ( int i=0; i < count; i++)
            {
                answer = answer + nums[i];
                answer = answer * 10;
                Console.WriteLine(answer);
            }

            answer = answer / 10;

            return answer;
        }
    }
}
