using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public static event Action<int> onSlotSelectedEvent;
    
    [Header("Configuration")]
    [SerializeField] private Image itemIcon;
    [SerializeField] private Image quantityContainer;
    [SerializeField] private TextMeshProUGUI itemQuantityText;

    public int slotIndex { get; set; }

    public void clickSlot()
    {
        onSlotSelectedEvent?.Invoke(slotIndex);
    }
    
    public void updateSlot(InventoryItem item)
    {
        itemIcon.sprite = item.icon;
        itemQuantityText.text = item.quantity.ToString();
        itemIcon.SetNativeSize();
    }

    public void showSlotInformation(bool show)
    {
        itemIcon.gameObject.SetActive(show);
        quantityContainer.gameObject.SetActive(show);
    }
}
