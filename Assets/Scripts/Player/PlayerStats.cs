using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/Stats", order = 1)]
public class PlayerStats : ScriptableObject
{
  [Header("Config")]
  public int level;
  
  [Header("Player")]
  public float health;
  public float maxHealth;
  
}
