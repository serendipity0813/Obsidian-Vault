using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Note
{
    internal class Week2
    {
        public static void Note2()
        {
            // 홀수 짝수 구분하기

            Console.Write("번호를 입력하세요 : ");
            int num = int.Parse(Console.ReadLine());

            if (num % 2 == 0)
                Console.WriteLine("짝수입니다");
            else
                Console.WriteLine("홀수입니다");


            //등급출력 코드
            int score = 100;
            string rank = "";

            switch (score / 10)
            {
                case 10:
                    rank = "Challenger";
                    break;
                case 9:
                    rank = "diamond";
                    break;
                case 8:
                    rank = "platinum";
                    break;
                case 7:
                    rank = "gold";
                    break;
                case 6:
                    rank = "silver";
                    break;

                default:
                    rank = "bronze";
                    break;

            }

            Console.WriteLine(rank);


            //로그인 프로그램

            string id = "id";
            string password = "pw";

            Console.WriteLine("아이디를 입력하세요: ");
            string inputId = Console.ReadLine();
            Console.WriteLine("비밀번호를 입력하세요 ");
            string inputPw = Console.ReadLine();

            if (id == inputId && inputPw == password)
                Console.WriteLine("로그인 성공");
            else
                Console.WriteLine("로그인 실패");


            //알파벳 판별 프로그램

            Console.WriteLine("문자를 입력하세요");
            char input = Console.ReadLine()[0];

            if ((input >= 'a' && input <= 'z') || input >= 'A' && input <= 'Z')
                Console.WriteLine("알파벳입니다");
            else
                Console.WriteLine("알파벳이 아닙니다");

            //구구단
            for (int j = 1; j <= 9; j++)
            {
                for (int i = 2; i <= 9; i++)
                {
                    Console.Write(i + " x " + j + " = " + (i * j) + "\t");
                }
                Console.WriteLine();
            }


            //가위바위보
            string[] choices = { "가위", "바위", "보" };
            string playerChoice = "";
            string computerChoice = choices[new Random().Next(0, 3)];

            while (playerChoice != computerChoice)
            {
                Console.Write("가위, 바위, 보 중 하나를 선택하세요: ");
                playerChoice = Console.ReadLine();

                Console.WriteLine("컴퓨터: " + computerChoice);

                if (playerChoice == computerChoice)
                {
                    Console.WriteLine("비겼습니다!");
                }
                else if ((playerChoice == "가위" && computerChoice == "보") ||
                         (playerChoice == "바위" && computerChoice == "가위") ||
                         (playerChoice == "보" && computerChoice == "바위"))
                {
                    Console.WriteLine("플레이어 승리!");
                    computerChoice = choices[new Random().Next(0, 3)];
                }
                else
                {
                    Console.WriteLine("컴퓨터 승리!");
                    computerChoice = choices[new Random().Next(0, 3)];
                }
            }


            //숫자맞추기
            int targetNumber = new Random().Next(1, 101); ;
            int guess = 0;
            int count = 0;

            Console.WriteLine("1부터 100 사이의 숫자를 맞춰보세요.");

            while (guess != targetNumber)
            {
                Console.Write("추측한 숫자를 입력하세요: ");
                guess = int.Parse(Console.ReadLine());
                count++;

                if (guess < targetNumber)
                {
                    Console.WriteLine("좀 더 큰 숫자를 입력하세요.");
                }
                else if (guess > targetNumber)
                {
                    Console.WriteLine("좀 더 작은 숫자를 입력하세요.");
                }
                else
                {
                    Console.WriteLine("축하합니다! 숫자를 맞추셨습니다.");
                    Console.WriteLine("시도한 횟수: " + count);
                }
            }

            // 플레이어의 공격력, 방어력, 체력, 스피드를 저장할 배열
            int[] playerStats = new int[4];

            // 능력치를 랜덤으로 생성하여 배열에 저장
            Random rand = new Random();
            for (int i = 0; i < playerStats.Length; i++)
            {
                playerStats[i] = rand.Next(1, 11);
            }

            // 능력치 출력
            Console.WriteLine("플레이어의 공격력: " + playerStats[0]);
            Console.WriteLine("플레이어의 방어력: " + playerStats[1]);
            Console.WriteLine("플레이어의 체력: " + playerStats[2]);
            Console.WriteLine("플레이어의 스피드: " + playerStats[3]);


            //성적 계산 
            int[] scores = new int[5];

            for (int i = 0; i < scores.Length; i++)
            {
                Console.Write("학생 " + (i + 1) + " 의 성적을 입력하세요: ");
                scores[i] = int.Parse(Console.ReadLine());
            }

            int sum = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                sum += scores[i];
            }

            double average = (double)sum / (double)scores.Length;
            Console.WriteLine("성적 평균은 " + average + "입니다.");




            //2차원 배열을 사용하여 게임 맵을 구현 + list 연습

            int[,] map = new int[5, 5]
            {
                {1, 1, 1, 1, 1 },
                {1, 0 ,0, 0, 1 },
                {1, 0, 1, 0, 1 },
                {1, 0, 0, 0, 1 },
                {1, 1, 1, 1, 1 }
            };

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (map[i, j] == 1)
                        Console.Write("■");
                    else
                        Console.Write("□");
                }
                Console.WriteLine();
            }


            List<int> listnumbers = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                listnumbers.Add(i);
            }
            listnumbers.Remove(2);

            foreach (int number in listnumbers)
            {
                Console.WriteLine(number);
            }

            PrintLine();
            PrintLine2(20);

            int result = Add(10, 20);
            Console.WriteLine(result);
        }
        static void PrintLine()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();

        }

        static void PrintLine2(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }

        static int Add(int a, int b)
        {
            return a + b;
        }

    }

}
