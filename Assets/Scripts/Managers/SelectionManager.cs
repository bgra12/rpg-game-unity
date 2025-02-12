using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
   public static event Action<EnemyAI> onEnemySelectEvent;
   public static event Action onNoSelectionEvent; 
   
   [Header("Configuration")]
   [SerializeField] private LayerMask enemyMask;
   
   private Camera mainCamera;

   private void Awake()
   {
      mainCamera = Camera.main;
   }

   private void Update()
   {
      selectEnemy();
   }

   private void selectEnemy()
   {
      if (Input.GetMouseButtonDown(0))
      {
         RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, enemyMask);

         if (hit.collider != null)
         {
            EnemyAI enemy = hit.collider.GetComponent<EnemyAI>();
            if(enemy == null) return;
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if(enemyHealth.currentHealth <= 0f) return;
            onEnemySelectEvent?.Invoke(enemy);
         }
         else
         {
            onNoSelectionEvent?.Invoke();
         }
      }
   }
   
}
