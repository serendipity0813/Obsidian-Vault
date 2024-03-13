```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject rain;
    public GameObject panel;
    public static GameManager I;
    int totalScore = 0;
    public Text scoreText;
    public Text timeText;
    float limit = 3f;


    void Awake() 
    {
        //�̱���ȭ �ϱ�
        I = this;
    }

    // Start is called before the first frame update
    void Start() 
    {
        InitGame();
        //�ð� ������ ���� ����Ʈ����
        InvokeRepeating("MakeRain", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //�ð��� �帣���� �ϱ�
        limit -= Time.deltaTime;
        timeText.text = limit.ToString("N2");
        //���߰� �ϱ�
        if (limit < 0)
        {
            Time.timeScale = 0.0f;
            panel.SetActive(true);
            limit = 0.0f;
        }
    }
    
    void MakeRain() 
    {
        //���� �����
        Instantiate(rain);
    }

    public void AddScore(int score)
    {
        //���� �ø���
        totalScore += score;
        scoreText.text = totalScore.ToString();
    }

    public void retry()
    {
        // ���� ����� 
        SceneManager.LoadScene("MainScene");
    }
    void InitGame()
    {
        //����ȯ�� �ʱ�ȭ
        Time.timeScale = 1;
        totalScore = 0;
        limit = 30f;

    }
}
```