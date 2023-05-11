using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private bool enemy;
    [SerializeField] public float maxHealth = 20f;

    private GameObject player;
    private Collider2D hitbox;
    private Animator playerAnimator;
    public float health;
    private bool attacked = false;
    public static string level;
    // Start is called before the first frame update
    void Start()
    {
        hitbox = GetComponent<Collider2D>();
        playerAnimator = GetComponent<Animator>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealth(float mod)
    {
        health += mod;
        /*if (mod < 0)
        {
            playerAnimator.setBool(hurt, true);
        }*/
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health <= 0)
        {
            Destroy();
        }
    }

    private void Die()
    {
        playerAnimator.SetTrigger("Dead");
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
