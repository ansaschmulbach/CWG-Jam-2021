using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHunger = 100f;
    public float hungerSpeed;
    public float currentHunger;
    public Hunger hungerBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHunger = maxHunger;
        hungerBar.SetMaxHunger(maxHunger);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage((float)Time.deltaTime * hungerSpeed);

    }
    
    void TakeDamage(float damage)
    {
        currentHunger -= damage;
        hungerBar.SetHunger(currentHunger);
    }

        
        
    public void GainHealth(float gain)
    {
        currentHunger += gain;
        hungerBar.SetHunger(currentHunger);
    }
        //add function so that when health reaches 0, play defeat screen and start game over.
    
}
