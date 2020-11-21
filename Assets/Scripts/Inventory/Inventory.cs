using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    [HideInInspector]
    public int scrapAmount = default;

    [HideInInspector] 
    public List<GameObject> slots = new List<GameObject>();
    
    // To find out which slot is free
    [HideInInspector] 
    public bool[] isFull = null;

    void Awake() {
        int qntSlots = 0;
        Transform inventory = GameObject.Find("Canvas").transform.Find("Inventory");
        
        // Adding each GameObject slot to the list
        foreach(Transform slot in inventory)
            if (slot.CompareTag("Slot")) 
            {
                slots.Add(slot.GetChild(0).gameObject);
                qntSlots++;
            }

        isFull = new bool[qntSlots];

        // Defining the index of each slot
        for (int i = 0; i < slots.Count; i++) {
            slots[i].GetComponent<Slot>().i = i;
        }
    }

}

public enum Items {
    Scrap = 1
}
