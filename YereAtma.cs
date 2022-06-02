using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class YereAtma : MonoBehaviour ,IPointerDownHandler
{
    public GameObject objespawn;
    Envanter env;

    
    void Start()
    {
        env = GameObject.FindGameObjectWithTag("envanter").GetComponent<Envanter>();

    }

    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData Data)
    {
        if (Data.button.ToString() == "Left")
        {
            if (env.tasimaAcik)
            {
                yereat(env.tasinanitem);
                env.tasimapanelkapat();
            }
        }
    }
    void yereat(Item Item)
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>(Item.itemid.ToString()),objespawn.transform.position, Resources.Load<GameObject>(Item.itemid.ToString()).transform.rotation);
        obj.GetComponent<Obje>().item = Item;
    }
}
