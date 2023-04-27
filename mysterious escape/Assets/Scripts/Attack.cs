using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    private PlayerMovement playerMovement;
    private Collider2D attackArea;

    void Start()
    {
        attackArea = GetComponent<Collider2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" && playerMovement.isAttacking)
        {
            // Implementar cambio de vida a enemigo
        }
    }
}
