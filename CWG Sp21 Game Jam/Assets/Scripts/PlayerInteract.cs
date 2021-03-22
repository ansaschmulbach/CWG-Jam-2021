using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    public GameObject currentInterObj = null;
    public Interactable currentInterObjScript = null;
    public Inventory inventory;
    //
    public Player player1;
    public Player player2;
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.E) && currentInterObj)
        {
            // check to see if this object is to be stored in inventory
            if(currentInterObjScript.inventory)
            {
                inventory.AddItem(currentInterObj);
            }

            
        }
        //Use item 1 with the '1' key
        
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Check the inventory for item 1
            GameObject item1 = inventory.FindItemByType("item1");
            if(item1 != null)
            {
                //Use the item
                player1.GainHealth(5);
                //Teleport the item

                //Remove item from inventory
                inventory.RemoveItem(item1);
            }

            
        }

        //Use item 2 with the '2' key

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Check the inventory for item 2
            GameObject item2 = inventory.FindItemByType("item2");
            if (item2 != null)
            {
                //Use the item

                //Teleport the item
                //test
                player2.GainHealth(5);
                //Remove item from inventory
                inventory.RemoveItem(item2);
            }


        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<Interactable>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            if(other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
            
        }
    }
}
