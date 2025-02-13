using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeButtonController : MonoBehaviour
{
    public static event Action<Attributes> onAttributeButtonClicked;
    [Header("Configuration")]
    [SerializeField] private Attributes attributes;

    public void selectAttribute()
    {
        onAttributeButtonClicked?.Invoke(attributes);
    }
}
