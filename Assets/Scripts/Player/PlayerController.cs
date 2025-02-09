using System;
using UnityEditorInternal;
using UnityEngine;

    public class PlayerController : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private PlayerStats playerStats;

        public PlayerStats Stats => playerStats;
        
        private PlayerAnimationController playerAnimationController;

        private void Awake()
        {
            playerAnimationController = GetComponent<PlayerAnimationController>();
        }

        public void resetPlayer()
        {
            playerStats.resetPlayerManaAndHealth();
            playerAnimationController.resetPlayerAnimation();
        }
    }
