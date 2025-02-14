using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : Singleton<InventoryController>
{
   [Header("Config")]
   [SerializeField] private int inventorySize;
   [SerializeField] private InventoryItem[] items;

   [Header("Testing")] 
   public InventoryItem testItem;
   
   public int InventorySize => inventorySize;
   public InventoryItem[] Items => items;

   public void Start()
   {
      items = new InventoryItem[inventorySize];
      verifyItems();
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.H))
      {
       addItem(testItem, 1);
      }
   }

   public void addItem(InventoryItem item, int quantity)
   {
      if (item == null || quantity <= 0) return;
      List<int> itemIndexes = checkItemStock(item.itemId);
      if (item.isStackable && itemIndexes.Count > 0)
      {
         foreach (int index in itemIndexes)
         {
            int maxStack = item.maxStackSize;
            if (items[index].quantity < maxStack)
            {
               items[index].quantity += quantity;
               if (items[index].quantity > maxStack)
               {
                  int difference = items[index].quantity - maxStack;
                  items[index].quantity = maxStack;
                  addItem(item,difference);
               }
               InventoryUIController.instance.addItemToInventory(items[index], index);
               return;
            }
         }
      }
      int quantityToAdd = quantity > item.maxStackSize ? item.maxStackSize : quantity;
      addItemIntoFreeSlot(item, quantityToAdd);
      int remainingquantity = quantity - quantityToAdd;
      if (remainingquantity > 0)
      {
        addItem(item, remainingquantity);
      }
   }

   public void useItem(int itemIndex)
   {
      if (items[itemIndex] == null) return;
      if (items[itemIndex].canUseItem())
      {
         decreaseItemQuantity(itemIndex);
      }
   }

   public void removeItem(int itemIndex)
   {
      if (items[itemIndex] == null) return;
      items[itemIndex].removeItem();
      items[itemIndex] = null;
      InventoryUIController.instance.addItemToInventory(null, itemIndex);
   }

   public void equipItem(int itemIndex)
   {
      if (items[itemIndex] == null) return;
      if (items[itemIndex].itemType != ItemType.Weapon) return;
      items[itemIndex].equipItem();
   }

   private void addItemIntoFreeSlot(InventoryItem item, int quantity)
   {
      for (int i = 0; i < inventorySize; i++)
      {
         if(items[i] != null) continue;
         items[i] = item.copyItem();
         items[i].quantity = quantity;
         InventoryUIController.instance.addItemToInventory(items[i],i);
         return;
      }
   }

   private void decreaseItemQuantity(int itemIndex)
   {
      items[itemIndex].quantity--;
      if (items[itemIndex].quantity <= 0)
      {
         items[itemIndex] = null;
         InventoryUIController.instance.addItemToInventory(null, itemIndex);
      }
      else
      {
         InventoryUIController.instance.addItemToInventory(items[itemIndex], itemIndex);
      }
   }
   
   private List<int> checkItemStock(string itemId)
   {
      List<int> itemIndexes = new List<int>();

      for (int i = 0; i < items.Length; i++)
      {
         if(items[i] == null) continue;
         if (items[i].itemId == itemId)
         {
            itemIndexes.Add(i);
         }
      }
      return itemIndexes;
   }

   private void verifyItems()
   {
      for (int i = 0; i < inventorySize; i++)
      {
         if (items[i] == null)
         {
            InventoryUIController.instance.addItemToInventory(null, i);
         }
      }
   }
}
