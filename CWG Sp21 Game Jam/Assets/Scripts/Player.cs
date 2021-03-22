using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHunger = 100f;
    public float currentHunger;
    public Hunger hungerBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHunger = maxHunger;
        hungerBar.SetMaxHunger(maxHunger);
        //
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(2);
        }
      
        //Timer stuff 
        
        TakeDamage((float)Time.deltaTime);

       
        /*
        else
        {
            Time.timeScale = 0;
        }
        */
        void TakeDamage(float damage)
        {
            currentHunger -= damage;
            hungerBar.SetHunger(currentHunger);
        }

        //add functions to increase health, can replace if argument with collect resources later
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (maxHunger - currentHunger >= 5) {
                GainHealth(5);
            } else
            {
                GainHealth(maxHunger - currentHunger);
            }
        }
        
        void GainHealth(float gain)
        {
            currentHunger += gain;
            hungerBar.SetHunger(currentHunger);
        }
        //add function so that when health reaches 0, play defeat screen and start game over.
    }
}
