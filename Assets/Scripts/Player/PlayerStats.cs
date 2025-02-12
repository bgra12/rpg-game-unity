using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/Stats", order = 1)]
public class PlayerStats : ScriptableObject
{
  [Header("Experience")]
  public int level;
  public float currentExp;
  public float nextLevelExp;
  public float initialNextLevelExp;
  [Range(1f,100f)] public float expMultiplier;
  
  [Header("Player")]
  public float health;
  public float maxHealth;
  public float mana;
  public float maxMana;
  public float baseDamage;
  public float criticalDamageRate;
  public float criticalChanceRate;
  
  public void resetPlayerManaAndHealth()
  {
    health = maxHealth;
    mana = maxMana;
  }

  public void resetPlayerExp()
  {
    level = 1;
    currentExp = 0f;
    nextLevelExp = initialNextLevelExp;
  }
}
