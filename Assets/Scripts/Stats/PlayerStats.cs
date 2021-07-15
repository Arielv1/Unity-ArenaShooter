using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void Die()
    {
        // end game
        Debug.Log("override called: "+transform.name + " Died.");
        FindObjectOfType<GameController>().GameOver();

    }

}
