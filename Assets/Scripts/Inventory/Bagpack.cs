using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bagpack : MonoBehaviour {
    
    public GameObject inventory;
    private Animator inventoryAnim;

    void Start() {
        inventoryAnim = inventory.GetComponent<Animator>();
    }

    public void OpenBagpack() {
        if (!inventory.activeSelf) {
            inventory.SetActive(true);
        } else {
            inventoryAnim.SetTrigger("Close");
            Invoke("DeactivateInventory", 0.3f);
        }
    }

    void DeactivateInventory() {
        inventory.SetActive(false);
    }

}
