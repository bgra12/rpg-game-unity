﻿using UnityEngine;


    public class PlayerExperienceController : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private PlayerStats stats;

        public void increasePlayerExperience(float amount)
        {
            stats.totalExp += amount;
            stats.currentExp += amount;
            if (stats.currentExp >= stats.nextLevelExp)
            {
                stats.currentExp -= stats.nextLevelExp;
                nextLevel();
            }
        }

        private void nextLevel()
        {
            stats.level++;
            stats.attributePoints++;
            float currentExpRequired = stats.nextLevelExp;
            float newNextLevelExp = Mathf.Round(currentExpRequired + stats.nextLevelExp * (stats.expMultiplier / 100f));
            stats.nextLevelExp = newNextLevelExp;
        }
    }
