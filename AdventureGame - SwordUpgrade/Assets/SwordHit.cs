using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite newSprite02;
    public Sprite newSprite03;

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private float hitcooldown;
    private float moveInput;
    public float startTimecooldown;
    private bool facingRight = true;
// public GameObject player;
    private bool rightfacing;
    void Update()
    {
        
        if (ScoreManager.instance.getpoints() == 20)
        {
            ChangeSprite(newSprite);
            PlayerAttack.instance.IncreaseDmg(2);
        } else if(ScoreManager.instance.getpoints() == 60)
        {
            ChangeSprite(newSprite02);
            PlayerAttack.instance.IncreaseDmg(4);
        } else if(ScoreManager.instance.getpoints() == 100){
            ChangeSprite(newSprite03);
            PlayerAttack.instance.IncreaseDmg(10);
        }

        rightfacing = PlayerController.facingRight;

        moveInput = Input.GetAxis("Horizontal");
        Vector3 temp = transform.rotation.eulerAngles;

        
        if(hitcooldown <= 0)
        {
            temp.z = -45.0f;
            if(rightfacing == true)
            {
                transform.rotation = Quaternion.Euler(temp);
            }
            else
            {
                transform.rotation = Quaternion.Euler(temp * -1);
            }
            
        } 
        else
        {
            hitcooldown -= Time.deltaTime;
        }
      
        if (timeBtwAttack <= 0)
        {
            timeBtwAttack = startTimeBtwAttack;
            if (hitcooldown <= 0)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    temp.z = 270.0f;

                    if (rightfacing == true)
                    {
                        transform.rotation = Quaternion.Euler(temp);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(temp * -1);
                    }

                    hitcooldown = startTimecooldown;
                }
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
           
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }
}
