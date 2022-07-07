using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inv;

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.I))
       {
            inv.gameObject.SetActive(!inv.gameObject.activeSelf);
       }
    }
}
