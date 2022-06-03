using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeciliEl : MonoBehaviour
{
    El el;
    Envanter env;
    OyunAyarlarý oyunayarlari;

    public GameObject[] prewievs;

    int slotsayi;

    private void Awake()
    {
        el = GameObject.FindGameObjectWithTag("Player").GetComponent<El>();
        oyunayarlari = GameObject.FindGameObjectWithTag("Player").GetComponent<OyunAyarlarý>();
        env = GameObject.FindGameObjectWithTag("envanter").GetComponent<Envanter>();
    }
    void Update()
    {
        slotsayibelirle();
        itemsec(env.itemss[slotsayi]);
    }

    void itemsec(Item item)
    {
        for (int i = 0; i < el.objeler.Count; i++)
        {
            if (el.objeler[i].name == item.itemismi && oyunayarlari.envanteracik == false)
            {
                el.objeler[i].SetActive(true);
                break;       
            }
            else
            {
                el.objeler[i].SetActive(false);

                for (int j = 0; j < prewievs.Length; j++)
                {
                    prewievs[j].SetActive(false);
                }
            }
        }
    }

    void slotsayibelirle()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slotsayi = 0; ;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slotsayi = 1; ;
        }

    }
}
