using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Note
{
    internal class Week4
    {

        //인터페이스와 열거형 실습내용
        #region          
        
        public enum Month
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        //인터페이스 실습
        public interface IMovable
        {
            void Move(int x, int y);    
        }

        public class Player : IMovable
        {
            public void Move(int x, int y)
            {

            }

            public void UseItem(IUsable item)
            {
                item.Use();
            }

            public void InteractWithItem(IItemPickable item)
            {
                item.PickUp();
            }

            public void DropItem(IDroppable item)
            {
                item.Drop();
            }



        }

        public class Enemy : IMovable
        {
            public void Move(int x, int y)
            {
 
            }
        }

        public interface IUsable
        {
            void Use();
        }

        public class Item : IUsable
        {
            public string Name { get; set; }

            public void Use()
            {
                Console.WriteLine("아이템 {0}을 사용했습니다.", Name);
            }
        }

        //이중 인터페이스 실습

        public interface IItemPickable
        {
            void PickUp();
        }

        public interface IDroppable
        {
            void Drop();
        }

        public class NewItem : IItemPickable, IDroppable
        {
            public string Name { get; set; }

            public void PickUp()
            {
                Console.WriteLine("아이템 {0}을 주웠습니다.", Name);
            }
            public void Drop()
            {
                Console.WriteLine("아이템 {0}을 버렸습니다.", Name);
            }
        }

        public void UsingItem()
        {
            IMovable movableObject2 = new Enemy();
            movableObject2.Move(1, 2);

            Player player = new Player();

            Item item = new Item() { Name = "Health Position" };
            player.UseItem(item);

            NewItem item2 = new NewItem() { Name = "Sword" };

            player.InteractWithItem(item2);
            player.DropItem(item2);
        }


        //열거형 실습
        public static void SelectMonth(int month)
        {
            if (month >= (int)Month.January && month <= (int)Month.December)
            {
                Month selectMonth = (Month)month;
                Console.WriteLine("선택한 월은 {0}입니다.", selectMonth);
            }
            else
            {
                Console.WriteLine("올바른 월을 입력해주세요.");
            }
        }


        #endregion


        //예외처리 / 값형과 참조형 / 박싱과 언박싱 실습내용
        #region
        //예외처리 실습
        public class NegativeNumberException : Exception
        {
            public NegativeNumberException(string message) : base(message)
            {

            }
        }

        public static void Exception()
        {
            try     //예외처리 시작
            {
                int number = -10;

                //사용자 정의 예외 처리
                if (number < 0)
                {
                    throw new NegativeNumberException("음수는 처리할 수 없습니다.");
                }
            }
            catch (NegativeNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("예외가 발생했습니다: " + ex.Message);
            }
            finally     //생략가능, 예외 유무와 관계없이 무조건 실행
            {
                Console.WriteLine("finally 실행");
            }

        }


        //값형과 참조형 실습
        struct MyStruct
        {
            public int value;
        }

        public static void Value()
        {
            MyStruct struct1 = new MyStruct();
            struct1.value = 10;

            MyStruct struct2 = struct1;

            struct2.value = 20;

            //값형 출력 결과값, 두 값이 다름
            Console.WriteLine($"struct1 value : {struct1.value}.");
            Console.WriteLine($"struct2 value : {struct2.value}.");
        }

        class MyClass
        {
            public int Value;
        }

        public static void Reference()
        {
            MyClass obj1 = new MyClass();
            obj1.Value = 10;

            MyClass obj2 = obj1;

            obj2.Value = 20;

            //참조형 출력 결과, 두 값이 같음 -> 같은 주소 참조
            Console.WriteLine($"obj1 value : {obj1.Value}.");
            Console.WriteLine($"obj2 value : {obj2.Value}.");


        }


        //박싱, 언박싱 실습
        public static void Box()
        {
            //값형
            int x = 10;
            int y = x;
            y = 20;
            Console.WriteLine("x: " + x);
            Console.WriteLine("y: " + y);

            //참조형
            int[] arr1 = new int[] { 1, 2, 3 };
            int[] arr2 = arr1;
            arr2[0] = 4;
            Console.WriteLine("arr1[0] : " + arr1[0]);
            Console.WriteLine("arr2[0] : " + arr2[0]);

            //박싱과 언박싱
            int num1 = 10;
            object obj = num1;  //박싱
            int num2 = (int)obj;    //언박싱
            Console.WriteLine("num1 : " + num1);    //10 출력
            Console.WriteLine("num2 : " + num2);    //10 출력

        }

        #endregion


        //Delegate 와 람다 및 LINQ
        #region

        //Delegate 실습 구현
        delegate int Calculate(int x, int y);   //Delegate1 예시

        static int Add(int x, int y)        //Delegate1 연결 메소드
        {
            return x + y;
        }       

        delegate void MyDelegate(string message);       //Delegate2 예시

        static void Method1 (string message0)       //Delegate2 연결 메소드1
        {
            Console.WriteLine("Method1 : " + message0);
        }
        static void Method2(string message0)        //Delegate2 연결 메소드2
        {
            Console.WriteLine("Method2 : " + message0);
        }


        static void Delegate1()
        {
            // 메서드 등록
            Calculate calc = Add;

            // 델리게이트 사용
            int result = calc(3, 5);
            Console.WriteLine("결과: " + result);
        }       //Delegate1 실제 작동 함수

        static void Delegate2()
        {
            MyDelegate myDelegate = Method1;
            myDelegate += Method2;

            myDelegate("Hello!");

            Console.ReadKey();

        }       //Delegate2 실제 작동 함수


        //<공격 콜백 받기 예제 코드>
        // 델리게이트 선언
        public delegate void EnemyAttackHandler(float damage);          // 델리게이트 선언

        //적 클래스
        public class DEnemy        
        {
            // 공격 이벤트
            public event EnemyAttackHandler OnAttack;

            // 적의 공격 메서드
            public void Attack(float damage)
            {
                // 이벤트 호출
                OnAttack?.Invoke(damage);
                // null 조건부 연산자
                // null 참조가 아닌 경우에만 멤버에 접근하거나 메서드를 호출
            }
        }

        // 플레이어 클래스
        public class DPlayer
        {
            // 플레이어가 받은 데미지 처리 메서드
            public void HandleDamage(float damage)
            {
                // 플레이어의 체력 감소 등의 처리 로직
                Console.WriteLine("플레이어가 {0}의 데미지를 입었습니다.", damage);
            }
        }

        // 게임 실행
        public static void Attack()
        {
            // 적 객체 생성
            DEnemy enemy = new DEnemy();

            // 플레이어 객체 생성
            DPlayer player = new DPlayer();

            // 플레이어의 데미지 처리 메서드를 적의 공격 이벤트에 추가
            enemy.OnAttack += player.HandleDamage;

            // 적의 공격
            enemy.Attack(10.0f);
        }


        //람다 구현 실습
        delegate void LambdaDelegate(string message);

        public static void Lambda()
        {
            Calculate calc = (x, y) => x + y;

            //델리게이트 인스턴스 생성 및 람다식 할당
            LambdaDelegate lambdaDelegate = (message) =>
            {
                Console.WriteLine($"람다식을 통해 전달된 메시지 : {message}");
            };

            //델리게이트 호출
            lambdaDelegate("안녕하세요 람다입니다 ㅎㅎ");

            Console.ReadKey();

        }

        
        //<게임 분기 선언 예제 코드>
        //Delegate 선언
        public delegate void GameEvent();        

        //이벤트 매니저 클래스
        public class EventManager
        {
            // 게임 시작 이벤트
            public event GameEvent OnGameStart;

            // 게임 종료 이벤트
            public event GameEvent OnGameEnd;

            // 게임 실행
            public void RunGame()
            {
                // 게임 시작 이벤트 호출
                OnGameStart?.Invoke();

                // 게임 실행 로직

                // 게임 종료 이벤트 호출
                OnGameEnd?.Invoke();
            }
        }

        // 게임 메시지 클래스
        public class GameMessage
        {
            public void ShowMessage(string message)
            {
                Console.WriteLine(message);
            }
        }

        // 게임 실행
        public static void Event()
        {
            // 이벤트 매니저 객체 생성
            EventManager eventManager = new EventManager();

            // 게임 메시지 객체 생성
            GameMessage gameMessage = new GameMessage();

            // 게임 시작 이벤트에 람다 식으로 메시지 출력 동작 등록
            eventManager.OnGameStart += () => gameMessage.ShowMessage("게임이 시작됩니다.");

            // 게임 종료 이벤트에 람다 식으로 메시지 출력 동작 등록
            eventManager.OnGameEnd += () => gameMessage.ShowMessage("게임이 종료됩니다.");

            // 게임 실행
            eventManager.RunGame();
        }


        //Func 와 Action 구현 실습
        static int Square(int x, int y)
        {
            return x * y;
        }

        static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }


        public static void Func()    //func를 이용한 메소드 호출 함수
        {
            Func<int, int, int> SquareFunc = Square;
            int result = SquareFunc(3, 5);
            Console.WriteLine("결과 : " + result);

        }

        public static void Act()        //act를 이용한 메소드 호출 함수
        {
            Action<string> printAction = PrintMessage;
            printAction("Ready Action!");

        }

        //<func 와 action 예제 코드>
        // 게임 캐릭터 클래스
        class GameCharacter
        {
            private Action<float> healthChangedCallback;

            private float health;

            public float Health
            {
                get { return health; }
                set
                {
                    health = value;
                    healthChangedCallback?.Invoke(health);
                }
            }

            public void SetHealthChangedCallback(Action<float> callback)
            {
                healthChangedCallback = callback;
            }
        }

        // 게임 캐릭터 생성 및 상태 변경 감지
        public static void Status()
        {
            GameCharacter character = new GameCharacter();
            character.SetHealthChangedCallback(health =>
            {
                if (health <= 0)
                {
                    Console.WriteLine("캐릭터 사망!");
                }
            });

            // 캐릭터의 체력 변경
            character.Health = 0;
        }


        //LINQ 실습 코드 구현
        public static void LINQ()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5};

            var everyNumbers = from num in numbers
                               where num % 2 == 0
                               select num;
            foreach (var num in everyNumbers)
            {
                Console.WriteLine(num);
            }
        }

        public static void StringBuilder()
        {
            // Nullable 형식 변수 선언
            int? nullableInt = null;
            double? nullableDouble = 3.14;
            bool? nullableBool = true;

            // 값 할당 및 접근
            nullableInt = 10;
            int intValue = nullableInt.Value;

            // null 값 검사
            if (nullableDouble.HasValue)
            {
                Console.WriteLine("nullableDouble 값: " + nullableDouble.Value);
            }
            else
            {
                Console.WriteLine("nullableDouble은 null입니다.");
            }

            // null 병합 연산자 사용
            // nullableInt ?? 0과 같이 사용되며, nullableInt가 null이면 0을 반환합니다.
            int nonNullableInt = nullableInt ?? 0;
            bool nonNullableBool = nullableBool ?? false;

            Console.WriteLine("nonNullableInt 값: " + nonNullableInt);
            Console.WriteLine("nonNullableBool 값: " + nonNullableBool);

        }
        #endregion


        public static void Note4()
        {
            //Lambda();
            //Event();
            //Func();
            //Act();
            //Status();
            //LINQ();
            //StringBuilder();
            
        }




    }

}
