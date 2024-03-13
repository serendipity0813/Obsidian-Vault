using System;
using System.Collections.Generic;


namespace Note
{
    public class Info
    {
        public string userName;
        public string job;
        public string level;

        public void IntroduceCharacter()
        {
            Console.WriteLine("이름 : " + userName);
            Console.WriteLine("직업 : " + job);
            Console.WriteLine("레벨 : " + level);
        }
    }
    public class Basic
    {
        public static void Note1()
        {
            Practice1();
            Practice2();
            Practice3();
            Practice4();
            Practice5();
            Practice6();
            Practice7();
            Practice8();
        }
        static void Practice1() //연습문제 1번
        {
            //변수설정 및 데이터 입력
            int level = 60;
            int stack = 4;

            float percent = 85.5f;
            float velocity = 276.14f;

            string nickname = "arcana gosu";
            string explanation = "이구역타로장인";

            Console.WriteLine("연습문제 1번 결과값");
            Console.WriteLine("\n변수설정 및 데이터 입력 결과");
            Console.WriteLine(level);
            Console.WriteLine(stack);
            Console.WriteLine(percent);
            Console.WriteLine(velocity);
            Console.WriteLine(nickname);
            Console.WriteLine(explanation);


            //숫자를 숫자로 형변환
            int iTen = 10;
            float fTen = (float)iTen;

            float fFive = 5.5f;
            int iFive = (int)fFive;

            Console.WriteLine("\n숫자 -> 숫자 형변환 결과");
            Console.WriteLine(iTen);
            Console.WriteLine(fTen);
            Console.WriteLine(fFive);
            Console.WriteLine(iFive);

            //숫자를 문자로 형변환
            int n = 10;
            float f = 0.5f;

            string nstr = n.ToString();
            string fstr = f.ToString();

            Console.WriteLine("\n숫자 -> 문자 형변환 결과");
            Console.WriteLine(n);
            Console.WriteLine(f);
            Console.WriteLine(nstr);
            Console.WriteLine(fstr);


            //문자를 숫자로 형변환
            string strTen = "10";
            string strFive = "5";

            int Ten;
            int Five;

            int.TryParse(strTen, out Ten);
            int.TryParse(strTen, out Five);


            Console.WriteLine("\n문자 -> 숫자 형변환 결과");
            Console.WriteLine(strTen);
            Console.WriteLine(strFive);
            Console.WriteLine(strTen);
            Console.WriteLine(strFive);

        }

        static void Practice2() // 연습문제 2번
        {
            int ten = 10;
            int plus = ten + 7;
            int minus = ten - 3;
            int mul1 = ten * 2;
            float mul2 = (float)ten * 1.5f;
            float div1 = ten / 3;
            int div2 = ten % 4;

            Console.WriteLine("연습문제 2번 결과값\n");

            Console.WriteLine("\n1) 숫자의 사칙연산 결과값");
            Console.WriteLine(ten);
            Console.WriteLine(plus);
            Console.WriteLine(minus);
            Console.WriteLine(mul1);
            Console.WriteLine(mul2);
            Console.WriteLine(div1);
            Console.WriteLine(div2);

            Console.WriteLine("\n2) 문자의 계산 결과값");
            string name = "partlyclean";
            int year = 2023;

            string introduce = "안녕하세요. 제 이름은 \"" + name + "\" 입니다.";
            Console.WriteLine(introduce);

            string thisYear = "올해는 '" + year + "년' 입니다.";
            Console.WriteLine(thisYear);

            Console.WriteLine("\n3) 논리 연산 결과값");
            int num = 10;
            bool result_1 = num == 10;
            bool result_2 = num != 11;
            bool result_3 = num < 20;
            bool result_4 = num > 5;

            Console.WriteLine(result_1);
            Console.WriteLine(result_2);
            Console.WriteLine(result_3);
            Console.WriteLine(result_4);


        }

        static void Practice3() // 연습문제 3번
        {
            Console.WriteLine("연습문제 3번 결과값\n");


            string input = Console.ReadLine();
            Console.WriteLine("입력받은 데이터는" + input + "입니다.\n");


            Console.WriteLine("\n1) 입력받은 데이터가 숫자인지, 불리언인지, 문자열인지 확인");
            string input1 = Console.ReadLine();
            int num;
            bool bo;

            bool check_int = int.TryParse(input1, out num);
            bool check_bool = bool.TryParse(input1, out bo);

            Console.WriteLine("\n1) 입력받은 데이터가 숫자인지, 불리언인지, 문자열인지 확인");

            if (check_int)
                Console.WriteLine("숫자입니다\n");

            else if (check_bool)
                Console.WriteLine("불리언입니다");

            else
                Console.WriteLine("문자열입니다");



            Console.WriteLine("\n2) 100보다 큰지 작은지 확인");
            string input2 = Console.ReadLine();

            int num2;
            bool check_int2 = int.TryParse(input2, out num2);


            if (check_int2)
            {
                if (num2 >= 100)
                    Console.WriteLine(num2 + "는 100보다 크거나 같은 수\n");

                else
                    Console.WriteLine(num2 + "는 100보다 작은 수\n");
            }

            else
                Console.WriteLine("숫자가 아닙니다.\n");


            Console.WriteLine("\n3) 짝수인지 홀수인지 확인");

            string input3 = Console.ReadLine();

            int num3;
            bool check_int3 = int.TryParse(input, out num3);

            if (check_int3)
            {
                int remain = num3 % 2;

                if (remain == 0)
                    Console.WriteLine("짝수입니다");

                else
                    Console.WriteLine("홀수입니다");

            }

            else
                Console.WriteLine("숫자가 아닙니다.\n");

        }
        
