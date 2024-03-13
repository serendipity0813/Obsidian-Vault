using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKata13
{
    public class Level_10
    {

        public static int Solution1(int num1, int num2)
        {
            int answer = 0;
            if (num1 < -50000 || num1 > 50000)
            {
                Console.WriteLine("오류 : num1 범위초과 ");
            }
            else if (num2 < -50000 || num2 > 50000)
            {
                Console.WriteLine("오류 : num2 범위초과 ");
            }
            else
            {
                answer = num1 - num2;
                Console.WriteLine(answer);
            }

            return answer;

        }

        public static int Solution2(int num1, int num2)
        {
            int answer = 0;
            if (num1 < 0 || num1 > 100)
            {
                Console.WriteLine("오류 : num1 범위초과 ");
            }
            else if (num2 < 0 || num2 > 100)
            {
                Console.WriteLine("오류 : num2 범위초과 ");
            }
            else
            {
                answer = num1 * num2;
                Console.WriteLine(answer);
            }

            return answer;

        }

        public static int Solution3(int num1, int num2)
        {
            int answer = 0;
            if (num1 <= 0 || num1 > 100)
            {
                Console.WriteLine("오류 : num1 범위초과 ");
            }
            else if (num2 <= 0 || num2 > 100)
            {
                Console.WriteLine("오류 : num2 범위초과 ");
            }
            else
            {
                answer = num1 / num2;
                Console.WriteLine(answer);
            }

            return answer;

        }

        public static int Solution4(int age)
        {
            int answer = 0;
            int year = 2022;

            if(age <= 0 || age > 120)
            {
                Console.WriteLine("오류 : age 범위 초과");
            }
            else
            {
                answer = year - age + 1;
                Console.WriteLine("태어난 년도 : {0}",answer);
            }

            return answer;


        }

        public static int Solution5(int num1, int num2)
        {
            int answer = 0;
            if (num1 < 0 || num1 > 10000)
            {
                Console.WriteLine("오류 : num1 범위초과 ");
            }
            else if (num2 < 0 || num2 > 10000)
            {
                Console.WriteLine("오류 : num2 범위초과 ");
            }
            else
            {
                if (num1 == num2)
                    answer = 1;
                else if (num1 != num2)
                    answer = -1;

                Console.WriteLine(answer);
            }

            return answer;

        }

        public static int Solution6(int num1, int num2)
        {
            int answer = 0;
            if (num1 < -50000 || num1 > 50000)
            {
                Console.WriteLine("오류 : num1 범위초과 ");
            }
            else if (num2 < -50000 || num2 > 50000)
            {
                Console.WriteLine("오류 : num2 범위초과 ");
            }
            else
            {
                answer = num1 + num2;
                Console.WriteLine(answer);
            }

            return answer;

        }

        public static int Solution7(int num1, int num2)
        {
            int answer = 0;
            int num11 = 0;


            if (num1 <= 0 || num1 > 100)
            {
                Console.WriteLine("오류 : num1 범위초과 ");
            }
            else if (num2 <= 0 || num2 > 100)
            {
                Console.WriteLine("오류 : num2 범위초과 ");
            }
            else
            {
                num11 = num1 * 1000;
                answer = num11 / num2;  

                Console.WriteLine(answer);
            }

            return answer;

        }

        public static int Solution8(int angle)
        {
            int answer = 0;

            if (angle <= 0 || angle > 180)
            {
                Console.WriteLine("오류 : angle 범위 초과");
            }
            else if(angle > 0 && angle < 90)
            {
                answer = 1;
            }
            else if (angle == 90)
            {
                answer = 2;
            }
            else if (angle > 90 && angle < 180)
            {
                answer = 3;
            }
            else if (angle == 180)
            {
                answer = 4;
            }

            Console.WriteLine(answer);

            return answer;


        }

        public static int Solution9(int n)
        {
            int answer = 0;

            if(n <=0 || n > 1000)
            {
                Console.WriteLine("오류 : n 범위이탈");
            }
            else
            {
                for(int i = 1; i <= n; i++)
                {
                    if (i % 2 == 0)
                        answer += i;
                }
            }

            Console.WriteLine(answer);

            return answer;
        }

        public static double Solution10(int[] numbers)
        {
            double answer = 0;

            int sum = 0;

            for(int i=0; i<numbers.Length; i++)
            {
                sum += numbers[i];
            }

            answer = sum / numbers.Length;

            if(sum % numbers.Length != 0)
            {
                answer += 0.5;
            }

            Console.WriteLine(answer);

            return answer;
        }

    }
}
