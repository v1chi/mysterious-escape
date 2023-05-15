using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float atkCooldown = 0.8f;
    [SerializeField] private BoxCollider2D hitbox;
    [SerializeField] private Animator playerAnimator;
    public bool isAttacking = false;
    private bool canAttack = true;

    private PlayerMovement playerMovement;
    private Collider2D attackArea;

    [SerializeField] AudioClip[] atksound;
    [SerializeField] AudioClip stepsound;
    [SerializeField] AudioController controller;
    int randomSfx;

    void Start()
    {
        //controller = GameObject.Find("Audio").GetComponent<AudioController>();
        hitbox.enabled = false;
    }
    public void AttackAnimation()
    {
        if (canAttack)
        {
            randomSfx = Random.Range(0, 3);
            controller.PlaySfx(atksound[randomSfx]);
            isAttacking = true;
            hitbox.enabled = true;
            playerAnimator.SetBool("Attack", true);
        }
    }
    public void EndAttack()
    {
        playerAnimator.SetBool("Attack", false);
        isAttacking = false;
        hitbox.enabled = false;
        StartCoroutine(AttackCooldown(atkCooldown));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && isAttacking == true)
        {
            other.GetComponent<HealthEnemy>().UpdateHealth(-damage);
        }
    }

    public IEnumerator AttackCooldown(float atkCooldown)
    {
        canAttack = false;
        yield return new WaitForSeconds(atkCooldown);
        canAttack = true;
    }
}
