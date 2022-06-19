using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
  public PlatformEffector2D effector;

  void Start(){
    effector = GetComponent<PlatformEffector2D>();
  }

  void Update(){

    if(Input.GetKey("s")){
      effector.rotationalOffset = 100f;
    }

    if(Input.GetKeyDown(KeyCode.Space) || Input.GetKey("w")){
      effector.rotationalOffset = 0;
    }
  }
}
