using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class MyTicTacToe
    {
        public static void GameStart()
        {
            string[,] map = new string[3, 3];
            int count = 1;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = $"{i}*{j}";
                }
            }

            bool match = false;

            while (match == false)
            {

                if (count % 2 == 0)
                {
                    Console.WriteLine("플레이어 2의 차례");
                }
                else
                {
                    Console.WriteLine("플레이어 1의 차례");
                }

                Console.WriteLine("\n");



                // 행, 열 입력받기
                Console.WriteLine();
                Console.Write("행 입력 : ");
                string line = Console.ReadLine();
                int line_num = int.Parse(line);
                Console.Write("열 입력 : ");
                string col = Console.ReadLine();
                int col_num = int.Parse(col);

                // 이미 입력받은 자리인지 아닌지 판단 후 지정된 자리에 마킹
                if (map[line_num, col_num] != " O " && map[line_num, col_num] != " X ")
                {
                    if (count % 2 == 1)
                    {
                        map[line_num, col_num] = " O ";
                        count++;
                    }
                    else if (count % 2 == 0)
                    {
                        map[line_num, col_num] = " X ";
                        count++;
                    }
                }
                else
                    Console.WriteLine("이미 마킹된 자리입니다.");


                // 틱택톡 판 확인
                for (int i = 0; i < map.GetLength(0); i++)
                {

                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j] + " | ");
                    }
                    Console.WriteLine("\n----------------");

                }

                //빙고 체크
                for (int i = 0; i < 3; i++)
                {
                    if (map[i, 1] == map[i, 2] && map[i, 1] == map[i, 0])
                    {
                        Console.WriteLine("빙고");
                        match = true;
                        break;
                    }

                    else if (map[1, i] == map[0, i] && map[1, i] == map[2, i])
                    {
                        Console.WriteLine("빙고");
                        match = true;
                        break;
                    }

                    else if (map[0, 2] == map[1, 1] && map[1, 1] == map[2, 0])
                    {
                        Console.WriteLine("빙고");
                        match = true;
                        break;
                    }

                    else if (map[0, 0] == map[1, 1] && map[1, 1] == map[2, 2])
                    {
                        Console.WriteLine("빙고");
                        match = true;
                        break;
                    }


                }

            }

            // 게임 마무리
            if (count % 2 == 0)
                Console.WriteLine("선공 승");
            else if (count % 2 == 1)
                Console.WriteLine("후공 승");
        }

    }
}

