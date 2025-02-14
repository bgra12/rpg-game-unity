using UnityEngine;

[CreateAssetMenu(fileName = "ItemHealthPotion", menuName = "Items/HealthPotion")]
public class ItemHealthPotion : InventoryItem
{
    [Header("Config")]
    public float healAmount;

    public override bool canUseItem()
    {
        if (GameManager.instance.Player.playerHealth.canRestoreHealth())
        {
            GameManager.instance.Player.playerHealth.restoreHealth(healAmount);
            return true;
        }
        else
        {
            return false;
        }
    } 
}