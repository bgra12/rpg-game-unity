using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    public static event Action onPlayerUpgradeEvent;
    
    [Header("Config")]
    [SerializeField] private PlayerStats playerStats;
    
    [Header("Settings")]
    [SerializeField] private UpgradeSettings[] upgradeSettings;

    private void upgradePlayer(int upgradeIndex)
    {
        playerStats.baseDamage += upgradeSettings[upgradeIndex].damageUpgrade;
        playerStats.totalDamage += upgradeSettings[upgradeIndex].damageUpgrade;
        playerStats.maxHealth += upgradeSettings[upgradeIndex].healthUpgrade;
        playerStats.health = playerStats.maxHealth;
        playerStats.maxMana += upgradeSettings[upgradeIndex].manaUpgrade;
        playerStats.mana = playerStats.maxMana;
        playerStats.criticalChanceRate += upgradeSettings[upgradeIndex].critChanceUpgrade;
        playerStats.criticalDamageRate += upgradeSettings[upgradeIndex].critDamageUpgrade;
    }

    private void attributeCallBack(Attributes attributes)
    {
        if (playerStats.attributePoints != 0)
        {
            switch (attributes)
            {
                case Attributes.Strength:
                    upgradePlayer(0);
                    playerStats.strength++;
                    break;
                case Attributes.Dexterity:
                    upgradePlayer(1);
                    playerStats.dexterity++;
                    break;
                case Attributes.Intelligence:
                    upgradePlayer(2);
                    playerStats.intelligence++;
                    break;
            }

            playerStats.attributePoints--;
            onPlayerUpgradeEvent?.Invoke();
        }
    }

    private void OnEnable()
    {
        AttributeButtonController.onAttributeButtonClicked += attributeCallBack;
    }

    private void OnDisable()
    {
        AttributeButtonController.onAttributeButtonClicked -= attributeCallBack;
    }
}

[System.Serializable]
public class UpgradeSettings
{
    public string upgradeName;

    [Header("Values")] 
    public float damageUpgrade;
    public float healthUpgrade;
    public float manaUpgrade;
    public float critChanceUpgrade;
    public float critDamageUpgrade;
    
}
