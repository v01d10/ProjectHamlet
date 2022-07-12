using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]
public class EquipmentObject : ItemObject
{
    public float DeffenseBonus;
    public float HealthBonus;
    public float AtkBonus;
    public float AtkSpdBonus;

    public void Awake()
    {
        type = ItemType.Equipment;
    }
}
