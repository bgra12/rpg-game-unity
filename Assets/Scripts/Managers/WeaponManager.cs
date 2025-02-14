using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : Singleton<WeaponManager>
{
    [Header("Configuration")]
    [SerializeField] private Image weaponIcon;
    [SerializeField] private TextMeshProUGUI weaponManaTMP;

    public void equipWeapon(Weapon weapon)
    {
        weaponIcon.sprite = weapon.icon;
        weaponIcon.SetNativeSize();
        weaponIcon.gameObject.SetActive(true);
        weaponManaTMP.text = weapon.projectileMana.ToString();
        weaponManaTMP.gameObject.SetActive(true);
        GameManager.instance.Player.playerAttack.equipWeapon(weapon);
    }
}
