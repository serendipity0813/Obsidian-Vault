- **Package 추가하기**
    
    - Window → Package Manager → Unity Register → Input System → Install
        ![[Pasted image 20240325182717.png]]
        
- **New Input Sytem 준비하기**
    
    - Create → Input Action 클릭 → 이름수정
    ![[Pasted image 20240325182727.png]]
    
- **Input Action 수정하기**
    
    - InputAction 더블클릭
        
    - No Control Schemes → Add Control Scheme
        ![[Pasted image 20240325182740.png]]
        
		- 이름 수정 → + 버튼 → Keyboard 와 Mouse 추가
        
    - Action Maps → + → Player
        
![[Pasted image 20240325182827.png]]
---
- Move Action 수정 → Add Up Down Left Right Composite 추가 → WASD 설정
  ![[Pasted image 20240325182833.png]]
  ![[Pasted image 20240325183054.png]]
        
- Look Action 수정
        
![[Pasted image 20240325182902.png]]
        
- Fire Action 수정
        
![[Pasted image 20240325182905.png]]

- 빈 오브젝트 → Player 이름수정
    
- Rigidbody 2D 추가 → Gravity Scale 0, Freeze Rotation Z
    
    ![[Pasted image 20240325183129.png]]
    
- Player Input 추가 → Actions - TopDown Controller 2D
    
![[Pasted image 20240325183134.png]]
    
- PlayerInputController , TopDownMovement 추가
    
- Player에 이미지 드래그 하여 추가 → MainSprite 이름 변경
![[Pasted image 20240325183139.png]]
