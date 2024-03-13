### 큐란 무엇일까요?

큐는 **FIFO (First In First Out)** 방식으로 작동하는 자료 구조입니다. 먼저 들어온 데이터가 먼저 나가는 방식으로 생각하면 됩니다. 마치 줄 서서 기다리는 것과 비슷하다고 볼 수 있습니다.

### C# 큐의 주요 함수

- **Enqueue(item):** 큐의 맨 뒤에 새로운 항목을 추가합니다.
- **Dequeue():** 큐의 맨 앞 항목을 제거하고 반환합니다.
- **Peek():** 큐의 맨 앞 항목을 제거하지 않고 반환합니다.
- **Count:** 큐에 저장된 항목의 개수를 반환합니다.
- **Clear():** 큐에 저장된 모든 항목을 제거합니다.

### 간단한 예제

다음 예제는 큐를 사용하여 숫자를 저장하고 꺼내는 방법을 보여줍니다.


```csharp
// 큐를 생성합니다.
Queue<int> queue = new Queue<int>();

// 큐에 숫자를 추가합니다.
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);

// 큐의 크기를 확인합니다.
Console.WriteLine(queue.Count); // 3

// 큐의 맨 앞 항목을 제거하고 출력합니다.
int number = queue.Dequeue();
Console.WriteLine(number); // 1

// 큐의 맨 앞 항목을 확인합니다.
number = queue.Peek();
Console.WriteLine(number); // 2

// 큐에 남은 항목을 모두 제거합니다.
queue.Clear();
```

