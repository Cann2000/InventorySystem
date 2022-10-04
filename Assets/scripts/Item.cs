using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Item
{

    public string ItemName, ItemInformation;
    public int ItemId, ItemAmount, ItemStockAmount, ItemDamage;

    public Sprite ItemIcon;
    public ItemType itemType;

    public enum ItemType
    {
        Empty,
        Weapon,
        Material,
        Food,
        Health,
        Build

    }
    public Item(string name, string information, int id, int amount, int stockamount, int damage, ItemType type)
    {
        ItemName = name;
        ItemInformation = information;
        ItemId = id;
        ItemAmount = amount;
        ItemStockAmount = stockamount;
        ItemDamage = damage;
        itemType = type;

        ItemIcon = Resources.Load<Sprite>(id.ToString());
    }
    public Item()
    {

    }

}
