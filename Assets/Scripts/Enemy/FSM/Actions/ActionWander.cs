using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ActionWander : FSMAction
{
    [Header("Config")]
    [SerializeField] private float speed;
    [SerializeField] private float wanderTime;
    [SerializeField] private Vector2 wanderRange;
    
    private Vector3 movePosition;
    private float timer;

    private void Start()
    {
        getNewDestination();
    }

    public override void act()
    {
       timer -= Time.deltaTime;
       Vector3 moveDirection = (movePosition - transform.position).normalized;
       Vector3 movement = moveDirection * (speed * Time.deltaTime);
       if (Vector3.Distance(transform.position, movePosition) >= 0.5f)
       {
           transform.Translate(movement);
       }

       if (timer <= 0)
       {
           getNewDestination();
           timer = wanderTime;
       }
    }

    private void getNewDestination()
    {
        float randomX = Random.Range(-wanderRange.x, wanderRange.x);
        float randomY = Random.Range(-wanderRange.y, wanderRange.y);
        
        movePosition = transform.position + new Vector3(randomX, randomY);
    }

    private void OnDrawGizmosSelected()
    {
        if (wanderRange != Vector2.zero)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(transform.position,wanderRange * 2f);
            Gizmos.DrawLine(transform.position, movePosition);
        }
    }
}
