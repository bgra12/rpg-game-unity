using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ActionAttack : FSMAction
{
    [Header("Config")]
    [SerializeField] private float damage;
    [SerializeField] private float timeBetweenAttacks;

    private EnemyAI enemy;
    private float timer;

    private void Awake()
    {
        enemy = GetComponent<EnemyAI>();
    }

    public override void act()
    {
        attackPlayer();
    }

    private void attackPlayer()
    {
        if (enemy.player == null || PlayerController.instance.Stats.health <= 0f) return;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            IDamageable player = enemy.player.GetComponent<IDamageable>();
            player.TakeDamage(damage);
            timer = timeBetweenAttacks;
        }
    }
}
