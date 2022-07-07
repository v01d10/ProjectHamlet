using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject Inventory;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<GroundItem>();
        if(item)
        {
            Inventory.AddItem(new Item(item.item), 1);
            Destroy(other.gameObject);
        }
    }

    private void Start()
    {
        Inventory.Load();
    }

    private void OnApplicationQuit()
    {
        Inventory.Save();

        Inventory.Container.Items.Clear();
    }
}
