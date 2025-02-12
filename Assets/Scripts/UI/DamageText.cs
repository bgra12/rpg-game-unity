using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private TextMeshProUGUI dmgTMP;

    public void setDamageText(float dmg)
    {
        dmgTMP.text = dmg.ToString();
    }

    public void destroyDamageText()
    {
        Destroy(gameObject);
    }
}
