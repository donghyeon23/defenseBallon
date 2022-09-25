using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    public GameObject square;
    public GameObject gameOverText;
    public GameObject panel;
    public Text bestScoreText;
    public Text timeText;

    float alive = 0.0f;
    float bestScore = 0.0f;

    public static gameManager I;

    public Animator anim;
    public GameObject balloon;

    void Awake() {
        I = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.GameStart();
    }

    void GameStart()
    {
        initGame();
        InvokeRepeating("makeSquare", 0.0f, 0.5f);
    }

    void makeSquare()
    {
        Instantiate(square);
    }

    // Update is called once per frame
    void Update()
    {
        alive += Time.deltaTime;
        timeText.text = alive.ToString("N2");
    }

    public void gameOver()
    {
        anim.SetBool("isDie", true);
        gameOverText.SetActive(true);
        Invoke("dead", 0.5f);
    }

    void dead() 
    {
        Destroy(balloon);
        Time.timeScale = 0.0f;
        if(alive > bestScore) 
        {
            bestScoreText.text = alive.ToString("N2");
        }
        panel.SetActive(true);
    }

    void initGame()
    {
        Time.timeScale = 0.5f;
        alive = 0.0f;
    }

    public void ReTry() 
    {
        SceneManager.LoadScene("MainScene");
    }
}
