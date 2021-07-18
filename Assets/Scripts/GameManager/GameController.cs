using UnityEngine;
using System.Threading.Tasks;

public class GameController : MonoBehaviour
{

    public GameOverScreen GameOverScreen;
    bool gameHasEnded = false;
    string winner;

    public void Victory()
    {
        Debug.Log("Match Won!");
    }

    public void GameOver(string theWinner)
    {
        // Debug.Log("GameOver called");
        // maybe will do a message of win or lost of player
        winner = theWinner;
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            GameOverScreen.Setup();
        }
    }
    public void checkGameOverForEnemies()
    {
        Debug.Log("checkGameOverForEnemies called");
        GameObject theEnemyCommander = GameObject.FindWithTag("Enemy Commander");
        if(theEnemyCommander != null)
        {
            Debug.Log("theEnemyCommander is not null");
            return;
        }
        GameObject Enemy = GameObject.FindWithTag("Enemy");
        if(Enemy != null) 
        {
            Debug.Log("Enemy is not null");
            return;
        }
        GameOver("Player");
    }
}
