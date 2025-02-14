using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : Singleton<InventoryUIController>
{
  [Header("Config")]
  [SerializeField] private GameObject inventoryPanel;
  [SerializeField] private InventorySlot inventorySlotPrefab;
  [SerializeField] private Transform inventorySlotContainer;
  [Header("Desc Panel")]
  [SerializeField] private GameObject descPanel;
  [SerializeField] private Image itemIcon;
  [SerializeField] private TextMeshProUGUI itemName;
  [SerializeField] private TextMeshProUGUI itemDescription;


  public InventorySlot currentInventorySlot{ get; set; }
  
  private List<InventorySlot> inventorySlots = new List<InventorySlot>();
  
  private void Start()
  {
    initInventorySlots();
  }

  private void initInventorySlots()
  {
    for (int i = 0; i < InventoryController.instance.InventorySize; i++)
    {
      InventorySlot slot = Instantiate(inventorySlotPrefab, inventorySlotContainer);
      slot.slotIndex = i;
      inventorySlots.Add(slot);
    }
  }

  public void useItem()
  {
    if(currentInventorySlot == null) return;
    InventoryController.instance.useItem(currentInventorySlot.slotIndex);
  }

  public void removeItem()
  {
    if(currentInventorySlot == null) return;
    InventoryController.instance.removeItem(currentInventorySlot.slotIndex);
  }

  public void equipItem()
  {
    if(currentInventorySlot == null) return;
    InventoryController.instance.equipItem(currentInventorySlot.slotIndex);
  }

  public void addItemToInventory(InventoryItem item, int slotIndex)
  {
    InventorySlot slot = inventorySlots[slotIndex];
    if (item == null)
    {
      slot.showSlotInformation(false);
      return;
    }
    
    slot.showSlotInformation(true);
    slot.updateSlot(item);
  }

  public void showItemDescription(int itemIndex)
  {
    if (InventoryController.instance.Items[itemIndex] == null) return;
    descPanel.SetActive(true);
    itemIcon.sprite = InventoryController.instance.Items[itemIndex].icon;
    itemName.text = InventoryController.instance.Items[itemIndex].itemName;
    itemDescription.text = InventoryController.instance.Items[itemIndex].itemDescription;
  }

  public void openAndCloseInventory()
  {
    inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    if (inventoryPanel.activeSelf == false)
    {
      descPanel.SetActive(false);
      currentInventorySlot = null;
    }
  }

  private void slotSelectedCallback(int slotIndex)
  {
    currentInventorySlot = inventorySlots[slotIndex];
    showItemDescription(slotIndex);
  }

  private void OnEnable()
  {
    InventorySlot.onSlotSelectedEvent += slotSelectedCallback;
  }

  private void OnDisable()
  {
    InventorySlot.onSlotSelectedEvent -= slotSelectedCallback;
  }
}
