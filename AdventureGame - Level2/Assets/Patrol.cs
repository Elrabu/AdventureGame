using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public int health;
    public float speed;
    public float distance;
    public float dazedTime;
    public float startDazedTime;

    private bool movingRight = true;
    public Material matWhite;
    public Material matDefault;
    //private UnityEngine.Object explosionRef;
    SpriteRenderer sr;

    public GameObject explosion;
    public GameObject Hitexplosion;
    public Transform groundDetection;
    // public GameObject bloodEffect;

    private Vector3 startingScale;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        // matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
        //  explosionRef = Resources.Load("Explosion");
        this.startingScale = transform.localScale;
    }


    void Update()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingRight)
            {
                // transform.eulerAngles = new Vector3(0, -180 ,0);
                gameObject.transform.localScale.Scale(new Vector3(-1.0f, 1.0f, 1.0f));
                movingRight = false;
            }
            else
            {
                // transform.eulerAngles = new Vector3(0, 0, 0);
                gameObject.transform.localScale.Scale(new Vector3(-1.0f, 1.0f, 1.0f));
                movingRight = true;
            }
        }

        if (dazedTime <= 0)
        {
            speed = 3;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }


        if (health <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            // GameObject explosion = (GameObject)Instantiate(explosionRef);
            // explosion.transform.position = new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z);
            Destroy(gameObject);
        }
        else
        {
            // Invoke("ResetMaterial", 1f);

        }
    }



    public void ResetMaterial()
    {
        sr.material = matDefault;
    }

    public void TakeDamage(int damage)
    {
        Instantiate(Hitexplosion, transform.position, Quaternion.identity);
        // sr.material = matWhite;
        dazedTime = startDazedTime;
        //  Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("Damage Taken!");


    }

}
