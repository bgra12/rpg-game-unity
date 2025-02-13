using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Potion,
    Scroll,
    Ingredient,
    Treasure
}

[CreateAssetMenu(menuName = "Items/Item")]
public class InventoryItem : ScriptableObject
{
    [Header("Config")]
    public string itemId;
    public string itemName;
    public Sprite icon;
    [TextArea] public string itemDescription;
    
    [Header("Info")]
    public ItemType itemType;
    public bool isConsumable;
    public bool isStackable;
    public int maxStackSize;

    [HideInInspector] public int quantity;

    public InventoryItem copyItem()
    {
        InventoryItem instance = Instantiate(this);
        return instance;
    }

    public virtual bool useItem()
    {
        return true;
    }

    public virtual void equipItem()
    {
        
    }

    public virtual void removeItem()
    {
        
    }
}
