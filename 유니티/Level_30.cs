using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CodeKata13
{
    public class Level_30
    {
        public static bool Solution21(int x)
        {
            bool answer = true;
            int num = x;
            int sum = 0;

            while (x > 0)
            {
                sum += x % 10;
                x = x / 10;
            }

            if (num % sum == 0)
                answer = true;
            else
                answer = false;

            Console.WriteLine($"{num%sum}, {answer}");

            return answer;

        }

        public static long Solution22(int a, int b)
        {
            long answer = 0;
            int temp = 0;

            if (a > b)
            {
                temp = a;
                a = b;
                b = temp;
            }            


            for( int i = a; i <= b; i++)
            {
                answer += i;
            }

            Console.WriteLine(answer);


            return answer;
        }

        public static int Solution23(int num)
        {
           int answer = 0;
            int count = 0;
            long n = num;

            if(n == 1)
                answer = 0;
            else
            {
                while (answer == 0)
                {
                    if (n == 1)
                    {
                        answer = count;
                        break;
                    }
                    else if(count > 500)
                    {
                        answer = -1;
                        break;
                    }

                    else if (n % 2 == 0)
                    {
                        n = n / 2;
                        count++;
                    }
                    else if(n % 2 == 1)
                    {
                        n = n * 3 + 1;
                        count++;
                    }
 

                }
            }
        
            Console.WriteLine(answer);

            return answer;

        }

        public static string Solution24(string[] seoul)
        {
            string answer = "";
            int num = 0;
            
            for( int i = 0; i < seoul.Length; i++)
            {
                if (seoul[i] == "Kim")
                    num = i;
            }

            answer = $"김서방은 {num}에 있다";


            Console.WriteLine(answer);

            return answer;
        }
        
        public static int[] Solution25(int[] arr, int divisor)
        {

            int[] list = new int[arr.Length];

            int count = 0;
            int check = 0;

            while (count < arr.Length)
            {

                if (arr[count] % divisor == 0)
                {
                    list[check] = arr[count];
                    check++;
                }

                count++;
            }


            if (check == 0)
            {
                check++;
                count = 0;
            }

            
            int[] answer = new int[check];

            if (count == 0)
            {
                answer[0] = -1;
                Console.WriteLine(answer[0]);
            }
            else
            {

                for (int j = 0; j < count; j++)
                {
                    if (list[j] != 0)
                    {
                        answer[check - 1] = list[j];
                        check--;
                    }
                }

                Array.Sort(answer);

                for (int j = 0; j < answer.Length; j++)
                {
                    Console.Write(answer[j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }


            return answer;

        }

        public static int Solution26(int[] absolute, bool[] signs)
        {
            int answer = 123456789;
            int sum = 0;

            for (int i = 0; i < absolute.Length; i++)
            {
                if (signs[i] == true)
                {
                    sum += absolute[i];
                }
                else if (signs[i] == false)
                {
                    sum -= absolute[i];
                }
            }

            answer = sum;

            Console.WriteLine(answer);

            return answer;
        }

        public static string Solution27(string phone_number)
        {
            string answer = "";
            int length = phone_number.Length;
            string backNumber = phone_number.Substring(phone_number.Length - 4);
            string frontNumber = "";
            string star = "*";

            for(int i=0; i < length - 4; i++)
            {
                frontNumber += star;
            }

            answer = frontNumber + backNumber;

            Console.WriteLine(answer);

            return answer;
        }

        public static int Solution28(int[] numbers)
        {
            int answer = -1;
            int sum = 45;

            for(int i  = 0; i < numbers.Length; i++)
            {
                sum -= numbers[i];
            }

            answer = sum;

            Console.WriteLine(answer);
            return answer;
        }

        
        public static int[] Solution29(int[] arr)
        {
            int min = 999;
            int count = 0;
            int length = 0;

            if(arr.Length == 1)
                length = arr.Length;
            else
                length = arr.Length - 1;

            int[] answer = new int[length];

            for(int i = 0; i<arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }

            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j] != min)
                {
                    answer[count] = arr[j];
                    count++;
                }
                else if (arr[j] ==min )
                {
                    continue;
                }
                     
            }

            if(arr.Length ==1)
                answer[0] = -1;

            for (int i = 0; i < answer.Length; i++)
            {
                Console.Write(answer[i]);
            }

            Console.WriteLine();
            return answer;

        }

        public static string Solution30(string s)
        {
            string answer = " ";

            int half = s.Length / 2;

            if (s.Length % 2 == 1)
            {
                answer = s.Substring(half, 1);
            }

            else if (s.Length % 2 == 0)
            {
                answer = s.Substring(half-1, 2);

            }


            Console.WriteLine(answer);


            return answer;
        }


    }
}
