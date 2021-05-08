using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    // Icon
    public string itemName;
    public string itemDescription;
    
    private static Dictionary<string, int> idLookup;
    private static int idGenerator;
    public int ID 
    { get; set; }

    void Start(){
        if(idLookup == null){
            idLookup = new Dictionary<string, int>();
        }

        if(!idLookup.ContainsKey(name)) {
            idLookup.Add(name, idGenerator++);
        }
        ID = idLookup[name];
    }
}
