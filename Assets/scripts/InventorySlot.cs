using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // týklama iþlemleri yapýlýr;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] Item item;
    public int slotNumber;

    InventoryManager inventoryManager;

    [SerializeField] Image itemicon;
    [SerializeField] Text itemamount;
    

    private void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }
    private void Update()
    {
        item = inventoryManager.itemss[slotNumber];

        if (item.ItemName != null)
        {
            itemicon.enabled = true;
            itemicon.sprite = item.ItemIcon;
            if (item.ItemAmount > 1)
            {
                itemamount.enabled = true;
                itemamount.text = item.ItemAmount.ToString();
            }
            else
            {
                itemamount.enabled = false;
            }
        }
        else
        {
            itemicon.enabled = false;
            itemamount.enabled = false;

        }
    }

    public void OnPointerEnter(PointerEventData Data) // mouse üstüne geldðinde çalýþýr
    {
        if (item.ItemName != null)
        {
            if (slotNumber > 3)
            {
                inventoryManager.InformationPanelActive(item);
            }

        }
    }

    public void OnPointerExit(PointerEventData Data) // mouse üstünden gittiðinde çalýþýr
    {
        inventoryManager.InformationPanelDeActive();
    }

    public void OnPointerDown(PointerEventData Data)
    {
        if (Data.button.ToString() == "Left") 
        {
            if (!inventoryManager.TransportOpen && item.ItemName != null)
            {
                inventoryManager.InformationPanelDeActive();

                inventoryManager.itemss[slotNumber] = new Item();
                inventoryManager.PortedItemActive(item);
            }
            else if (inventoryManager.TransportOpen)
            {
                if (item.ItemName == null)
                {
                    inventoryManager.itemss[slotNumber] = inventoryManager.PortedItem;
                    inventoryManager.PortedItemDeActive();
                }
                else
                {
                    if (item.ItemName == inventoryManager.PortedItem.ItemName)
                    {
                        if (item.itemType == Item.ItemType.Food || item.itemType == Item.ItemType.Material || item.itemType == Item.ItemType.Build)
                        {
                            inventoryManager.itemss[slotNumber].ItemAmount += inventoryManager.PortedItem.ItemAmount;
                            inventoryManager.PortedItemDeActive();
                        }
                    }

                }
            }
        }
        if (Data.button.ToString() == "Right")
        {
            if (!inventoryManager.TransportOpen)
            {
                if (item.itemType == Item.ItemType.Food || item.itemType == Item.ItemType.Material || item.itemType == Item.ItemType.Build)
                {
                    if (item.ItemAmount > 1)
                    {
                        int Value = item.ItemAmount / 2;
                        Item NewItem = new Item(item.ItemName, item.ItemInformation, item.ItemId, Value, item.ItemStockAmount, item.ItemDamage, item.itemType);
                        inventoryManager.PortedItemActive(NewItem);
                        int NewValue = item.ItemAmount - Value;
                        inventoryManager.itemss[slotNumber].ItemAmount = NewValue;
                    }
                }
            }
        }
    }
}
