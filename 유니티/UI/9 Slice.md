# [9 Slice](https://howudong.tistory.com/164#article-1--9-slice)

- 이미지를 9조각으로 나누어 영역별로 사이즈를 조절하는 테크닉

---

### [Image Type](https://howudong.tistory.com/164#article-1-0-1--image-type)

- Image 컴포넌트 속성 중 Image Type에서 사용
    - Sliced와 Tiled에서 사용
    - 9 Slice가 되어있지 않으면 Sliced와 Tiled 사용 불가능

![[Pasted image 20240219200920.png]]

![[Pasted image 20240219200930.png]]

---

## [9 Slice 사용]

- Project에 이미지 원본 파일을 클릭
- Inspector에서 Sprite Editor 클릭

![[Pasted image 20240219201044.png]]

- 아래와 같이 초록색 선으로 9개의 네모 영역을 만든 후, 우측 상단에 Apply
![[Pasted image 20240219201053.png]]


- 경고 문구가 사라진 것을 확인할 수 있다.

![[Pasted image 20240219201142.png]]

---

### [9 Slice를 하면 뭐가 다를까?]

- 그림으로 보는 것이 가장 빠르다.
![[Pasted image 20240219201240.png]]

- 왼쪽은 Sliced 적용 / 오른쪽은 Simple 이미지이다.
- Simple은 크기가 바뀔 때마다 전체 이미지 비율이 그에 상응하여 바뀐다.
- Sliced는 가운데 부분이 제일 크게 바뀌고 나머지 부분은 거의 안 바뀌는 것을 확인할 수 있다.

---

### [스프라이트 에디터(Sprite Editor) 영역별 분석]
![[Pasted image 20240219201338.png]]

- `1번 영역` : 크기가 바뀌어도 사이즈가 고정
- `2번 영역` : 세로 사이즈는 고정, 가로 사이즈만 크기에 따라 변경
- `3번 영역` : 가로 사이즈는 고정, 세로 사이즈만 크기에 따라 변경
- `4번 영역` : 크기에 따라 가로, 세로 사이즈가 변경

---

## [9 Slice는 왜 알아야 할까?](https://howudong.tistory.com/164#article-1-2--9-slice%EB%8A%94-%EC%99%9C-%EC%95%8C%EC%95%84%EC%95%BC-%ED%95%A0%EA%B9%8C?)

- Simple Type으로 이미지를 크게 키우면 해상도가 깨져 흐릿하게 보일 수 있다.
- 늘어나지 않는 고정된 부분을 정해둠으로써 흐릿해짐이나 깨짐을 방지할 수 있다.
- **실제로 현업에서 디자이너가 UI나 파일을 건네줄 때 9 Slice를 거쳐야 사용할 수 있도록 건네준다.**