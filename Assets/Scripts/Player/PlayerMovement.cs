using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField]
    private float speed;

    public Vector2 MoveDirection => moveDirection;
    
    private PlayerAnimationController playerAnimationController;
    private PlayerActions actions;
    private Rigidbody2D rb2D;
    private Vector2 moveDirection;
    private PlayerController playerController;
 
    
    private void Awake()
    {
       playerController = GetComponent<PlayerController>();
       actions = new PlayerActions();
       rb2D = GetComponent<Rigidbody2D>();
       playerAnimationController = GetComponent<PlayerAnimationController>();
    }
    
    void Update()
    {
        readMovement();
    }

    private void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        if (playerController.Stats.health <= 0)
        {
            return;
        }
        rb2D.MovePosition(rb2D.position + moveDirection * (speed * Time.fixedDeltaTime));
    }

    private void readMovement()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
        if (moveDirection == Vector2.zero)
        {
            playerAnimationController.setIsMoving(false);
            return;
        }

        if (playerController.Stats.health > 0)
        {
            playerAnimationController.setIsMoving(true);
            playerAnimationController.setMoveDirection(moveDirection);
        }
       
    }
    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }
}