        static void Practice4() // 연습문제 4번
        {
            Console.WriteLine("연습문제 4번 결과값\n");

            Console.WriteLine("\n첫 번째 숫자 입력\n");

            string input1 = Console.ReadLine();

            Console.WriteLine("\n두 번째 숫자 입력\n");

            string input2 = Console.ReadLine();

            int num1, num2;
            bool check_int1 = int.TryParse(input1, out num1);
            bool check_int2 = int.TryParse(input2, out num2); // 숫자 여부 체크

            if (check_int1 && check_int2)
            {
                Console.WriteLine("\n두 데이터는 모두 숫자입니다.\n");
                if (num1 == num2)
                    Console.WriteLine(num1 + " 와(과) " + num2 + " 은(는) 같습니다.\n");

                else if (num1 >= num2)
                    Console.WriteLine(num1 + " 은(는) " + num2 + " 보다 큽니다.\n");

                else if (num2 >= num1)
                    Console.WriteLine(num1 + " 은(는) " + num2 + " 보다 작습니다.\n");

                else
                    Console.WriteLine("\n두 수를 비교할 수 없습니다. 숫자를 다시 입력해 주십시오,\n");

            }

            else if (check_int1 || check_int2)
                Console.WriteLine("\n하나의 데이터만 숫자입니다. 두 개의 숫자를 입력하세요! \n");

            else
                Console.WriteLine("\n두 데이터 모두 숫자가 아닙니다. 두 개의 숫자를 입력하세요!\n");
        }

        static void Practice5() // 연습문제 5번
        {

            Console.WriteLine("연습문제 4번 결과값 \n");

            Console.WriteLine("Q1. 대한민국의 수도는 어디일까요? \n");
            Console.WriteLine("1. 인천  2. 평창  3. 서울  4. 부산\n");

            string answer = Console.ReadLine();

            int check;
            bool check_int = int.TryParse(answer, out check);

            if (check_int)
            {
                switch (check)
                {
                    case 1:
                        Console.WriteLine(" \n땡! \n");
                        break;

                    case 2:
                        Console.WriteLine(" \n땡! \n");
                        break;

                    case 3:
                        Console.WriteLine(" \n정답입니다! \n");
                        break;

                    case 4:
                        Console.WriteLine(" \n땡! \n");
                        break;
                }

            }
            else
                Console.WriteLine("\n숫자가 아닙니다!");



            Console.WriteLine("\n\nQ2. 어디로 여행을 가고싶나요? \n");
            Console.WriteLine(" 1.제주도   2.코타키나발루   3.싱가포르   4.태국 \n");

            string answer2 = Console.ReadLine();

            int check2;
            bool check2_int = int.TryParse(answer2, out check2);

            if (check2_int)
            {
                if (check2 != 1 && check2 != 2 && check2 != 3 && check2 != 4)
                    Console.WriteLine("\n 1~4 사이의 숫자를 입력해 주십시오. \n");

                else
                {
                    switch (check2)
                    {
                        case 1:
                            Console.WriteLine(" \n제주도는 한국의 섬으로 비교적 방문이 쉽고 다양한 놀거리/먹거리가 준비되어 있습니다. \n");
                            break;

                        case 2:
                            Console.WriteLine(" \n 코타키나발루는 말레이시아 사바주의 주도로, 말레이시아 동부 보르네오섬 최대의 도시입니다. \n");
                            break;

                        case 3:
                            Console.WriteLine(" \n싱가포르는 동남아시아, 말레이 반도의 끝에 위치한 섬나라이자 항구 도시로 이루어진 도시 국가입니다.\n");
                            break;

                        case 4:
                            Console.WriteLine(" \n태국은 중국문화, 말레이문화, 불교문화, 힌두문화, 이슬람 문화가 혼재되어 있습니다. 불교적인 모습을 많이 띄지만, 문화 자체는 색다르고 스펙트럼이 넓은 형태를 띄고 있어요.\n");
                            break;
                    }
                }

            }

            else
                Console.WriteLine("\n숫자가 아닙니다.\n");

        }

