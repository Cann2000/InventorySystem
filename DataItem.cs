using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataItem : MonoBehaviour
{
    public List<Item> items;

    private void Awake()
    {
        items.Add(new Item(0, "", 0, 0, 0, Item.ItemType.bos));
        items.Add(new Item(1, "Balta", 1, 1, 0, Item.ItemType.silah));
        items.Add(new Item(2, "Býçak", 1, 1, 0, Item.ItemType.silah));
        items.Add(new Item(3, "Mýzrak", 1, 1, 0, Item.ItemType.silah));
        
    }
}
