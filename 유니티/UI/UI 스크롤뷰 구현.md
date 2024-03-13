
## Scroll Rect
- 스크롤뷰 클릭시 인스펙터 창에서 Scroll Rect 컴포넌트가 있는 걸 확인 가능
이걸로 스크롤뷰에 대해 기본적인 설정 가능


![[Pasted image 20240208202427.png]]

**각 요소에 대해서는 [유니티 레퍼런스](https://docs.unity3d.com/kr/2020.3/Manual/script-ScrollRect.html) 혹은 참고한 [블로그 링크](https://maintaining.tistory.com/entry/Unity-%EB%AA%A8%EB%B0%94%EC%9D%BC-%EC%8A%A4%ED%81%AC%EB%A1%A4-%EA%B5%AC%ED%98%84UGUI-Scroll-View) 참고하기
(주의) 왠만하면 Movement Type은 Unrestricted 사용하지 않기

#### Layout Group
- 자동으로 오브젝트를 정렬해주는 기능, 스크롤뷰가 아니더라도 유용하게 사용 가능

**스크롤뷰 생성시 오브젝트들을 처음 넣으면 위치들을 설정해줘야 함
-> 매우 귀찮고 해상도에 따라 위치가 달라지기 때문에 필수 사용

![[Pasted image 20240208203452.png]]

인스펙터 창에서 Layout group을 검색하여 원하는 컴포넌트 추가
- 오브젝트 하나에 Layout group은 하나만 사용 가능
- 요소별 자세한 사항은 역시 [레퍼런스](https://docs.unity3d.com/kr/2020.3/Manual/script-VerticalLayoutGroup.html) 혹은 [블로그](https://maintaining.tistory.com/entry/Unity-%EB%AA%A8%EB%B0%94%EC%9D%BC-%EC%8A%A4%ED%81%AC%EB%A1%A4-%EA%B5%AC%ED%98%84UGUI-Scroll-View) 참고

#### 스크롤뷰 생성
1. 하이어라키 창에 UI - Scroll View 생성
	- ![[Pasted image 20240208204014.png]]
2. 사용할 스크롤바를 제외한 나머지 제거 
	-   ![[Pasted image 20240208203958.png]]
3. Content는 스크롤 내부 요소들이 들어가는 공간
	- UI Anchor를 원하는 방향으로 설정
4. 요소 추가하기
	- Content 하위에 오브젝트 넣어주기 
		-> 처음에는 아무 설정이 되어있지 않으므로 기본 크기로 10개 겹쳐있음
		-> 여기서 Layout Group 컴포넌트를 추가하여 사용
	- ![[Pasted image 20240208204236.png]]
5. Layout Group Component 추가
	- 스크롤 방향에 따라 Vertical, Horizontal, grid 등 선택
	- 추가 후 이미지들이 나란히 정렬됨
	- 여기서 Child Alignmet 와 Control Child Size, Child Force Expand 등을 사용하여 본인이 원하는 크기와 방식으로 정렬 가능
	- Padding 으로 이미지와 배경의 상하좌우 간격을 조절할 수 있음
	- Spacing 으로 각 이미지별 사이 간격 조절가능
6. 이미지가 채워지기 시작하는 방향과 화면별 이미지들의 변형사항을 설정하기
	-  ![[Pasted image 20240208204959.png]]
7.  Content 하위에 이미지가 아닌 게임오브젝트일 경우 인식되지 않으니 주의 