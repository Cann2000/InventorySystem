using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<Item> itemss;

    [SerializeField] GameObject slot, ItemInformationPanel, PortedSlot;
    public int StartingSlotAmount, SlotAmount, EmptySlotAmount;

    DataItem dataitem;

    public bool InformationPanelOpen;
    public bool TransportOpen;



    public Item InformationItem, PortedItem;


    void Start()
    {

        dataitem = FindObjectOfType<DataItem>();

        for (int i = StartingSlotAmount; i < SlotAmount; i++)
        {
            GameObject slotobj = Instantiate(slot);
            slotobj.transform.SetParent(gameObject.transform);
            slotobj.GetComponent<InventorySlot>().slotNumber = i;
        }
        for (int i = 0; i < EmptySlotAmount; i++)
        {
            itemss.Add(new Item());
        }

        ItemAdd(1, 30);
        ItemAdd(2, 1);
        ItemAdd(3, 2);
        ItemAdd(4, 1);
        ItemAdd(5, 2);
        ItemAdd(6, 5);
        ItemAdd(7, 3);
        ItemAdd(8, 1);
        ItemAdd(9, 1);
        ItemAdd(10, 2);
        ItemAdd(11, 3);
        ItemAdd(12, 1);
        ItemAdd(13, 4);


    }

    void Update()
    {
        if (TransportOpen)
        {
            PortedSlot.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = PortedItem.ItemIcon;
            PortedSlot.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0); //image mousu takip etsin
            if (PortedItem.ItemAmount > 1)
            {
                PortedSlot.transform.GetChild(1).gameObject.GetComponent<Text>().enabled = true;
                PortedSlot.transform.GetChild(1).gameObject.GetComponent<Text>().text = PortedItem.ItemAmount.ToString();
            }
            else
            {
                PortedSlot.transform.GetChild(1).gameObject.GetComponent<Text>().enabled = false;
            }

        }

        if (InformationPanelOpen)
        {
            ItemInformationPanel.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            ItemInformationPanel.transform.GetChild(0).gameObject.GetComponent<Text>().enabled = true;
            ItemInformationPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = InformationItem.ItemName;
            ItemInformationPanel.transform.GetChild(1).gameObject.GetComponent<Text>().enabled = true;
            ItemInformationPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = InformationItem.ItemInformation;
        }

    }

    public void ItemAdd(int id, int amount)
    {
        for (int i = 0; i < dataitem.items.Count; i++)
        {
            if (dataitem.items[i].ItemId != id)
            {
                continue;
            }

            Item NewItem = new Item(dataitem.items[i].ItemName, dataitem.items[i].ItemInformation, dataitem.items[i].ItemId, amount, dataitem.items[i].ItemStockAmount, dataitem.items[i].ItemDamage, dataitem.items[i].itemType);

            if (NewItem.itemType == Item.ItemType.Food || NewItem.itemType == Item.ItemType.Material || NewItem.itemType == Item.ItemType.Build || NewItem.itemType == Item.ItemType.Health)
            {
                AddOnSlot(NewItem);
            }
            else if (NewItem.ItemAmount > 1)
            {
                int Value = NewItem.ItemAmount - 1;
                Item NewItem_2 = new Item(NewItem.ItemName, NewItem.ItemInformation, NewItem.ItemId, Value, NewItem.ItemStockAmount, NewItem.ItemDamage, NewItem.itemType);
                NewItem.ItemAmount = 1;

                AddOnEmptySlot(NewItem);
                ItemAdd(NewItem_2.ItemId, NewItem_2.ItemAmount);
            }
            else
            {
                AddOnEmptySlot(NewItem);
            }
        }
    }

    public void AddOnSlot(Item item)
    {
        for (int i = 0; i < itemss.Count; i++)
        {
            if (itemss[i].ItemName == item.ItemName)
            {
                itemss[i].ItemAmount += item.ItemAmount;
                break;
            }
            if(i==itemss.Count-1)
            {
                AddOnEmptySlot(item);
            }
        }
    }

    public void AddOnEmptySlot(Item item)
    {
        for (int i =4;i < itemss.Count;i++)
        {
            if (itemss[i].ItemName == null)
            {
                itemss[i] = item;
                break;  
            }
        }
    }

    public void InformationPanelActive(Item item)
    {
        InformationPanelOpen = true;
        InformationItem = item;
        ItemInformationPanel.SetActive(true);
    }
    public void InformationPanelDeActive()
    {
        InformationPanelOpen = false;
        InformationItem = null;
        ItemInformationPanel.SetActive(false);
    }

    public void PortedItemActive(Item item)
    {
        TransportOpen = true;
        PortedItem = item;
        PortedSlot.SetActive(true);
    }
    public void PortedItemDeActive()
    {
        TransportOpen = false;
        PortedItem = null;
        PortedSlot.SetActive(false);
    }



}
