using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private List<InventoryItemController> _inventory;
    void Start()
    {
        _inventory = new List<InventoryItemController>();
    }
    public void AddItem(InventoryItemController item){
        // print("Adding item id: " + item.ID);
        _inventory.Add(item);
    }
}
