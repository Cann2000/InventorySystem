using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Envanter : MonoBehaviour
{
    public List<Item> itemss;
    DataItem dataitem;

    public Item tasinanitem;

    public GameObject tasimapanel;
    public bool tasimaAcik;


    public int bosslotmiktar;

    private void Awake()
    {
        dataitem = GameObject.FindGameObjectWithTag("dataitem").GetComponent<DataItem>();

        for (int i = 0; i < bosslotmiktar; i++)
        {
            itemss.Add(new Item());
        }
    }

    void Start()
    {
        itemekle(1, 3);
        itemekle(3, 1);
    }

    void Update()
    {
        if (tasimaAcik)
        {
            tasimapanel.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = tasinanitem.itemicon;
            tasimapanel.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0); //image mousu takip etsin

            if (tasinanitem.itemmiktar > 1)
            {
                tasimapanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
                tasimapanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = tasinanitem.itemmiktar.ToString();
            }
                        else
            {
                tasimapanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
    }

    public void itemekle(int id, int miktar)
    {
        for (int i = 0; i < dataitem.items.Count; i++)
        {
            if (dataitem.items[i].itemid != id)
            {
                continue;
            }

            Item yeni_item = new Item(dataitem.items[i].itemid, dataitem.items[i].itemismi, miktar, dataitem.items[i].itemdepomiktar, dataitem.items[i].itemhasar, dataitem.items[i].itemtipi);

            if (yeni_item.itemtipi == Item.ItemType.yiyecek || yeni_item.itemtipi == Item.ItemType.malzeme || yeni_item.itemtipi == Item.ItemType.yapý || yeni_item.itemtipi == Item.ItemType.saðlýk)
            {
                slotunüzerineekle(yeni_item);
            }

            else if (yeni_item.itemmiktar > 1)
            {
                int deger = yeni_item.itemmiktar - 1;
                Item yeni_item2 = new Item(dataitem.items[i].itemid, dataitem.items[i].itemismi, deger, dataitem.items[i].itemdepomiktar, dataitem.items[i].itemhasar, dataitem.items[i].itemtipi);
                yeni_item.itemmiktar = 1;


                BosSlotItemEkle(yeni_item);
                itemekle(yeni_item2.itemid, yeni_item2.itemmiktar);
            }
            else
            {
                BosSlotItemEkle(yeni_item);
            }
        }
    }

    public void slotunüzerineekle(Item item)
    {
        for (int i = 0; i < itemss.Count; i++)
        {
            if (itemss[i].itemismi == item.itemismi)
            {
                itemss[i].itemmiktar += item.itemmiktar;
                break;
            }
            if (i == itemss.Count - 1)
            {
                BosSlotItemEkle(item);
            }
        }
    }

    public void BosSlotItemEkle(Item ýtem)
    {
        for (int i = 2; i < itemss.Count; i++)
        {
            if (itemss[i].itemismi == null)
            {
                itemss[i] = ýtem;
                break;
            }
        }
    }

    public void tasimapanelaç(Item item)
    {
        tasimaAcik = true;
        tasinanitem = item;
        tasimapanel.SetActive(true);
    }

    public void tasimapanelkapat()
    {
        tasimaAcik = false;
        tasinanitem = null;
        tasimapanel.SetActive(false);
    }
}
