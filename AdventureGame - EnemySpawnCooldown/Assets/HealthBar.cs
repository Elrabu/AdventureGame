using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public GameObject object1;
    public GameObject[] playerdie;
    private bool spawned = false;
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        
    }
    public void TakeDamage()
    {
        slider.value = slider.value - 10;
    }
    public void SetHealth(int health)
    { 
        slider.value = health;
    }
    public void Update()
    {
        if(slider.value <= 0)
        {
            StartCoroutine(timeend(2));
            
        }

    }

    IEnumerator timeend(int time)
    {
        if(spawned == false)
        {
            Instantiate(playerdie[0], object1.transform.position, Quaternion.identity);
            spawned = true;
        }
        
        object1.SetActive(false);
        yield return new WaitForSeconds(time);
        Loader.Load(Loader.Scene.EndScene);

    }
    
}
