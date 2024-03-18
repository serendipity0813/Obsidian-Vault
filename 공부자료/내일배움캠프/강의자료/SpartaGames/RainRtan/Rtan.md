```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rtan : MonoBehaviour
{
    float direction = 0.05f;
    float toward = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���콺�� �����ų� ���� ������ ����� ĳ���� �¿��Ī�� ������
        if (Input.GetMouseButtonDown(0))
        {
            toward *= -1;
            direction *= -1;
        }

        if (transform.position.x > 2.8)
        {
            direction = -0.03f;
            toward = -1.0f;

        }
      
        if (transform.position.x < -2.8)
        {
            direction = 0.03f;
            toward = 1.0f;
        }
           
        Debug.Log(transform.position.x);
        transform.localScale = new Vector3(toward, 1, 1);
        transform.position += new Vector3(direction, 0, 0);
    }
}
```