using System;
using UnityEngine;


public class TextManager : Singleton<TextManager>
{
    [Header("Configuration")]
    [SerializeField] private DamageText damageTextPrefab;

    public void showDamageText(float damageAmount, Transform parent)
    {
        DamageText text = Instantiate(damageTextPrefab, parent);
        text.transform.position += Vector3.right * 0.5f;
        text.setDamageText(damageAmount);
    }
}