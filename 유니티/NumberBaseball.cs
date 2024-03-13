using System;

namespace Minigame
{

    public class NumberBaseball
    {
        public static void GameStart()
        {
            //숫자맞추기(숫자야구)
            Random random = new Random();  // 랜덤 객체 생성
            int[] numbers = new int[4];  // 4개의 숫자를 저장할 배열

            //4개의 랜덤 숫자 생성하여 배열에 저장
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 10);
            }

            bool guess = false;
            int trynum = 0;  // 시도 횟수 초기화

            while (guess == false)
            {
                Console.WriteLine("4개의 숫자를 입력하세요 (1~9)");
                int[] guesses = new int[4];  // 사용자가 입력한 숫자를 저장할 배열

                for (int i = 0; i < guesses.Length; i++)
                    guesses[i] = int.Parse(Console.ReadLine());

                int strike = 0;
                int ball = 0;

                for (int i = 0; i < numbers.Length; i++)
                {
                    for (int j = 0; j < guesses.Length; j++)
                    {
                        if (numbers[i] == guesses[j])
                        {
                            if (i == j)
                                strike++;
                            else
                                ball++;

                            break;
                        }
                    }
                }

                trynum++;
                Console.WriteLine("{0} 번째 시도, {1} 스트라이크 {2} 볼 입니다.", trynum, strike, ball);

                if (strike == 4)
                {
                    Console.WriteLine($"축하합니다! {trynum}번 만에 모든 숫자를 맞추셨습니다.");
                    guess = true;
                    break;
                }

            }
        }

    }

}









    

