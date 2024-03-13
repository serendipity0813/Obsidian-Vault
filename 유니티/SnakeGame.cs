using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;


public enum Direction   //이동방향 열거
{
    LEFT,
    RIGHT,
    UP, 
    DOWN
}

class SnakeGame
{
    static void Main()

    {
        int gameSpeed = 100;    // 게임 속도 제어 변수 +, 숫자가 커질수록 게임이 느려짐
        int foodCount = 0;  //먹은 음식 수 카운트

        DrawWalls();        //게임 맵 생성


        Point p = new Point(4, 5, '□');     //뱀의 초기 위치를 4,5 로 잡고 심볼 출력
        Snake snake = new Snake(p, 4, Direction.RIGHT);     // p위치에 길이가 4인 뱀 생성 후 방향은 오른쪽으로 설정
        snake.Draw();       //뱀 출력

        FoodCreator foodCreator = new FoodCreator(80, 20, '●');     //맵의 가로, 세로 길이를 매개변수로 전달 
        Point food = foodCreator.CreateFood();      //음식 생성
        food.Draw();        //음식 출력

        while(true)     //게임이 끝날 때 까지 계속 반복
        {
            if (Console.KeyAvailable)       //키 입력이 들어올 때 실행
            {
                var key = Console.ReadKey(true).Key;    //입력된 키 값을 저장

                switch(key)     //저장된 키 값에 따라 분류하여 코드 실행
                {
                    case ConsoleKey.UpArrow:                //up 화살표 일 경우   
                        snake.direction = Direction.UP;     //뱀의 방향을 위로 변경
                        break;                              //switch 종료
                    case ConsoleKey.DownArrow:              
                        snake.direction = Direction.DOWN;
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.direction = Direction.LEFT;
                        break;
                    case ConsoleKey.RightArrow:
                        snake.direction = Direction.RIGHT;
                        break;
                }

            }

            if (snake.Eat(food))        //뱀이 음식을 먹었을 경우 실행되는 함수
            {
                foodCount++;            //음식 먹은 횟수 +1
                food.Draw();

                food = foodCreator.CreateFood();        //음식 새로 생성
                food.Draw();                            //음식 출력
                if (gameSpeed > 10)                     //게임 스피드가 10보다 큰 경우
                {
                    gameSpeed -= 10;                    // 게임 속도 -10(더 빠르게)

                }
                gameSpeed -= 10;                    // 게임 속도 -10(더 빠르게)
            }
            else
            {
                snake.Move();                           //만약 아니라면 이어서 게임 진행
            }


            Thread.Sleep(gameSpeed);                    //Thread 함수 호출하여 게임 속도 반영

            if(snake.IsHitTail() || snake.IsHitWall())      //만약 뱀의 머리가 몸통이나 벽과 만나면 게임 종료
            {
                break;
            }

            Console.SetCursorPosition(0, 21);                    //커서 위치 변경
            Console.WriteLine($"먹은 음식 수 : {foodCount}");    //먹은 음식 수 출력
        }

        WriteGameOver();        //게임오버 문구 출력
        Console.ReadLine();     
    }


    static void WriteText(string text, int xOffset, int yOffset)        // 문구 입력 함수
    {
        Console.SetCursorPosition(xOffset, yOffset);    //입력받은 x, y좌표로 커서 이동
        Console.WriteLine(text);                        //입력받은 text 출력
    }


    static void WriteGameOver()     //게임오버 창 출력 함수
    {
        int xOffset = 25;       //커서 위치 설정용 변수 선언
        int yOffset = 22;
        Console.SetCursorPosition(xOffset, yOffset++);      //커서 위치 변경 후 y값 +1
        WriteText("============================", xOffset, yOffset++);      //text 출력 후 y값 +1
        WriteText("         GAME OVER", xOffset, yOffset++);                //text 출력 후 y값 +1
        WriteText("============================", xOffset, yOffset++);      //text 출력 후 y값 +1

    }



    static void DrawWalls()     //게임 맵 그리는 함수
    {
        for(int i = 0; i < 81; i++) //가로 길이 설정 후 반복
        {
            Console.SetCursorPosition(i, 0);    //(i, 0) 위치로 이동 
            Console.Write("■");                //심볼 기호 출력
            Console.SetCursorPosition(i, 20);   //(i, 20) 위치로 이동 
            Console.Write("■");
        }

        for (int j = 0; j < 20; j++) //세로 길이 설정 후 반복
        {
            Console.SetCursorPosition(0, j);    //(0, j) 위치로 이동 
            Console.Write("■");                //심볼 기호 출력
            Console.SetCursorPosition(80, j);   //(0, j) 위치로 이동 
            Console.Write("■");
        }


    }

}




public class Point
{
    public int x { get; set; }  // x값 받고 기록 및 반환
    public int y { get; set; }  // y값 받고 기록 및 반환
    public char sym {  get; set; }  // sym값 받고 기록 및 반환


    public Point(int _x, int _y, char _sym) // point 클래스 생성
    {
        x = _x;     // 받은 x, y, sym 값을 클래스의 x, y, sym값에 기록
        y = _y;     
        sym = _sym;
    }

    public void Draw()  // 오브젝트 그리는 함수
    {
        Console.SetCursorPosition(x, y);    // (x,y) 로 콘솔 위치 이동 
        Console.Write(sym);     // 해당 위치에 입력받은 심볼 출력
    }

    public void Clear() // 오브젝트 지우는 함수
    {
        sym = ' ';      // 심볼을 빈칸(' ') 으로 변경
        Draw();         // 드로우 함수 호출 -> 빈칸 심볼 출력
    }

