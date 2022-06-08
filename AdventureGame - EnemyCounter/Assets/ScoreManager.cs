using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highscoreText;
    public Text amountText;

    int score = 0;
    int highscore = 0;
    int amount = 2;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();

        
    }

    // Update is called once per frame
    void Update()
    {
        
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
