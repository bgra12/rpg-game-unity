using System;
using UnityEditorInternal;
using UnityEngine;

    public class PlayerController : MonoBehaviour
    {
        public static PlayerController instance;
        
        [Header("Configuration")]
        [SerializeField] private PlayerStats playerStats;

        public PlayerStats Stats => playerStats;
        public PlayerMana playerMana { get; private set; }
        public PlayerHealth playerHealth { get; private set; }
        private PlayerAnimationController playerAnimationController;
        
        private void Awake()
        {
            playerMana = GetComponent<PlayerMana>();
            playerHealth = GetComponent<PlayerHealth>();
            playerAnimationController = GetComponent<PlayerAnimationController>();
            instance = this;
        }

        public void resetPlayer()
        {
            playerStats.resetPlayer();
            playerAnimationController.resetPlayerAnimation();
            transform.GetComponent<CircleCollider2D>().enabled = true;
            playerMana.resetMana();
        }
    }
