using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
   // [SerializeField] private Transform pfDamagePopup;

    public static ScoreManager instance;

    public Text scoreText;
    public Text highscoreText;
    public Text amountText;
    public Text announcement;

    int score = 0;
    int highscore = 0;
    int amount = 2;
    
    private void Awake()
    {
        instance = this;
        
        
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt("score", score);
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Level2")
        {
            PlayerPrefs.SetInt("score", 0);
        }

        score = PlayerPrefs.GetInt("score");

        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();

        TimeController.instance.BeginTimer();

    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "Level2")
        {
            if (amount == 0)
            {
                PlayerController.facingRight = true;
                Loader.Load(Loader.Scene.Level2);
            }
        }
        if(SceneManager.GetActiveScene().name == "Level2")
        {
            if (amount == 0)
            {
                PlayerController.facingRight = true;
                Loader.Load(Loader.Scene.WinScene);
            }
        }
       
        
        
    }

    public void addEnemy()
    {
        amount = amount + 1;
        amountText.text = amount.ToString();
    }
    public void Enemyremove()
    {
        amount = amount - 1;
        amountText.text = amount.ToString();
    }
    public int getscore()
    {
        return amount;
    }
    public int getpoints()
    {
        return score;
    }

    public void AddPoint()
    {
        score += 10;
        scoreText.text = score.ToString() + " POINTS";
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        
    }

    
}
