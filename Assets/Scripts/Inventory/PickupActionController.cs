using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InventoryItemController))]
public class PickupActionController : TriggerController
{
    public bool deleteOrigin;
    private InventoryItemController _item;
    void Start(){
        _item = GetComponent<InventoryItemController>();
    }
    override public void TriggerAction(GameObject triggerer){
        // Add item to inventory
        InventoryController inv = triggerer.GetComponent<InventoryController>();
        if(inv){
            inv.AddItem(_item);
        }

        // If the pickup item is one-use, delete it after picking up
        if(deleteOrigin){
            Destroy(gameObject);
        }
    }
}
