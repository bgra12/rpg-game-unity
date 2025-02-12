using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
   Magic,
   Melee
}

[CreateAssetMenu(fileName = "Weapon_")]
public class Weapon : ScriptableObject
{
   [Header("Config")]
   public Sprite icon;
   public WeaponType weaponType;
   public float damage;
   
   [Header("Projectile")]
   public Projectile projectile;
   public float projectileMana;
   
   
}
