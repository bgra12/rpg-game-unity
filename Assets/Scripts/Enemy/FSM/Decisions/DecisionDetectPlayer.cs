using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionDetectPlayer : FSMDecision
{
    [Header("Config")]
    [SerializeField] private float range;
    [SerializeField] private LayerMask playerMask;

    private EnemyAI enemy;

    private void Awake()
    {
        enemy = GetComponent<EnemyAI>();
    }

    public override bool decide()
    {
        return detectPlayer();
    }

    private bool detectPlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(enemy.transform.position, range, playerMask);
        if (playerCollider != null)
        {
            enemy.player = playerCollider.transform;
            return true;
        }
        enemy.player = null;
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
