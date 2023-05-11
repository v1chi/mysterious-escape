using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] private float speed = 3f;

    //public bool isAttacking;
    //private Vector2 moveInput;

    //private Attack attackScript;

    [Header("Componentes")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject hitbox;
    private HealthPlayer health;
    private Rigidbody2D playerRb;
    private SpriteRenderer sr;
    private Animator playerAnimator;
    //private Animator weapon;

    [Header("Movimiento")]
    private float characterSpeed;
    public float walkSpeed;
    public float runSpeed;

    // Start is called before the first frame update
    void Start()
    {
        characterSpeed = walkSpeed;
        playerRb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
        //weapon = hitbox.GetComponent<Animator>();
        health = this.GetComponent<HealthPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementUpdate();
        Attack();
    }

    void FixedUpdate()
    {
        playerRb.velocity = new Vector2(characterSpeed * Input.GetAxisRaw("Horizontal"), characterSpeed * Input.GetAxisRaw("Vertical"));
    }

    void MovementUpdate()
    {
        playerAnimator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        playerAnimator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
        playerAnimator.SetFloat("Speed", playerRb.velocity.sqrMagnitude);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            characterSpeed = runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            characterSpeed = walkSpeed;
        }
        LastDirection();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            hitbox.GetComponent<Attack>().AttackAnimation();
        }
    }

    void LastDirection()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            playerAnimator.SetFloat("Dir", 1);
            //weapon.SetFloat("Dir", 1);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            playerAnimator.SetFloat("Dir", 3);
            //weapon.SetFloat("Dir", 3);
        }
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            playerAnimator.SetFloat("Dir", 0);
            //weapon.SetFloat("Dir", 0);
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            playerAnimator.SetFloat("Dir", 2);
            //weapon.SetFloat("Dir", 2);
        }
    }

    public void EndAttack()
    {
        hitbox.GetComponent<Attack>().EndAttack();
    }

}