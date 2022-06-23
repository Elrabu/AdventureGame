using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
   
   /* public static DamagePopup Create(Vector3 position, int damageAmount)
     {
        Transform damagePopupTransform = Instantiate(GameAssets.I.pfDamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount);

        return damagePopup;
     }
    */
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;

    public void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    public void Setup(int damageAmount)
    {
        textMesh.SetText(damageAmount.ToString());
        textColor = textMesh.color;
        disappearTimer = 1f;
    }
    public void Popup(string text)
    {
        textMesh.SetText(text);
        textColor = textMesh.color;
        disappearTimer = 1f;
    }

    
    private void Update()
    {
        float moveYSpeed = 2f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            float disappearSpeed = 10f;
            textColor.a -= disappearSpeed * Time.deltaTime;
          //  textMesh.color = textColor;
            if(textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
