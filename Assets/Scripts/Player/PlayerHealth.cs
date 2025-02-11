using System;
using System.Collections;
using System.Collections.Generic;
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
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1f);
        }
    }

    public void TakeDamage(float damage)
    {
       playerStats.health -= damage;
       if (playerStats.health <= 0)
       {
           playerStats.health = 0;
           playerDead();
       }
    }

    private void playerDead()
    {
      playerAnimationController.setDeadAnimation();
    }
}