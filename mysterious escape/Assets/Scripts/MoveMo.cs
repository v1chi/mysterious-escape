using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMo : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private float attackTime= .25f;
    private float attackCounter = .25f;
    private bool isAttacking;
    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private Animator playerAnimator;

    float moveX;
    float moveY;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        moveX = 0;
        moveY = 0;
    }

    void Update()
    {   
        playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveY = 1;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveY = -1;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveX = -1;
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveX = 1;
        }

         if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            moveY = 0;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            moveX = 0;
        }

        moveInput = new Vector2(moveX, moveY).normalized;

        playerAnimator.SetFloat("Horizontal", moveX);
        playerAnimator.SetFloat("Vertical", moveY);
        playerAnimator.SetFloat("Speed", moveInput.sqrMagnitude);

        if (moveX != 0 || moveY != 0)
        {
            playerAnimator.SetFloat("LastMoveHorizontal", moveX);
            playerAnimator.SetFloat("LastMoveVertical", moveY);
        }
         if(isAttacking){
            moveInput= Vector2.zero;
            attackCounter -= Time.deltaTime;
            if(attackCounter<=0){
                playerAnimator.SetBool("isAttacking",false);
                isAttacking = false; 
            }
        }

        if (Input.GetKeyDown(KeyCode.M)){

            attackCounter = attackTime;
            playerAnimator.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }
}