        static void Practice6() // 연습문제 6번
        {
            Console.WriteLine("연습문제 6번 결과값\n");

            Console.WriteLine("\n1) 구구단 만들기\n");

            int two = 2;
            for (int i = 1; i <= 9; i++)
            {
                Console.WriteLine(two + " * " + i + " = " + two * i);
            }

            Console.WriteLine("\n출력하고 싶은 구구단을 몇 단 입니까?\n");
            string input = Console.ReadLine();

            int num;
            bool check_int1 = int.TryParse(input, out num);

            if (check_int1)
            {
                for (int j = 1; j <= 9; j++)
                {
                    Console.WriteLine(num + " * " + j + " = " + num * j);
                }
            }
            else
                Console.WriteLine("\n숫자를 입력해주세요!\n");


            Console.WriteLine("\n2) 피보나치 수열 구하기 \n");

            int fibo1 = 1;
            int fibo2 = 1;

            Console.Write(fibo1);

            for (int i = 1; i <= 9; i++)
            {
                Console.Write(" " + fibo2);
                fibo2 = fibo1 + fibo2;
                fibo1 = fibo2 - fibo1;

            }

            Console.WriteLine("\n몇 개의 피보나치 수열을 출력하고 싶으신가요? \n");
            string fiboinput = Console.ReadLine();

            bool check_int = int.TryParse((string)fiboinput, out num);
            int sfibo1 = 1;
            int sfibo2 = 1;

            if (check_int)
            {
                if (num >= 47)
                    Console.WriteLine("숫자가 너무 큽니다. 47미만의 숫자를 입력해주세요\n");

                else if (num < 0)
                    Console.WriteLine("양수를 입력해주세요\n");

                else
                {
                    Console.Write(sfibo1);

                    for (int j = 1; j <= num; j++)
                    {
                        Console.Write(" " + sfibo2);
                        sfibo2 = sfibo1 + sfibo2;
                        sfibo1 = sfibo2 - sfibo1;

                    }

                    Console.Write("\n");
                }

            }
            else
                Console.WriteLine("\n숫자를 입력해주세요!\n");



        }

        static void Practice7() // 연습문제 7번
        {
            Console.WriteLine("연습문제 7번 결과값\n");
            Console.WriteLine("\n이름 입력하기\n");

            Console.WriteLine("\n이름을 입력해주세요 (3~10글자) \n");
            string name = Console.ReadLine();

            int length = name.Length;
            if (length < 3 || length > 10)
                Console.WriteLine("\n이름을 확인해주세요\n");
            else
                Console.WriteLine("\n제 이름은 " + name + " 입니다\n");

            bool success = false;

            do
            {
                Console.Clear();
                Console.WriteLine("\n이름을 입력해주세요 (3~10글자) \n");
                string name2 = Console.ReadLine();

                int length2 = name2.Length;
                if (length2 < 3 || length2 > 10)
                    Console.WriteLine("\n이름을 확인해주세요\n");
                else
                {
                    Console.WriteLine("\n제 이름은 " + name + " 입니다\n");
                    success = true;

                }

            }
            while (!success);
        }

        static void Practice8() // 배열, 함수, 클래스와 객체 
        {
            //배열 파트 학습내용 코드 정리
            Console.WriteLine("\n[ 배열 학습내용 ]\n");

            int[] years = new int[24];

            Console.WriteLine("\nfor문을 활용한 배열\n");

            for (int i = 0; i < 24; i++)
            {
                years[i] = 2000 + i;
                Console.WriteLine(years[i]);
            }

            Console.WriteLine("\nforeach문을 활용한 배열\n");

            foreach (int year in years)
            {
                Console.WriteLine(year);
            }

            string[] game = new string[] { "League of Legends", "메이플 스토리", "디아블로" }; // 생성과 동시에 초기화


            //함수파트 학습내용 코드 정리

            Console.WriteLine("\n[ 함수 학습내용 ]\n");

            int hp = 10;
            int point = 0;

            DisplayMyInfo(60, "이구역타로장인", "아르카나");

            Console.WriteLine("\n몬스터 사냥");
            attack(1);
            attack(2);
            attack(3);
            attack(2);
            attack(1);
            attack(2);
            attack(3);

            Console.WriteLine("\n경험치 획득");
            point = Getpoint(77);

            void attack(int damage)
            {
                if (hp < 1)
                    return;

                hp -= damage;
                Console.WriteLine("데미지 : " + damage + " 현재 체력 : " + hp);


            }

            int Getpoint(int bonus)
            {
                Console.WriteLine("\n" + bonus + " 경험치를 획득합니다\n");

                return bonus;
            }

            void DisplayMyInfo(int level, string name, string Class)
            {
                Console.WriteLine("캐릭터 정보 확인\n");
                Console.WriteLine("레벨 : " + level + "\n이름 : " + name + "\n직업 : " + Class + "\n");
            }


            Console.WriteLine("\n[클래스와 객체 학습내용 ]\n");

            Info myCharacter = new Info();
            myCharacter.userName = "이구역사격장인";
            myCharacter.job = "건슬링어";
            myCharacter.level = "60";

            myCharacter.IntroduceCharacter();



        }

    }
}
