using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField]
    private float speed;

    private readonly int moveX = Animator.StringToHash("moveX");
    private readonly int moveY = Animator.StringToHash("moveY");
    private readonly int isMoving = Animator.StringToHash("isMoving");
    
    private PlayerActions actions;
    private Rigidbody2D rb2D;
    private Vector2 moveDirection;
    private Animator animator;
    
    private void Awake()
    {
       actions = new PlayerActions();
       rb2D = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
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
        rb2D.MovePosition(rb2D.position + moveDirection * (speed * Time.fixedDeltaTime));
    }

    private void readMovement()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
        if (moveDirection == Vector2.zero)
        {
            animator.SetBool(isMoving, false);
            return;
        }
        animator.SetBool(isMoving, true);
        animator.SetFloat(moveX, moveDirection.x);
        animator.SetFloat(moveY, moveDirection.y);
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
