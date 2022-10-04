using UnityEngine;
using System.Collections;
namespace UnityStandardAssets.Characters.FirstPerson;


public class OyunAyarları : MonoBehaviour
{

    public GameObject envanterpanel;

    public bool envanter;

    FirstPersonController fpc;
    public karakter krk;
    public Yan_panel yanpnl;

    void Start()
    {
        envanter = false;
        fpc = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && krk.zaman == 0)
        {
            envanter =! envanter;
        }
        if (envanter)
        {
            yanpnl.enabled = false;
            //fpc.enabled = false;
            envanterpanel.SetActive(true);
            Cursor.visible = true; // mosumuz gözüksün
            Screen.lockCursor = false; // mouse ortaya sabitleme
        }
        else
        {
            yanpnl.enabled = true;
            //fpc.enabled = true;
            envanterpanel.SetActive(false);
            Cursor.visible = false; // mosumuz gözükmesin
            Screen.lockCursor = true; // mouse ortaya sabitle
        }

    }
}
