using System;
using System.Collections.Generic;


namespace Note
{
    internal class Week3
    {
        //구조체, 클래스 등 예시 모음
        #region
        //구조체 예시
        struct SPerson
        {
            //구조체 예시
            public string Sname;
            public int Sage;

            public void SPrintInfo()
            {
                Console.WriteLine($"Name: {Sname}, Age: {Sage}");
            }
        }

        //클래스 예시
        class Person
        {
            //필드 선언 예시 
            public string Cname;
            public int Cage;
            private string Pname;
            private int Page;

            //프로퍼티 사용 예시
            public string PNAME //Fname의 기능을 외부에서 호출하지만 사용은 FNAME 으로
            {
                get { return Pname; }   //값을 반환 - 읽기 전용
                set { Pname = value; }  //값을 받아와서 저장 - 쓰기 전용
            }

            public int PAGE
            {
                get { return Page; }
                set { Page = value; }
            }


            //접근제한자 예시
            //public string Nickname;         // 외부에서 자유롭게 접근 가능
            //private int Phone;           // 같은 클래스 내부에서만 접근 가능
            //protected string Address;  // 같은 클래스 내부와 상속받은 클래스에서만 접근 가능


            //디폴트 생성자
            public Person()
            {
                Cname = "UnKnown";
                Cage = 0;
            }

            //매개변수를 받는 생성자
            public Person(string newName, int newAge)
            {
                Cname = newName;
                Cage = newAge;
            }

            //메소드 예시
            public void CPrintInfo()
            {
                Console.WriteLine($"Name: {Cname}, Age : {Cage}");
            }

        }


        // 부모 클래스 (클래스 상속 예시)
        public class Animal
        {
            public string Aname { get; set; }
            public int Aage { get; set; }

            public void Eat()
            {
                Console.WriteLine("Animal is eating.");
            }

            public void Sleep()
            {
                Console.WriteLine("Animal is sleeping.");
            }
        }

        // 자식 클래스
        public class Dog : Animal
        {
            public void Bark()
            {
                Console.WriteLine("Dog is bark");
            }

        }

        public class Cat : Animal
        {
            public void Meow()
            {
                Console.WriteLine("Cat is meow");
            }

            //public void Sleep() //부모 클래스의 메소드를 숨기고 재정의
            //{
            //    Console.WriteLine("Cat Sleep");
            //}
        }


        //클래스 상속 및 버츄얼 메소드 예시
        public class Unit
        {
            // 버추얼 메소드 예시
            public virtual void Move() //자식이 재정의를 할 수 있다
            {
                Console.WriteLine("두발로 걷기");
            }
            // 버추얼 -> 실형태가 다를 수 있으니 직접 가서 재정의 확인해봐라

            public void Attack()
            {
                Console.WriteLine("Unit 공격");
            }
        }

        public class Marine : Unit
        {

        }

        public class Zergling : Unit
        {
            public override void Move()
            {
                Console.WriteLine("네발로 걷기");
            }
        }


        //추상클래스 예시 - 권한의 차이, 강제성
        abstract class Shape
        {
            public abstract void Draw();
        }

        class Circle : Shape
        {
            public override void Draw()
            {
                Console.WriteLine("Drawing a Circle");
            }
        }

        class Square : Shape
        {
            public override void Draw()
            {
                Console.WriteLine("Drawing a Circle");
            }
        }

        class Triangle : Shape
        {
            public override void Draw()
            {
                Console.WriteLine("Drawing a Circle");
            }
        }

        //제너릭 예시
        class Stack<T> //선입후출 구조
        {

            private T[] elements;
            private int top;

            public Stack()
            {
                elements = new T[100];
                top = 0;
            }

            public void Push(T item)
            {
                elements[top++] = item;
            }

            public T Pop()
            {
                return elements[--top];
            }


        }


        //제너릭 2개 사용 예시
        class Pair<T1, T2>  //int
        {
            public T1 First { get; set; }
            public T2 Second { get; set; }

            public Pair(T1 first, T2 second)
            {
                First = first;
                Second = second;
            }

            public void Display()
            {
                Console.WriteLine($"First: {First}, Second: {Second}");
            }

        }

        // out 키워드 사용 예시
        static void Divide(int a, int b, out int quotient, out int remainder)
        {
            quotient = a / b; ;
            remainder = a % b; ;
        }

        // ref 키워드 사용 예시
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        #endregion  

        public static void Note3()
        {
            //구조체 사용
            SPerson sperson1;
            sperson1.Sname = "structure person";
            sperson1.Sage = 11;
            sperson1.SPrintInfo();

            //클래스 사용 예시
            Person person1 = new Person(); // 클래스의 디폴트 인스턴스 생성
            Person person2 = new Person("Class person", 22); // 매개변수를 받는 생성자 호출
            person2.CPrintInfo(); // 메소드 호출


            //프로퍼티 사용 예시
            Person person = new Person();
            person.PNAME = "Property person";   // FNAME 프로퍼티에 값 설정
            person.PAGE = 33;        // FAGE 프로퍼티에 값 설정

            Console.WriteLine($"Name: {person.PNAME}, Age: {person.PAGE}");  // FNAME과 FAGE 프로퍼티 값 호출


            //클래스 상속 예시1
            Dog dog = new Dog();
            dog.Aname = "animal dog";
            dog.Aage = 44;

            dog.Eat();
            dog.Sleep();
            dog.Bark();

            //클래스 상속 예시2
            Cat cat = new Cat();
            cat.Aname = "animal cat";
            cat.Aage = 55;

            cat.Eat();
            cat.Sleep();
            cat.Meow();

            //버추얼 메소드 사용 코드
            Marine marine = new Marine();
            marine.Move();
            marine.Attack();

            Zergling zergling = new Zergling();
            zergling.Move();
            zergling.Attack();

            // unit은 참조의 형태, 마린과 저글링은 실제 형태
            List<Unit> list = new List<Unit>();
            list.Add(new Marine());
            list.Add(new Zergling());

            foreach (Unit unit in list)
            {
                unit.Move();
            }

            //추상클래스 사용 코드
            List<Shape> Slist = new List<Shape>();
            Slist.Add(new Circle());
            Slist.Add(new Triangle());
            Slist.Add(new Square());

            foreach (Shape shape in Slist)
            {
                shape.Draw();
            }

            //제너릭 예시 코드
            Stack<int> intStack = new Stack<int>();
            intStack.Push(1);
            intStack.Push(2);
            intStack.Push(3);
            Console.WriteLine(intStack.Pop());

            Pair<int, string> pair1 = new Pair<int, string>(1, "One");
            pair1.Display();

            Pair<double, bool> pair2 = new Pair<double, bool>(3.14, true);
            pair2.Display();

            //out 사용 코드
            int quotient, remainder;
            Divide(7, 3, out quotient, out remainder);
            Console.WriteLine($"{quotient}, {remainder}");

            //ref 사용 코드
            int x = 1, y = 2;
            Swap(ref x, ref y);
            Console.WriteLine($"{x} {y}");

        }





    }

  

} 






    

