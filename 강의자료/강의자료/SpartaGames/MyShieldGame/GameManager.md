```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject square;
    public Text timeTxt;
    float alive = 0f;
    public GameObject endPanel;
    public static GameManager I;
    public Text thisScoreTxt;
    public Text maxScoreTxt;
    public Animator anim;
    bool isRunning = true;

    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("MakeSquare", 0.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            alive += Time.deltaTime;
            timeTxt.text = alive.ToString("N2");
        }
       
    }

    void MakeSquare()
    {
        Instantiate(square);
    }
    public void gameOver()
    {
        isRunning = false;
        anim.SetBool("isDie", true);
        Invoke("timeStop", 0.7f);
        maxScoreTxt.text = PlayerPrefs.GetFloat("bestScore").ToString("N2");
        thisScoreTxt.text = alive.ToString("N2");
        endPanel.SetActive(true);

        if (PlayerPrefs.HasKey("bestscore") == false)
        { 
            PlayerPrefs.SetFloat("bestscore", alive);
        }
        else
            { 
                if(PlayerPrefs.GetFloat("bestscore") < alive)
                 {
                     PlayerPrefs.SetFloat("bestscore", alive);
                 }
            }

        float maxScore = PlayerPrefs.GetFloat("bestscore");
        maxScoreTxt.text = maxScore.ToString("N2");

    }
    public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }
    void timeStop()
    {
        Time.timeScale = 0.0f;
    }

}
```