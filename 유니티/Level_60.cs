using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKata13
{
    internal class Level_60
    {
        public static string Solution51(int[] food)
        {
            string answer = "";
            int[] stage = new int[food.Length];
            int sum = 0;

            for(int i = 0; i < food.Length; i++)
            {
                if(i == 0)
                {
                    stage[i] = 0;
                    sum++;
                }

                else
                {
                    stage[i] = food[i] / 2;
                    sum += stage[i] * 2;
                }

            }

            for (int j = 1; j < food.Length; j++)
            {
                for (int i = 0; i < stage[j]; i++)
                {
                    answer = answer + j;
                }
            }


            answer += stage[0];

            for (int j = food.Length-1; j > 0; j--)
            {
                for (int i = 0; i < stage[j]; i++)
                {
                    answer = answer + j;
                }
            }


            Console.WriteLine(answer);

            return answer;
        }

        public static int Solution52(int a, int b, int n)
        {
            int answer = 0;
            int num = 0;

            while(true)
            {
                num += b * (n / a);
                n = b * (n / a) + n % a;

                if (n < a)
                    break;
            }

            answer = num;


            Console.WriteLine(answer);
            return answer;
        }

        public static int[] Solution53(int k, int[] score)
        {
            int[] answer = new int[score.Length];
            int[] top = new int[k];

            int pivot = k - 1;

            for (int i = 0; i < score.Length; i++)
            {


                if (score[i] > top[0])
                    top[0] = score[i];

                Array.Sort(top);

                answer[i] = top[pivot];

                if (pivot > 0)
                    pivot--;

            }


            for (int i = 0; i < score.Length; i++)
            {
                Console.WriteLine(answer[i]);
            }

                return answer;
        }

        public static string Solution54(int a, int b)
        {
            string answer = "";
            int num = -1;        //1일 부터 시작하므로

            if(a > 1)
            {
                for (int i = 1; i < a; i++)
                {
                    if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12)
                        num += 31;
                    else if (i == 2)
                        num += 29;
                    else
                        num += 30;
                }
            }

            num += b;
            num = num % 7;

            switch (num)
            {
                case 0:
                answer = "FRI";
                    break;
                case 1:
                    answer = "SAT";
                    break;
                case 2:
                    answer = "SUN";
                    break;
                case 3:
                    answer = "MON";
                    break;
                case 4:
                    answer = "TUE";
                    break;
                case 5:
                    answer = "WED";
                    break;
                case 6:
                    answer = "THU";
                    break;

            }


            Console.WriteLine(answer);
            return answer;
        }


        public static string Solution55(string[] cards1, string[] cards2, string[] goal)
        {
                string answer = "";
                int count1 = 0;
                int count2 = 0;

                for(int i = 0; i < goal.Length; i++)
                {
                    if (goal[i] == cards1[count1])
                    {
                        if(count1 < cards1.Length-1)
                        count1++;
                    }

                    else if (goal[i] == cards2[count2])
                    {

                        if (count2 < cards2.Length - 1)
                            count2++;
                    }
                 
                    else
                    {
                        answer = "No";
                        break;
                    }
                    
                   
                }

                if (answer != "No")
                    answer = "Yes";

                Console.WriteLine(answer);
                return answer;
        }

        public static int Solution56(int k, int m, int[] score)
        {
            int answer = 0;
            int price = 0;

            Array.Sort(score);
            Array.Reverse(score);

            for(int j=1; j< score.Length / m + 1; j++)
            {
                price = score[j*m-1] * m;
                answer += price;
            }



            Console.WriteLine(answer);
            return answer;
        }

        public static int[] Solution57(int[] answers)
        {
            int[] count = new int[3];
            int[] pivot = new int[3];
            int[] member1 = { 1, 2, 3, 4, 5 };
            int[] member2 = { 2, 1, 2, 3, 2, 4, 2, 5 };
            int[] member3 = { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 };
            int length = 1;
            int high = 0;
            int flag = 0;

            for (int i=0; i<answers.Length; i++)
            {
                if (answers[i] == member1[i% 5])
                    count[0]++;

                if (answers[i] == member2[i% 8])
                    count[1]++;

                if (answers[i] == member3[i% 10])
                    count[2]++;

            }

            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > high)
                {
                    high = count[i];
                    for(int j=0; j<pivot.Length; j++)
                    {
                        if (j == i)
                            pivot[j] = j + 1;
                        else
                            pivot[j] = 0;
                    }
                    length = 1;
                }
                else if (count[i] == high)
                {
                    pivot[i] = i + 1;
                    length++;
                }

            }

            int[] answer = new int[length];

            for (int i = 0; i < pivot.Length; i++)
            {
                if (pivot[i] != 0)
                {
                    answer[flag] = pivot[i];
                    flag++;
                }
            }


            for (int j = 0; j <length; j++)
            {
                Console.WriteLine(answer[j]);
            }

            return answer;

        }

        public static int Solution58(int[] nums)
        {
            int answer = 0;
            int number = 0;
            double root = 0;
            int count = 0;

            for(int i=0; i<= nums.Length-3; i++)
            {
                for (int j = i+1; j <= nums.Length - 2; j++)
                {
                    for (int k = j+1; k <= nums.Length - 1; k++)
                    {
                        count = 0;
                        number = nums[i] + nums[j] + nums[k];
                        root = Math.Sqrt(number);

                        for (int p = 2; p <= root; p++)
                        {
                            if (number % p == 0)
                            {
                                count++;
                                break;
                            }
 
                        }

                        if (count == 0)
                        {
                            Console.WriteLine(number);
                            answer++;
                        }
                           
                    }
                }
            }



            Console.WriteLine(answer);
            return answer;
        }

        public static int Solution59(int n, int m, int[] section)
        {
            int answer = 1;
            int pivot = section[0];

            for(int i=1; i<section.Length; i++)
            {
                if (section[i] > pivot + m-1)
                {
                    pivot = section[i];
                    answer++;
                }
            }


            Console.WriteLine(answer);
            return answer;
        }

        //다시 풀기
        public static long Solution60(int number, int limit, int power)
        {
            long answer = 0;
            long count = 0;
            int root = 0;

            for(int i=1; i<=number; i++)
            {
                count = 0;
                root = 0;

                for (int j = 1; j <= i; j++)
                {
                    if (j * j >= i)
                    {
                        root = j;
                        break;
                    }
                   

                }



                for (int j=1; j<=root; j++)
                {
                    if (i == j * j)
                        count++;
                    else if (i % j == 0)
                        count += 2;
                }

                Console.WriteLine(root + " " + count);

                if (count > limit)
                    answer += power;
                else
                    answer += count;

            }


            Console.WriteLine(answer);
            return answer;
        }


    }
}
