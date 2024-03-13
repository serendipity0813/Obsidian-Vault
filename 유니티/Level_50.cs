using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKata13
{
    internal class Level_50
    {
        public static string Solution41(string s)
        {
            string answer = "";
            int length = 0;


            for (int j = 0; j < s.Length; j++)
            {
                if (s[j] == ' ')
                {
                    answer += s[j];
                    length = 0;
                }
                else if(length % 2 == 0)
                {
                    answer += s[j].ToString().ToUpper();
                    length++;
                }
                else if (length % 2 ==1)
                {
                    answer += s[j].ToString().ToLower();
                    length++;
                }

            }


            Console.WriteLine(answer);  
            return answer;
        }

        public static int Solution42(int[] number)
        {
            int answer = 0;

            for(int i = 0; i < number.Length; i++)
            {
                for (int j = i+1; j < number.Length; j++)
                {
                    for (int k = j+1; k < number.Length; k++)
                    {
                        if (number[i] + number[j] + number[k] == 0)
                            answer++;
                    }
                }
            }


            Console.WriteLine(answer);
            return answer;
        }

        public static int Solution43(string t, string p)
        {
            int answer = 0;
            long numt = 0;
            long nump = 0;
            nump = Int64.Parse(p);

            for (int i = 0; i< t.Length-p.Length+1; i++)
            {
                numt = Int64.Parse(t.Substring(i, p.Length));
                if (numt <= nump)
                    answer++;
            }



            Console.WriteLine(answer);
            return answer;
        }

        public static int Solution44(int[,] sizes)
        {
            int answer = 0;
            int largebig = 0;
            int smallbig = 0;
            int temp = 0;
            int length = sizes.GetLength(0);

            for(int i = 0; i < length; i++)
            {
                if (sizes[i,0] < sizes[i,1])
                {
                    temp = sizes[i, 0];
                    sizes[i,0] = sizes[i,1];
                    sizes[i,1] = temp;
                }

                if (sizes[i,0] > largebig)
                    largebig = sizes[i,0];

                if (sizes[i, 1] > smallbig)
                    smallbig = sizes[i,1];
            }
            Console.WriteLine(largebig);
            Console.WriteLine(smallbig);

            answer = largebig * smallbig;

            Console.Write(answer);
            return answer;
        }

        public static string Solution45(string s, int n)
        {
            string answer = "";
            char alp = ' ';
            int num = 0;

            for (int i = 0; i < s.Length; i++)
            {
                alp = s[i];
                if(alp != ' ')
                {
                    num = (int)alp;
                    if(num >= 65 && num <= 90)
                    {
                        num += n;
                        if(num > 90)
                           num -= 26;

                    }
                    else if (num >= 97 && num <= 122)
                    {
                        num += n;
                        if (num > 122)
                            num -= 26;

                    }

                    alp = (char)num;
                    answer += alp;
                }
                else
                    answer += alp;
             
            }

            Console.WriteLine(answer);
            return answer;
        }

        public static int Solution46(string s)
        {
            int answer = 0;
            string ReplaceS= s.Replace("one", "1");
            ReplaceS = ReplaceS.Replace("two", "2");
            ReplaceS = ReplaceS.Replace("three", "3");
            ReplaceS = ReplaceS.Replace("four", "4");
            ReplaceS = ReplaceS.Replace("five", "5");
            ReplaceS = ReplaceS.Replace("six", "6");
            ReplaceS = ReplaceS.Replace("seven", "7");
            ReplaceS = ReplaceS.Replace("eight", "8");
            ReplaceS = ReplaceS.Replace("nine", "9");
            ReplaceS = ReplaceS.Replace("zero", "0");
            answer = Int32.Parse(ReplaceS);



            Console.WriteLine(answer);
            return answer;
        }
       
        public static string[] Solution47(string[] strings, int n)
        {
            string[] answer = new string[strings.Length];
            string[] alp = new string[strings.Length];

            Array.Sort(strings);

            for(int i=0; i < strings.Length; i++)
            {
                alp[i] = strings[i][n] + strings[i];
            }

           Array.Sort(alp);

            for (int i = 0; i < strings.Length; i++)
            {
                answer[i] = alp[i].Substring(1);
            }

            for (int i = 0; i < strings.Length; i++)
            {
                Console.WriteLine(answer[i]);
            }

            return answer;
        }

        public static int[] Solution48(int[] array, int[,] commands)
        {

            int col = commands.GetLength(0);
            int[] answer = new int[col];

            for (int i = 0; i<col; i++)
            {
                int start = commands[i, 0];
                int end = commands[i, 1];


                int length = end - start + 1;

                int[] newarr = new int[length];

                for(int j=0; j<length; j++)
                {
                    newarr[j] = array[j + start-1];
                }

                Array.Sort(newarr);

                answer[i] = newarr[commands[i, 2] - 1];

            }

            for(int j=0; j<answer.Length; j++)
            {
                Console.Write(answer[j]);
            }

            return answer;
        }

        public static int[] Solution49(int[] numbers)
        {
            List<int> answer = new List<int>();
            int check= 0;

            for (int i = 0; i < numbers.Length-1; i++)
            {               
                for (int j = i+1; j < numbers.Length; j++)
                {
                    check = numbers[i] + numbers[j];
                    if(answer.Contains(check) == false)
                    {
                        answer.Add(check);
                    }
  
                }   
             
            }

            answer.Sort();
            return answer.ToArray();
        }

        public static int[] Solution50(string s)
        {
            int[] answer = new int[s.Length];
            answer[0] = -1;
            int num = 0;

            for(int i=1; i<s.Length; i++)
            {
                num = -1;
                for (int j = 0; j < i; j++)
                {
                    if (s[i] == s[j])
                        num = i-j;
                }
                answer[i] = num;
            }
            for (int i = 0; i < s.Length; i++)
            {
                Console.Write(answer[i]);
            }
                

            return answer;
        }

    }
}
