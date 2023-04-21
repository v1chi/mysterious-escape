using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;

    public bool shouldRotate;

    public LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D Enemyrb;
    private Animator EnemyAnimator;
    private Vector2 movement;
    public Vector3 direction;

    private bool isInChaseRange;
    private bool isInAttackRange;

    private void Start()
    {
        Enemyrb = GetComponent<Rigidbody2D>();
        EnemyAnimator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        EnemyAnimator.SetBool("isRunning", isInChaseRange);

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
        
        if (shouldRotate)
        {
            EnemyAnimator.SetFloat("Horizontal", direction.x);
            EnemyAnimator.SetFloat("Vertical", direction.y);
        }
    }

    private void FixedUpdate()
    {
        if (isInChaseRange && !isInAttackRange)
        {
            moveCharacter(movement);
        }
        if (isInAttackRange)
        {
            Enemyrb.velocity = Vector2.zero;
        }
    }

    private void moveCharacter(Vector2 direction)
    {
        Enemyrb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
