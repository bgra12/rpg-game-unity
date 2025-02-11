using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionAttackPlayer : FSMDecision
{
    [Header("Config")]
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask playerMask;

    private EnemyAI enemy;

    private void Awake()
    {
        enemy = GetComponent<EnemyAI>();
    }

    public override bool decide()
    {
        return playerInAttackRange();
    }

    private bool playerInAttackRange()
    {
        if (enemy.player == null) return false;
        Collider2D playerCollider = Physics2D.OverlapCircle(enemy.transform.position, attackRange, playerMask);
        if (playerCollider != null) return true;
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
