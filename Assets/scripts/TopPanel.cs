using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class TopPanel : MonoBehaviour
{
    [SerializeField] List<GameObject> Slots;

    public Sprite EmptySlot, SelectedSlot;


    void Update()
    {
        buildChoose();
    }

    void buildChoose()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            SetIcon(0);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetIcon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            SetIcon(2);

        }        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            SetIcon(3);

        }
    }

    void SetIcon(int SlotNumber)
    {
        for (int i = 0; i < Slots.Count; i++)
        {
            Slots[i].GetComponent<Image>().sprite = EmptySlot;
        }

        Slots[SlotNumber].GetComponent<Image>().sprite = SelectedSlot;
    }

}
