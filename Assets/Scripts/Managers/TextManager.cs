using System;
using UnityEngine;


public class TextManager : MonoBehaviour
{
    public static TextManager instance;
    
    [Header("Configuration")]
    [SerializeField] private DamageText damageTextPrefab;

    private void Awake()
    {
        instance = this;
    }

    public void showDamageText(float damageAmount, Transform parent)
    {
        DamageText text = Instantiate(damageTextPrefab, parent);
        text.transform.position += Vector3.right * 0.5f;
        text.setDamageText(damageAmount);
    }
}