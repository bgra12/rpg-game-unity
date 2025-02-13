using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public static event Action onEnemyDeadEvent;
    
    [Header("Config")]
    [SerializeField] private float health;
    
    public float currentHealth { get; private set; }
    
    private Animator animator;
    private EnemyAI enemy;
    private EnemySelector enemySelector;
    private EnemyLoot enemyLoot;
    
    private void Awake()
    {
        enemy = GetComponent<EnemyAI>();
        animator = GetComponent<Animator>();
        enemySelector = GetComponent<EnemySelector>();
        enemyLoot = GetComponent<EnemyLoot>();
    }

    private void Start()
    {
        currentHealth = health;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0f)
        {
            killEnemy();
        }
        else
        {
            TextManager.instance.showDamageText(damage, transform);
        }
    }

    private void killEnemy()
    {
        animator.SetTrigger("Dead");
        enemy.enabled = false;
        enemySelector.noSelectionCallBack();
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        onEnemyDeadEvent?.Invoke();
        GameManager.instance.addPlayerExp(enemyLoot.ExpDrop);
    }
    
    
}
