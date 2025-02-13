using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [Header("Configuration")]
    [SerializeField] private PlayerStats playerStats;

    private PlayerAnimationController playerAnimationController;

    private void Awake()
    {
        playerAnimationController = GetComponent<PlayerAnimationController>();
    }

    private void Update()
    {
        if (playerStats.health <= 0f)
        {
            playerDead();
        }
    }

    public void TakeDamage(float damage)
    {
       playerStats.health -= damage;
       TextManager.instance.showDamageText(damage,transform);
       if (playerStats.health <= 0)
       {
           playerStats.health = 0;
           playerDead();
       }
    }

    public void restoreHealth(float amount)
    {
        playerStats.health += amount;
        if (playerStats.health > playerStats.maxHealth)
        {
            playerStats.health = playerStats.maxHealth;
        }
    }

    public bool canRestoreHealth()
    {
        return playerStats.health > 0f && playerStats.health < playerStats.maxHealth;
    }

    private void playerDead()
    {
      playerAnimationController.setDeadAnimation();
      transform.GetComponent<CircleCollider2D>().enabled = false;
    }
}