using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public override void Die()
    {
        // end game
        Debug.Log("override called: "+transform.name + " Died.");
        FindObjectOfType<GameController>().GameOver();
    }

}
