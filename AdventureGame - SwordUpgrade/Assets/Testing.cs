using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Transform pfDamagePopup;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           // Debug.Log("click");
           // Transform damagePopupTransform = Instantiate(pfDamagePopup, Vector3.zero, Quaternion.identity);
           // DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
          //  damagePopup.Setup(100);
        }
    }


}
