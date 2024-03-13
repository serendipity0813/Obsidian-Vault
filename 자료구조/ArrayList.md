## C# ArrayList

ArrayList는 C#에서 동적 배열을 구현하는데 사용되는 클래스입니다. ArrayList는 크기가 가변적이며, 객체를 추가하거나 제거할 때 자동으로 크기가 조정됩니다. ArrayList는 다음과 같은 특징을 가지고 있습니다.

- **동적 배열**: ArrayList는 크기가 가변적입니다. 객체를 추가하거나 제거할 때 자동으로 크기가 조정됩니다.
- **순서**: ArrayList는 순서가 있는 데이터 구조입니다. 객체는 추가된 순서대로 저장됩니다.
- **null 허용**: ArrayList는 null 값을 허용합니다.
- **인덱싱**: ArrayList는 인덱싱을 지원합니다. 인덱스를 사용하여 특정 위치에 있는 객체를 가져오거나 설정할 수 있습니다.
- **빠른 검색**: ArrayList는 객체를 빠르게 검색할 수 있습니다.
- **느린 삽입 및 삭제**: ArrayList는 객체를 삽입하거나 삭제할 때 느릴 수 있습니다.

ArrayList는 다음과 같은 경우에 사용할 수 있습니다.

- 데이터를 순서대로 저장해야 하는 경우
- 객체를 추가하거나 제거해야 하는 경우
- null 값을 허용해야 하는 경우
- 빠른 검색이 필요한 경우

다음은 ArrayList를 사용하는 방법에 대한 예입니다.

C#

```
using System;
using System.Collections;

public class Main
{

    public static void Main(string[] args)
    {

        // ArrayList 객체 생성
        ArrayList names = new ArrayList();

        // 객체 추가
        names.Add("John");
        names.Add("Jane");
        names.Add("Joe");

        // 객체 삽입
        names.Insert(1, "Mary");

        // 객체 제거
        names.RemoveAt(2);

        // 객체 가져오기
        string name = (string)names[0];

        // 객체 설정
        names[0] = "John Doe";

        // ArrayList 크기
        int size = names.Count;

        // ArrayList 비어있는지 확인
        bool isEmpty = names.Count == 0;

        // ArrayList 루프
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }
}
```

코드를 사용할 때는 주의가 필요합니다. [자세히 알아보기](https://bard.google.com/faq#coding)

content_copy

ArrayList는 C#에서 동적 배열을 구현하는데 유용한 클래스입니다. ArrayList는 크기가 가변적이며, 객체를 추가하거나 제거할 때 자동으로 크기가 조정됩니다. ArrayList는 순서가 있고, null 값을 허용하며, 인덱싱을 지원합니다. ArrayList는 빠른 검색이 가능하지만, 삽입 및 삭제는 느릴 수 있습니다.

ArrayList는 다음과 같은 다른 컬렉션 클래스와 유사합니다.

- **List<T>**: List<T>는 강력한 형식 안전성을 제공하는 동적 배열입니다.
- **LinkedList<T>**: LinkedList<T>는 데이터를 순서대로 저장하는데 효율적인 연결 리스트입니다.
- **Dictionary<TKey, TValue>**: Dictionary<TKey, TValue>는 키-값 쌍을 저장하는데 효율적인 해시 테이블입니다.

사용할 컬렉션 클래스는 특정 요구 사항에 따라 다릅니다.