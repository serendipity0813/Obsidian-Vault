### 1) Dotween

![[Pasted image 20240122212849.png]]

**Tweening이란?**

위치, 크기, 회전, 색상과 같은 값을 점진적으로 변화시키는 것!

(코루틴을 안쓰고 쉽게 이런걸 구현할 수 있다고 생각하면 편함)

**내가 직접 다 코루틴으로 짜는게 더 편한데?**

저도 쓰기 전까지는 이런 생각을 했었습니다.

하지만, 트위닝 라이브러리로 10초면 만들 수 있는걸 30분, 40분 고민해서 짜야하는 경우도 생기고, 만들었는데 안예뻐서 바꾸고 싶으면 트위닝 라이브러리는 수없이 많은 결과물을 시도해볼 수 있지만, 직접 만들었을때는 **그냥 하면 안돼요?** 하게 되겠죠(뭐 인내심에 따라 2-3번은 재제작을 해볼 수도 있지만요).

**UI 최적화 원리**

![[Pasted image 20240122212857.png]]

문제 : 애니메이션은 idle 때도 값을 dirty로 만듬 // 애니메이션 쓰는 UI 분리 매우 추천 (Canvas 단위로 분리)

**→ 적어도 바뀔 때만 리프레시가 일어나면 억울하지라도 않겠다**는 생각

**Tweening 라이브러리**

Dotween을 가장 많이 사용하며(코드로만 사용시 거의 다 지원), LeanTween같은 무료 에셋을 활용하기도 함

[DOTween - Documentation (demigiant.com)](https://dotween.demigiant.com/documentation.php#shortcuts)

---

### Dotween 사용법

Dotween을 Import하고, Utility Panel에서 TextMeshPro를 추가합니다.

![[Pasted image 20240122212919.png]]

Dotween을 사용하기 위해 DG.Tweening 네임스페이스를 추가합니다.

### To (유사 Lerp)

[DOTween.To](http://DOTween.To)(getter, setter, to, duration)

### DO시리즈

- 트랜스폼 계열
    
    (1) DOMove
    
    DOLocalMove
    
    DOMoveX
    
    (rectTransform) DOMoveXAnchor
    
    (2) DORoate
    
    (3) DOScale
    
- 기타
    
    (1) DOColor
    
    (2) DOFade
    
    (3) DOText
    

### 옵션

**(1) Ease**

Ease는 어떻게 트위닝이 진행되는지에 대한 양상에 대한 것입니다. 선형적인것만 가능했다면 사실 코루틴을 이길 수가 없을텐데, 수학적인 연산을 활용하여 아래와 같은 다양한 형태의 변화를 제공합니다.

In : 시작점에서 해당 변화가 두드러지는 경우

Out : 종료시점에서 해당 변화가 두드러지는 경우

InOut : 시작과 종료 모두에서 해당 변화가 도드라지는 경

![[Pasted image 20240122212933.png]]

[](https://mblogthumb-phinf.pstatic.net/MjAyMDA5MDhfMjA2/MDAxNTk5NTU3NzUyNjQ2.4Gm7cn8K210uZrx7_2nb68J5kYYuWW4zbhxuWXIXLkYg.8h5t5VQrLGWyM4KsZW_YAuUrfh9Eu9YvIc1_VVUzrkgg.GIF.hana100494/ease6.gif?type=w800)

[](https://mblogvideo-phinf.pstatic.net/MjAyMDA5MDhfMTM5/MDAxNTk5NTU4NTQ0OTcx.WfIgvFKWflGpWFnoAEHjcB-2Lk-BIK0rXX0qWwaWPTIg.4oQEeVd87mEkVOEXYUHwq9_RF4rmDFLkVF_OO_A10M0g.GIF.hana100494/ease9.gif?type=mp4w800)

**(2) Delay**

어떤 이벤트가 일어날 때 지금 당장 일어나야되는 게 아니라든지 하는 이유로 딜레이가 필요한 게 있습니다. 그럴 때 SetDelay를 통해 딜레이를 살짝 줄 수 있습니다.

**(3) From**

어떤 이벤트가 일어날 때 시작점을 지정을 따로 초기화해야 하는 경우가 있는데, 이럴 때 From을 활용하여 시작점을 초기화하지 않고 걸 수 있습니다.

### Sequence

시퀀스는 일련의 동작의 순서를 정의할 수 있는 개념으로,

Append : 뒤에 붙인다

Prepend : 앞에 붙인다

Join : 같이 일어나도록 한다

Insert : 실행시기를 초단위로 정해서 넣는다

와 같이 합니다.

```csharp
mySequence.Append(A)
.Join(B)
.Insert(1.5f,C)
.Prepend(D)
.Append(E);
```

![[Pasted image 20240122212948.png]]


