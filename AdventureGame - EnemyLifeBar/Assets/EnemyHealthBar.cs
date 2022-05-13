using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public PatrolNew PatrolNew;

    Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
        localScale.x = PatrolNew.currentHealth * 2;
        transform.localScale = localScale;
    }
}
