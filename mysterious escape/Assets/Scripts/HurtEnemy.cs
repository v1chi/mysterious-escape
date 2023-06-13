using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2d(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyHealth eHealthMan;
            eHealthMan = other.gameObject.GetComponent<EnemyHealth>();
            eHealthMan.HurtEnemy(damageToGive);
        }
    }
}
