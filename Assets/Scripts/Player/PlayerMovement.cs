using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField]
    private float speed;

    private PlayerActions actions;
    private Rigidbody2D rb2D;
    private Vector2 moveDirection;
    
    private void Awake()
    {
       actions = new PlayerActions();
       rb2D = GetComponent<Rigidbody2D>();
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
