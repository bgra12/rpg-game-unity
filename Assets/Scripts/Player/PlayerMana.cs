using System;
using UnityEngine;

    public class PlayerMana : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private PlayerStats playerStats;

        public float currentMana { get; private set; }

        private void Start()
        {
            resetMana();
        }

        public void useMana(float amount)
        {
            playerStats.mana = Mathf.Max(playerStats.mana -= amount, 0f);
            currentMana = playerStats.mana;
        }

        public bool canRestoreMana()
        {
            return playerStats.mana > 0f && playerStats.mana < playerStats.maxMana;
        }

        public void restoreMana(float amount)
        {
            playerStats.mana += amount;
            playerStats.mana = Mathf.Min(playerStats.mana, playerStats.maxMana);
        }

        public void resetMana()
        {
            currentMana = playerStats.maxMana;
        }
    }
