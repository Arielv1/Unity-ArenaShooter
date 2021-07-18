using UnityEngine;
using System.Threading.Tasks;

public class GameController : MonoBehaviour
{

    public GameOverScreen GameOverScreen;
    public GameObject victoryUI;
    
    bool gameHasEnded = false;

    public void Victory()
    {
        Debug.Log("Match Won!");
        victoryUI.SetActive(true);
    }

    public void GameOver()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            GameOverScreen.Setup();
        }
    }
    public void checkVictory()
    {
        Debug.Log("checkGameOverForEnemies called");
        
        GameObject Enemy = GameObject.FindWithTag("Enemy");
        GameObject theEnemyCommander = GameObject.FindWithTag("Enemy Commander");
        if(theEnemyCommander == null && Enemy == null)
        {
            Victory();
        }
        // Debug.Log("There are still enemies in the game.");
        return;
    }
}
