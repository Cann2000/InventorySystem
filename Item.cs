using UnityEngine;


[System.Serializable]
public class Item
{
    public string itemismi;
    public int itemid, itemmiktar, itemhasar, itemdepomiktar;

    public Sprite itemicon;
    public GameObject itemmodel;
    public ItemType itemtipi;



    public enum ItemType
    {
        bos,
        silah,
        malzeme,
        yiyecek,
        saðlýk,
        yapý
    }

    public Item(int id, string isim, int miktar, int depo, int hasar,ItemType tip)
    {
        itemid = id;
        itemismi = isim;
        itemmiktar = miktar;
        itemdepomiktar = depo;
        itemhasar = hasar;
        itemtipi = tip;

        itemicon = Resources.Load<Sprite>(itemid.ToString());
        itemmodel = Resources.Load<GameObject>(itemid.ToString());
    }

    public Item()
    {

    }
}
