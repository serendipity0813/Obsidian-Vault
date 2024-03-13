Stack은 **LIFO (Last In First Out)** 방식으로 작동하는 자료 구조입니다. 먼저 들어온 데이터가 나중에 나가는 방식으로 생각하면 됩니다. 마치 접시를 쌓아 올리는 것과 비슷하다고 볼 수 있습니다.

### C# Stack의 주요 함수

- **Push(item):** 스택의 맨 위에 새로운 항목을 추가합니다.
- **Pop():** 스택의 맨 위 항목을 제거하고 반환합니다.
- **Peek():** 스택의 맨 위 항목을 제거하지 않고 반환합니다.
- **Count:** 스택에 저장된 항목의 개수를 반환합니다.
- **Clear():** 스택에 저장된 모든 항목을 제거합니다.

### 간단한 예제

다음 예제는 스택을 사용하여 문자열을 저장하고 꺼내는 방법을 보여줍니다.

```csharp
// 스택을 생성합니다.
Stack<string> stack = new Stack<string>();

// 스택에 문자열을 추가합니다.
stack.Push("Hello");
stack.Push("World!");

// 스택의 크기를 확인합니다.
Console.WriteLine(stack.Count); // 2

// 스택의 맨 위 항목을 제거하고 출력합니다.
string str = stack.Pop();
Console.WriteLine(str); // World!

// 스택의 맨 위 항목을 확인합니다.
str = stack.Peek();
Console.WriteLine(str); // Hello

// 스택에 남은 항목을 모두 제거합니다.
stack.Clear();
```