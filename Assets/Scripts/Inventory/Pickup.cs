using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private Inventory inventory;
    private GameObject pressButton;
    public GameObject itemButton;

    public Items ID = default;

    private const KeyCode USE_BUTTON = KeyCode.E;
    private bool nearToItem = false;

    void Start() {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        pressButton = GameObject.Find("Canvas").transform.Find("Press Button").gameObject;
    }

    void Update() {
        if (nearToItem && Input.GetKeyDown(USE_BUTTON))
        {
            for (int i = 0; i < inventory.slots.Count; i++) 
            {
                if (inventory.isFull[i] == false) 
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);

                    if (ID == Items.Scrap)
                        inventory.scrapAmount++;

                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            pressButton.SetActive(true);
            nearToItem = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            pressButton.SetActive(false);
            nearToItem = false;
        }
    }

}
