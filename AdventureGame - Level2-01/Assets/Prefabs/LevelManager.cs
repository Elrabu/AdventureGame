using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void RestartGame()
    {
        PlayerController.facingRight = true;
        Loader.Load(Loader.Scene.GameScene);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
