using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public bool inventory;  //if true this object can be stored in inventory
    public string itemType; //tells what type of item this object is
    
    public void DoInteraction()
    {
        //Pick up and put in inventory
        gameObject.SetActive(false);
    }
    
}
