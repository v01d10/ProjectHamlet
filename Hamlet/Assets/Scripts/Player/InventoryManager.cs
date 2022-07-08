using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inv;

    void Start()
    {
        inv.gameObject.SetActive(false);
    }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.I))
       {
        OpenInventory();
       }
    }

    public void OpenInventory()
    {
        inv.gameObject.SetActive(!inv.gameObject.activeSelf);
    }
}
