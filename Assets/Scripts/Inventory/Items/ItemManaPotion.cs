using UnityEngine;

[CreateAssetMenu(fileName = "ItemManaPotion", menuName = "Items/ManaPotion")]
public class ItemManaPotion : InventoryItem
{
    [Header("Config")] 
    public float manaAmount;

    public override bool canUseItem()
    {
        if (GameManager.instance.Player.playerMana.canRestoreMana())
        {
            GameManager.instance.Player.playerMana.restoreMana(manaAmount);
            return true;
        }
        else
        {
            return false;
        }
    }
}