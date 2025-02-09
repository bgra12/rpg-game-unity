using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField]
    private float speed;
    
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        playerAnimationController.setIsMoving(true);
        playerAnimationController.setMoveDirection(moveDirection);
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
