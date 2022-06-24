using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadscore : MonoBehaviour
{

    public Text scoretext;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("score");
        scoretext.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
