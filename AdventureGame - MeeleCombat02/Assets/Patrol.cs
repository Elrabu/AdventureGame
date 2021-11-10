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

  public Transform groundDetection;
 // public GameObject bloodEffect;

    void Update(){

    transform.Translate(Vector2.right * speed * Time.deltaTime);

    RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
    if(groundInfo.collider == false){
      if(movingRight == true){
        transform.eulerAngles = new Vector3(0, -180 ,0);
        movingRight = false;
      } else {
        transform.eulerAngles = new Vector3(0, 0, 0);
        movingRight = true;
      }
    }

    if(dazedTime <= 0)
        {
            speed = 3;
        } else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }


    if(health <= 0)
        {
            Destroy(gameObject);
        }

  }

  public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
      //  Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("Damage Taken!");
    }

}
