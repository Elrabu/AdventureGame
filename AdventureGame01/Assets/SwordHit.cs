using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwordHit : MonoBehaviour
{
    [SerializeField] private Transform pfDamagePopup;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite newSprite02;
    public Sprite newSprite03;

    private bool level1 = false;
    private bool level2 = false;
    private bool level3 = false;
    private int swordlevel = 0;

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private float hitcooldown;
    private float moveInput;
    public float startTimecooldown;
    private bool facingRight = true;
// public GameObject player;
    private bool rightfacing;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "Level2")
        {
            PlayerPrefs.SetInt("swordlevel", 0);
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("swordlevel", swordlevel);
    }
    void Update()
    {
        
        if (ScoreManager.instance.getpoints() >= 20 && level1 == false)
        {
            level1 = true;
            ChangeSprite(newSprite);
            PlayerAttack.instance.IncreaseDmg(2);
            
            if (PlayerPrefs.GetInt("swordlevel") != 1)
            {
                Transform damagePopupTransform = Instantiate(pfDamagePopup, gameObject.transform.position, Quaternion.identity);
                DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
                damagePopup.Popup("Sword Upgraded");
                swordlevel = 1;
            }
            
            
            
            
        } else if(ScoreManager.instance.getpoints() >= 60 && level2 == false)
        {
            level2 = true;
            ChangeSprite(newSprite02);
            PlayerAttack.instance.IncreaseDmg(4);
            
            if (PlayerPrefs.GetInt("swordlevel") != 2)
            {
                Transform damagePopupTransform = Instantiate(pfDamagePopup, gameObject.transform.position, Quaternion.identity);
                DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
                damagePopup.Popup("Sword Upgraded");
                swordlevel = 2;
            }
           
            
        } else if(ScoreManager.instance.getpoints() >= 100 && level3 == false)
        {
            level3 = true;
            ChangeSprite(newSprite03);
            PlayerAttack.instance.IncreaseDmg(10);
            
            if (PlayerPrefs.GetInt("swordlevel") != 3)
            {
                Transform damagePopupTransform = Instantiate(pfDamagePopup, gameObject.transform.position, Quaternion.identity);
                DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
                damagePopup.Popup("Sword Upgraded");
                swordlevel = 3;
            }
             
            
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
