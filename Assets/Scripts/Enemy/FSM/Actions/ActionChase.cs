using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionChase : FSMAction
{
    [Header("Config")]
    [SerializeField] private float chaseSpeed;

    private EnemyAI enemy;

    private void Awake()
    {
        enemy = GetComponent<EnemyAI>();
    }

    public override void act()
    {
        chasePlayer();
    }

    private void chasePlayer()
    {
        if(enemy.player == null) return;
        Vector3 directionToPlayer = enemy.player.position - transform.position;
        if (directionToPlayer.magnitude >= 1.3f)//stop distance to player
        {
            transform.Translate(directionToPlayer.normalized * (chaseSpeed * Time.deltaTime));
        }
        
    }
}
