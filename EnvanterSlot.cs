using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class EnvanterSlot : MonoBehaviour , IPointerDownHandler
{
    public Item item;
    public int slotsayi;
    Envanter env;

    public Image itemicon;
    public TextMeshProUGUI itemmiktar;

    void Start()
    {
        env = GameObject.FindGameObjectWithTag("envanter").GetComponent<Envanter>();
    }

    void Update()
    {
        
        item = env.itemss[slotsayi];

        if (item.itemismi != null)
        {
            itemicon.enabled = true;
            itemicon.sprite = item.itemicon;
            if (item.itemmiktar > 1)
            {
                itemmiktar.enabled = true;
                itemmiktar.text = item.itemmiktar.ToString();
            }
            else
            {
                itemmiktar.enabled = false;
            }
        }
        else
        {
            itemicon.enabled = false;
            itemmiktar.enabled = false;

        }
    }


    // taþýma iþlemi

    public void OnPointerDown(PointerEventData Data)
    {
        if (Data.button.ToString() == "Left")
        {
            if (!env.tasimaAcik && item.itemismi != null)
            {
                env.itemss[slotsayi] = new Item();// týkladýðýmýz yeri boþ obje yap
                env.tasimapanelaç(item);
            }
            //else if (env.tasimaAcik)
            //{
            //    if (item.itemismi == null && env.tasinanitem.itemtipi == Item.ItemType.malzeme)
            //    {
            //        env.itemss[Carslot] = env.tasinanitem;
            //    }
            //}
            else if (env.tasimaAcik)
            {
                if (item.itemismi == null)
                {
                    env.itemss[slotsayi] = env.tasinanitem;
                    env.tasimapanelkapat();
                }

                else
                {
                    if (item.itemismi == env.tasinanitem.itemismi)
                    {
                        if (item.itemtipi == Item.ItemType.yiyecek || item.itemtipi == Item.ItemType.malzeme || item.itemtipi == Item.ItemType.yapý)
                        {
                            env.itemss[slotsayi].itemmiktar += env.tasinanitem.itemmiktar;
                            env.tasimapanelkapat();
                        }
                    }
                    else
                    {
                        Item Yeni_Item = env.itemss[slotsayi];
                        env.itemss[slotsayi] = env.tasinanitem;
                        env.tasinanitem = Yeni_Item;
                    }
                }
            }

        }
    }
}
