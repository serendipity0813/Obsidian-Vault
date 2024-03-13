**좋은 소프트웨어 설계는?

- 변경 사항이 기존 코드들을 방해하지 않도록 코드를 작성하기
- but 너무 양극단으로 가지 않도록 하기
- 높은 응집도와 낮은 결합도는 좋은 소프트웨어의 특징

### SOLID 원칙은 아주 중요하다!
	-> 오류에 대한 이야기가 아닌 구현방향에 대한 문제

**[![](https://blogger.googleusercontent.com/img/a/AVvXsEgAoMEFvoe7g5ln07zG_J69RsChULWtV9aXGn6HMqmF8JvmxBekJjDPHCJ9Cy-AJWW3AvOo4nWCetYEXRtWRLI3KkIorWKLTcUVn3EiXYfV987umxYajm_qtdWCwtewCACdt82IsvbZR1nGgEr0y1yoauVmX3NKpJ24STdq8HbuqjS1Da060A8xh3uRsYYx=w628-h151)](https://www.blogger.com/blog/post/edit/3583706664799492072/6850347808730267998#)**


### 소프트웨어 설계 원칙 - SOLID 원칙

SOLID 원칙은 객체 지향 프로그래밍 설계 원칙으로, 유지 보수 가능하고 확장 가능한 소프트웨어를 만들기 위한 원칙입니다.


- S: 단일 책임 원칙 (Single Responsibility Principle):

의미 : 하나의 클래스는 하나의 책임만 가져야 한다. 각 클래스는 한 가지 목적을 위해 존재하고, 변경의 이유는 하나여야 한다.

- 예시 1
    
    유니티의 컴포넌트들의 사례
    
    Transform : scale, rotation, position을 저장하고 이와 관련한 처리를 수행하는 클래스
    
    Rigidbody : 물리 시뮬레이션을 위해 사용되는 클래스
    
    MeshFilter : 3D 모델의 참조를 위해 존재하는 클래스
    
- 예시 2
    
![[Pasted image 20240114235700.png]]
    ```
    ```
```csharp
public class UnrefactoredPlayer : MonoBehaviour
    {
     [SerializeField] private string inputAxisName;
     [SerializeField] private float positionMultiplier;
     private float yPosition;
     private AudioSource bounceSfx;
     private void Start()
     {
    	 bounceSfx = GetComponent<AudioSource>();
     }
     private void Update()
     {
    	 float delta = Input.GetAxis(inputAxisName) * Time.deltaTime;
    	 yPosition = Mathf.Clamp(yPosition + delta, -1, 1);
    	 transform.position = new Vector3(transform.position.x, yPosition * positionMultiplier, transform.position.z);
     }
     private void OnTriggerEnter(Collider other)
     {
    	 bounceSfx.Play();
     }
    }
```

    
- 예시3
    
![[Pasted image 20240114235731.png]]
    ```
    
```csharp
// RequireComponent == 이 컴포넌트는 아래 세개의 컴포넌트들을 무조건 필수로 가지고 있어야 합니다.
    [RequireComponent(typeof(PlayerAudio), typeof(PlayerInput), 
    typeof(PlayerMovement))] // 대괄호를 애트리뷰트(attribute)라고 함
    public class Player : MonoBehaviour
    {
     [SerializeField] private PlayerAudio playerAudio;
     [SerializeField] private PlayerInput playerInput;
     [SerializeField] private PlayerMovement playerMovement;
     private void Start()
     {
     playerAudio = GetComponent<PlayerAudio>();
     playerInput = GetComponent<PlayerInput>();
     playerMovement = GetComponent<PlayerMovement>();
     }
    }
    public class PlayerAudio : MonoBehaviour
    {
     …
    }
    public class PlayerInput : MonoBehaviour
    {
     …
    }
    public class PlayerMovement : MonoBehaviour
    {
     …
    }
```
    

<aside> 💡 **중용의 미학** 단일 책임 원칙을 수행하기 위해서 클래스의 구조를 과도하게 정리하는 것은 위험합니다. 유니티에서는 세 가지 기준에 의해 단일책임원칙을 적용하라고 제안합니다. 기준 : 가독성 / 확장성 / 재사용성

**우리가 코드를 객체지향적으로 리팩토링하는 이유가 무엇일까요? 개발자 좋으라고!**

</aside>

- O: 개방-폐쇄 원칙 (Open-Closed Principle): 확장에는 열려 있고, 수정에는 닫혀 있어야 합니다. **기존 코드를 변경하지 않고도 새로운 기능을 추가**할 수 있도록 설계되어야 합니다. [**추상클래스 혹은 인터페이스를 사용하면 참 쉽습니다**]
    
- 예시 1
    
    ```csharp
    public class AreaCalculator 
    {
     public float GetRectangleArea(Rectangle rectangle)
     {
     return rectangle.width * rectangle.height;
     }
     public float GetCircleArea(Circle circle)
     {
     return circle.radius * circle.radius * Mathf.PI;
     }
    }
    public class Rectangle
    {
     public float width;
     public float height;
    }
    public class Circle
    {
     public float radius;
    }
    ```
    
![[Pasted image 20240114235751.png]]
    
```csharp
public abstract class Shape
    {
     public abstract float CalculateArea();
    }
    
    public class Rectangle : Shape
    {
     public float width;
     public float height;
     public override float CalculateArea()
     {
       return width * height;
     }
    }
    public class Circle : Shape
    {
     public float radius;
     public override float CalculateArea()
     {
       return radius * radius * Mathf.PI; 
     }
    }
    
    public class AreaCalculator 
    {
     public float GetArea(Shape shape)
     {
       return shape.CalculateArea();
     }
    }
```
    
    
![[Pasted image 20240114235803.png]]
    
- 예시 2
    
    ```csharp
    public interface IEnemy
    {
        void Attack();
    }
    
    public class Zombie : IEnemy
    {
        public void Attack()
        {
            // 좀비의 공격 로직
        }
    }
    
    public class Robot : IEnemy
    {
        public void Attack()
        {
            // 로봇의 공격 로직
        }
    }
    
    public class Dinosaur : IEnemy
    {
    	
    }
    
    public class EnemyManager
    {
        private List<IEnemy> enemies = new List<IEnemy>();
    
        public void AddEnemy(IEnemy enemy)
        {
            enemies.Add(enemy);
        }
    
        public void AllEnemiesAttack()
        {
            foreach(var enemy in enemies)
            {
                enemy.Attack();
            }
        }
    }
    ```
    
- L: 리스코프 치환 원칙 (Liskov Substitution Principle): **하위 클래스는 상위 클래스의 기능을 완전히 대체할 수 있어야 합니다.** 이는 상속 관계에서 어떤 클래스든지 자신의 부모 클래스로 취급될 수 있어야 함을 의미합니다. [**상속을 통해 보여줄께 완전히 달라진 나 금지**]
    
- 예시
    
![[Pasted image 20240114235824.png]]
```csharp
public class Vehicle
    {
     public float speed = 100;
     public Vector3 direction;
     public void GoForward()
     {

     }
     public void Reverse()
     {
 
     }
     public void TurnRight()
     {
    
     }
     public void TurnLeft()
     {
     
     }
     
    }
```
    
    
![[Pasted image 20240114235832.png]]
    
    리스코프 치환 원칙을 어기는 사례
    
    1. 자식 클래스를 만들면서 **피처를 제거하는 경우**
        
    2. 자식 클래스의 일부를 예외로 처리하는 경우
        
    3. 구현은 있으나 구현이 공백인 경우
        
    
```csharp
    public class Penguin : Bird{
    	public override Fly(){
    				// (1) Do nothing
    				// (2) Exception 금지
    	}
    }
```
    
    리스코프 치환 원칙 지키는 방법 :
    
    추상화 간단하게 유지 / 하위클래스에서 public 멤버 추가 지양 / 현실의 분류에 몰두 X / 컴포지션 적극적 활용
    
![[Pasted image 20240114235841.png]]
    
    ![[Pasted image 20240115000027.png]]
    
- I: 인터페이스 분리 원칙 (Interface Segregation Principle): **클라이언트는 자신이 사용하지 않는 인터페이스에 의존하지 않아야 합니다**. 여러 개의 인터페이스로 분리함으로써 클라이언트는 필요한 기능에만 의존할 수 있습니다. **[King터페이스 금지, 인터페이스는 쫌쫌따리!]**
    
- 예시
    
    ```csharp
    public interface IUnitStats
    {
        public float Health { get; set; }
        public int Defense { get; set; }
        public void Die();
        public void TakeDamage();
        public void RestoreHealth();
        public float MoveSpeed { get; set; }
        public float Acceleration { get; set; }
        public void GoForward();
        public void Reverse();
        public void TurnLeft();
        public void TurnRight();
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Endurance { get; set; }
    }
    ```
    
![[Pasted image 20240115000037.png]]
```csharp
    public interface IMovable
    {
        public float MoveSpeed { get; set; }
        public float Acceleration { get; set; }
        public void GoForward();
        public void Reverse();
        public void TurnLeft();
        public void TurnRight();
    }
    public interface IDamageable
    {
        public float Health { get; set; }
        public int Defense { get; set; }
        public void Die();
        public void TakeDamage();
        public void RestoreHealth();
    }
    public interface IUnitStats
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Endurance { get; set; }
    }

```

    
- D: 의존 역전 원칙 (Dependency Inversion Principle): **의존 관계는 추상화에 의존해야 하며, 구체화에는 의존해서는 안 됩니다**. 즉, 상위 수준의 모듈은 하위 수준의 모듈에 의존해서는 안 되며, **추상화에 의존**해야 합니다.
    
- 예시
    
    - 예시
        
    ![[Pasted image 20240115000057.png]]
        
        ```csharp
        public class Switch : MonoBehaviour
        {
            public Door door;
            public bool isActivated;
            public void Toggle()
            {
                if (isActivated)
                {
                    isActivated = false;
                    door.Close();
                }
                else
                {
                    isActivated = true;
                    door.Open();
                }
            }
        }
        public class Door : MonoBehaviour
        {
            public void Open()
            {
                Debug.Log("The door is open.");
            }
            public void Close()
            {
                Debug.Log("The door is closed.");
            }
        }
        ```
        
    ![[Pasted image 20240115000105.png]]
        
        ```csharp
        public class Switch : MonoBehaviour
        {
            public ISwitchable client;
            public void Toggle()
            {
                if (client.IsActive)
                {
                    client.Deactivate();
                }
                else
                {
                    client.Activate();
                }
            }
        }
        
        public interface ISwitchable
        {
            public bool IsActive { get; }
            public void Activate();
            public void Deactivate();
        }
        
        public class Door : MonoBehaviour, ISwitchable
        {
            private bool isActive;
            public bool IsActive => isActive;
            public void Activate()
            {
                isActive = true;
                Debug.Log("The door is open.");
            }
            public void Deactivate()
            {
                isActive = false;
                Debug.Log("The door is closed.");
            }
        }
        ```
        
    
    코드에는 정답이 없지만 어떻게 하면 더 좋은 코드가 될 지에 대해서 고민을 꾸준히 하는 것