using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private float attackTime= .25f;
    private float attackCounter = .25f;
    private bool isAttacking;

    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private Animator playerAnimator;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        playerAnimator.SetFloat("Horizontal", moveX);
        playerAnimator.SetFloat("Vertical", moveY);
        playerAnimator.SetFloat("Speed", moveInput.sqrMagnitude);

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            playerAnimator.SetFloat("LastMoveHorizontal", Input.GetAxisRaw("Horizontal"));
            playerAnimator.SetFloat("LastMoveVertical", Input.GetAxisRaw("Vertical"));
        }
         if(isAttacking){
            moveInput= Vector2.zero;
            attackCounter -= Time.deltaTime;
            if(attackCounter<=0){
                playerAnimator.SetBool("isAttacking",false);
                isAttacking = false; 
            }
        }

        if (Input.GetKeyDown(KeyCode.T)){

            attackCounter= attackTime;
            playerAnimator.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }

    

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);
    }
}