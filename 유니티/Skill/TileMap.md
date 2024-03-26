Unity의 Tilemap 시스템을 사용하면 이러한 타일 기반의 게임 환경을 쉽게 만들 수 있습니다. 이 시스템을 사용하면 작은 스프라이트를 통해 광대한 게임 환경을 구성할 수 있으며, 복잡한 게임 레벨을 쉽게 디자인하고, 편집하고, 조작할 수 있습니다.

- **Tilemap 시스템은 다음의 구성 요소**
    
    1. **Tilemap GameObject**: Unity의 타일맵 구조를 구성하는 데 사용됩니다. Tilemap Grid의 자식으로 위치하고, 특정 타일의 배치를 관리합니다.
    2. **Grid GameObject**: 모든 타일맵이 위치하는 기본 격자를 나타냅니다.
    3. **Tilemap Renderer**: Tilemap의 모양을 실제로 그리는 역할을 합니다.
    4. **Tilemap Collider 2D**: 필요한 경우, Tilemap에 물리적인 경계를 추가하는 데 사용됩니다. 이를 통해 게임 캐릭터가 타일맵 환경과 상호작용할 수 있게 됩니다.
    5. **Tile Assets**: 개별 타일의 모양과 동작을 정의합니다. 여러 개의 타일을 묶어서 Tileset이라고 부르기도 합니다.
- **TileMap 준비하기**
    
    - Create → 2D Object → Tilemap → Rectangular
        
        ![[Pasted image 20240326100718.png]]
        
    - 이름 수정 Floor
        
    - Window → 2D → Tile Palette
        ![[Pasted image 20240326100732.png]]
        
    - Create New Palette → 이름 수정 Dungeon → Artwork\Level 폴더에 저장
        
        ![[Pasted image 20240326100738.png]]
        
        ![[Pasted image 20240326100749.png]]
        
    - Floor1 ~ 8 드래그 하여 추가 → Artwork\Level 폴더에 저장
        
        ![[Pasted image 20240326100755.png]]
        
    - 모든 wall_* 추가
        
        ![[Pasted image 20240326100759.png]]
        
- **TileMap 그리기**
    
    - Floor 하나 선택 후 그리기
        
        ![[Pasted image 20240326100805.png]]
        
    - Create → 2D Object → Tilemap → Rectangular → 이름변경 BackDesign
        
    - Tilemap Renderer → Order in Layer 2
        
    - 그리기
        
        ![[Pasted image 20240326100812.png]]
        
    - Create → 2D Object → Tilemap → Rectangular → 이름변경 ForeDesign
        
    - Tilemap Renderer → Order in Layer 20
        
    - 그리기
        
        ![[Pasted image 20240326100816.png]]
        
    - Create → 2D Object → Tilemap → Rectangular → 이름변경 Collision
        
    - Tilemap Collider 2D 추가
        
    - Tilemap → Color → a 0
        
        ![[Pasted image 20240326100822.png]]
        
    - 그리기
        
        ![[Pasted image 20240326100830.png]]