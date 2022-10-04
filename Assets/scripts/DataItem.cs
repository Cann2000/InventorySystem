using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataItem : MonoBehaviour
{
    public List<Item> items;

    private void Awake()
    {
        items.Add(new Item("", "", 0, 0, 0, 0, Item.ItemType.Empty));
        items.Add(new Item("Wood", "You can make items from wood", 1, 1, 6, 0, Item.ItemType.Material));
        items.Add(new Item("Axe", "You can cut trees with an axe", 2, 1, 1, 0, Item.ItemType.Weapon));
        items.Add(new Item("Knife", "You can attack with a knife", 3, 1, 1, 0, Item.ItemType.Weapon));
        items.Add(new Item("Spear", "You can attack with a spear", 4, 1, 1, 0, Item.ItemType.Weapon));
        items.Add(new Item("Foundation", "you can build with foundation", 5, 1, 6, 0, Item.ItemType.Build));
        items.Add(new Item("Wall", "you can build with wall", 6, 1, 6, 0, Item.ItemType.Build));
        items.Add(new Item("Roof", "you can build with roof", 7, 1, 6, 0, Item.ItemType.Build));
        items.Add(new Item("Meat", "quenches hunger", 8, 1, 1, 0, Item.ItemType.Food));
        items.Add(new Item("Hamburger", "quenches hunger", 9, 1, 1, 0, Item.ItemType.Food));
        items.Add(new Item("Cheese", "quenches hunger", 10, 1, 1, 0, Item.ItemType.Food));
        items.Add(new Item("Banana", "quenches hunger", 11, 1, 10, 0, Item.ItemType.Food));
        items.Add(new Item("Watermelon", "quenches hunger and thirst", 12, 1, 1, 0, Item.ItemType.Food));
        items.Add(new Item("Milk", "quenches thirst", 13, 1, 1, 0, Item.ItemType.Food));
        items.Add(new Item("Health Kit", "It is useful to replenish life", 14, 1, 1, 0, Item.ItemType.Health));

    }

}
