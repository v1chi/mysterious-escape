using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive = 2;
    private BoxCollider2D hitbox;

    // Start is called before the first frame update
    void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
        hitbox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colision detectada");
        if (other.tag == "Enemy")
        {
            Debug.Log("Enemigo detectado");
            other.GetComponent<EnemyHealth>().HurtEnemy(damageToGive);
        }
    }
}
