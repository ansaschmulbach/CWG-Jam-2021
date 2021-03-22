using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public Camera cam1; 
    public Camera cam2;
 
    public Player player1;
    public Player player2;
  
    void Start()
    {
        
        Camera[] cams = FindObjectsOfType<Camera>();
        cam1 = cams[0];
        cam2 = cams[1];
        
        cam1.enabled = true;
        cam2.enabled = false;
        
        
         Player [] players = FindObjectsOfType<Player>();
         player1 = players[0];
         player2 = players[1];
        
         player1.enabled = true;
         player1.GetComponent<PlayerMovement>().enabled = true;
        player1.GetComponent<PlayerInteract>().enabled = true;
        player2.enabled = false;
         player2.GetComponent<PlayerMovement>().enabled = false;
        player2.GetComponent<PlayerInteract>().enabled = false;

    }
   
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;


            // disable player 1 and enable player 2 and vice versa
            
            player1.enabled = !player1.enabled;
            player1.GetComponent<PlayerMovement>().enabled = !player1.GetComponent<PlayerMovement>().enabled;
            player1.GetComponent<PlayerInteract>().enabled = !player1.GetComponent<PlayerInteract>().enabled;
            player2.enabled = !player2.enabled;
            player2.GetComponent<PlayerMovement>().enabled = !player2.GetComponent<PlayerMovement>().enabled;
            player2.GetComponent<PlayerInteract>().enabled = !player2.GetComponent<PlayerInteract>().enabled;

        }
    }
}
