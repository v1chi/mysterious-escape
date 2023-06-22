using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive = 2;
    private BoxCollider2D hitbox;
    private bool isTouching;
    private float waitToHurt = 1f;
    private EnemyHealth healthMan;

    // Start is called before the first frame update
    void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
        hitbox.enabled = false;
        isTouching = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                healthMan.HurtEnemy(damageToGive);
                waitToHurt = 2f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colision detectada");
        if (other.tag == "Enemy" && !isTouching)
        {
            Debug.Log("Enemigo detectado");
            other.GetComponent<EnemyHealth>().HurtEnemy(damageToGive);
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        isTouching = true;
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Enemy")
        {
            isTouching = false;
            waitToHurt = 2f;
        } 
    }
}
