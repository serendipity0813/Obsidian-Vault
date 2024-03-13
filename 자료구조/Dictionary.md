## C# 딕셔너리

C# 딕셔너리는 키-값 쌍을 저장하는데 사용되는 컬렉션 클래스입니다. 딕셔너리는 키를 사용하여 값을 빠르게 검색할 수 있습니다. 딕셔너리는 다음과 같은 특징을 가지고 있습니다.

- **키-값 쌍**: 딕셔너리는 키와 값의 쌍을 저장합니다. 키는 고유해야 하며, 값은 어떤 유형의 객체일 수도 있습니다.
- **빠른 검색**: 딕셔너리는 키를 사용하여 값을 빠르게 검색할 수 있습니다.
- **삽입 및 삭제**: 딕셔너리는 삽입 및 삭제 작업이 비교적 빠릅니다.
- **순서**: 딕셔너리는 기본적으로 순서를 보장하지 않습니다. 하지만 .NET 6부터 `Dictionary<TKey, TValue>` 클래스는 순서를 보장하는 옵션을 제공합니다.
- **null 허용**: 딕셔너리는 키와 값 모두 null 값을 허용합니다.

**딕셔너리 사용**

다음은 딕셔너리를 사용하는 방법에 대한 예입니다.

C#

```
using System.Collections.Generic;

public class Main
{

    public static void Main(string[] args)
    {

        // 딕셔너리 객체 생성
        Dictionary<string, string> names = new Dictionary<string, string>();

        // 키-값 쌍 추가
        names.Add("John", "Doe");
        names.Add("Jane", "Doe");
        names.Add("Joe", "Doe");

        // 값 가져오기
        string name = names["John"];

        // 키 존재 여부 확인
        bool hasKey = names.ContainsKey("John");

        // 값 제거
        names.Remove("John");

        // 딕셔너리 루프
        foreach (KeyValuePair<string, string> pair in names)
        {
            Console.WriteLine(pair.Key + ": " + pair.Value);
        }
    }
}
```

코드를 사용할 때는 주의가 필요합니다. [자세히 알아보기](https://bard.google.com/faq#coding)

content_copy

**딕셔너리와 다른 컬렉션 클래스 비교**

- **List<T>: List<T>는 동적 배열입니다. 딕셔너리보다 느리지만 순서를 보장합니다.
 - LinkedList<T>**: LinkedList<T>는 연결 리스트입니다. 딕셔너리보다 느리지만 삽입 및 삭제가 빠릅니다.
- **HashSet<T>**: HashSet<T>은 해시 집합입니다. 딕셔너리보다 느리지만 중복된 값을 허용하지 않습니다.

**딕셔너리 사용 시 고려 사항**

- 키는 고유해야 합니다.
- 딕셔너리는 기본적으로 순서를 보장하지 않습니다.
- 딕셔너리는 null 값을 허용합니다.

**자료구조 선택**

사용할 컬렉션 클래스는 특정 요구 사항에 따라 다릅니다. 딕셔너리는 키-값 쌍을 빠르게 검색해야 하는 경우에 유용합니다.