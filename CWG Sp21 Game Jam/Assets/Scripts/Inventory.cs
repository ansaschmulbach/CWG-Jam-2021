using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[10];
    // Start is called before the first frame update
    public void AddItem(GameObject item)
    {

        bool itemAdded = false;

        // Find first open slot in inventory
        for(int i = 0; i < inventory.Length; i++)
        {
            if (inventory [i] == null)
            {
                inventory[i] = item;
                Debug.Log(item.name + " was added");
                itemAdded = true;
                // Do something with the object
                item.SendMessage("DoInteraction");
                break;
            }
        }

        //inventory full
        if(!itemAdded)
        {
            Debug.Log("Inventory Full - item not added");
        }
    } 
    public GameObject FindItemByType(string itemType)
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i] !=null )
            {
                if(inventory[i].GetComponent<Interactable>().itemType == itemType)
                {
                    //We found an item of the type we were looking for
                    return inventory[i];
                }
            }
        }
        //item of type not found
        return null;
    }
    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                //We found the item - remove it
                inventory[i] = null;
                Debug.Log(item.name + " was removed from inventory");
                break;
            }
            
        }
    }
}
