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
    
    private void Awake()
    {
        enemy = GetComponent<EnemyAI>();
        animator = GetComponent<Animator>();
        enemySelector = GetComponent<EnemySelector>();
    }

    private void Start()
    {
        currentHealth = health;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            animator.SetTrigger("Dead");
            enemy.enabled = false;
            enemySelector.noSelectionCallBack();
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            onEnemyDeadEvent?.Invoke();
        }
        else
        {
            TextManager.instance.showDamageText(damage, transform);
        }
    }
    
    
}
