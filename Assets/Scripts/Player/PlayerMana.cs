using System;
using UnityEngine;

    public class PlayerMana : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private PlayerStats stats;

        public float currentMana { get; private set; }

        private void Start()
        {
            resetMana();
        }

        public void useMana(float amount)
        {
            stats.mana = Mathf.Max(stats.mana -= amount, 0f);
            currentMana = stats.mana;
        }

        public void resetMana()
        {
            currentMana = stats.maxMana;
        }
    }