    public bool IsHit(Point p)      //x, y좌표 비교 함수 
    {
        return p.x==x && p.y==y;    //포인트의 x, y 좌표와 현재 x, y 좌표 비교 후  bool 값 반환
    }

}

public class Snake
{
    public List<Point> body;    //뱀의 형태를 리스트로 표현
    public Direction direction; //뱀의 현재 진행방향 저장

    public Snake(Point tail, int length, Direction _direction)  // 뱀의 꼬리위치, 길이, 방향 입력받음
    {
        direction = _direction;     //뱀의 이동방향을 매개변수로 부터 받음
        body = new List<Point>();   //뱀의 형태를 표현할 리스트 생성
        for (int i = 0; i < length; i++)    //뱀의 몸 길이만큼 반복
        {
            Point p = new Point(tail.x, tail.y, '□');   //Point 클래스 생성
            body.Add(p);    // 리스트에 포인트 데이터 추가
            tail.x += 1;    // tail 의 x좌표 +1
        }
    }


    public void Draw()      //뱀을 그리는 함수
    {
        foreach(Point p in body)   //body 리스트 안의 p를 반복 호출
        {
            p.Draw();   //호출한 포인트에 Draw 함수 호출하여 심볼그리기
        }
    }

    public void Move()  //뱀 위치 이동 함수
    {
        Point tail = body.First();  //body 리스트의 첫 번째 값 호출 후 tail 포인트에 삽입
        body.Remove(tail);  //리스트에서 tail값 삭제
        Point head = GetNextPoint();    //다음 이동 위치 호출 후 head포인트에 삽입
        body.Add(head);     //리스트에 head값 추가

        tail.Clear();       //tail 위치를 빈칸으로 출력
        head.Draw();        //head 위치에 심볼 출력
    }

    public Point GetNextPoint()     //다음 위치 값 반환하는 함수
    {
        Point head = body.Last();   //head 포인트에 body 리스트 중 마지막 값 호출하여 삽입
        Point nextPoint = new Point(head.x, head.y, head.sym);  // 다음위치 포인트 생성 및 현재 head 값 입력

        switch (direction)  //입력한 방향에 따른 코드 호출
        {
            case Direction.LEFT:    //왼쪽이면 다음위치 포인트의 x값을 2 감소 후 멈춤 
                nextPoint.x -= 2;
                break;
            case Direction.RIGHT:   //오른쪽이면 다음위치 포인트의 x값을 2 감소 후 멈춤
                nextPoint.x += 2;
                break;
            case Direction.UP:      //위쪽이면 다음위치 포인트의 y값을 1 감소 후 멈춤
                nextPoint.y -= 1;   //y의 값이 감소해야 커서 위치는 위로 이동
                break;
            case Direction.DOWN:    //아래쪽이면 다음위치 포인트의 x값을 2 감소후 멈춤
                nextPoint.y += 1;
                break;
        }
        return nextPoint;   //다음 위치 변환
    }

    public bool Eat(Point food) //뱀이 음식을 먹었는지 판단하는 함수
    {
        Point head = GetNextPoint();    //head포인트에 다음 위치 삽입
        if (head.IsHit(food))           //head의 좌표가 food 좌표랑 같은지 체크
        {
            food.sym = head.sym;        //food 심볼을 head심볼로 변환
            body.Add(food);             //body 리스트에 food 위치 추가
            return true;                // true값 반환
        }
        else
        {
            return false;               // 만나지 않으면 false값 반환
        }
    }

    public bool IsHitTail()     //뱀이 자신의 몸과 만나는 지 확인하는 함수
    {
        var head = body.Last();     //head 에 body 리스트 마지막 값 삽입
        for (int i = 0; i < body.Count - 2; i++)    //몸 전체 길이 -2 만큼 반복
        {
            if (head.IsHit(body[i]))     //head 값이 body 리스트 값과 같으면
            return true;        //true 반환
        }
        return false;           //만나지 않으면 false값 반환
    }

    public bool IsHitWall()     //뱀이 벽과 만나는 지 확인하는 함수
    {
        var head = body.Last();     //head 에 body 리스트 마지막 값 삽입
        if (head.x <= 0 || head.x >= 80 || head.y <= 0 || head.y >= 20)
            return true;        // head의 x, y 좌표가 벽과 만나는 지 확인 후 true 반환
        return false;           // 만나지 않으면 false 값 반환
    }
}

public class FoodCreator    //음식을 랜덤으로 만들어주는 클래스
{
    int mapWidth;   //게임맵의 가로크기 
    int mapHeight;  //게임맵의 세로크기 
    char sym;       //음식 심볼 저장용 

    Random random = new Random();   //랜덤값 생성

    public FoodCreator(int mapWidth, int mapHeight, char sym)   //FoodCreator 클래스 생성
    {
        this.mapWidth = mapWidth;   //가로, 세로, 심볼 입력받은 후 저장
        this.mapHeight = mapHeight; 
        this.sym = sym;
    }

    public Point CreateFood()   //무작위 위치에 음식 생성
    {
        int x =  random.Next(2, mapWidth - 2);  // 2 부터 가로길이-2 의 x범위중 임의로 선택
        x = x % 2 == 1 ? x : x + 1;     //2로 나눈 후 나머지가 1일 때 x값 +1 (짝수로 만들기) 
        int y = random.Next(2, mapHeight - 2);  // 2 부터 세로길이-2 의  y범위중 임의로 선택
        return new Point(x, y, sym);    //음식이 만들어질 포인트 변환
    }


}



