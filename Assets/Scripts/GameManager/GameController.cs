using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameOverScreen GameOverScreen;
    bool gameHasEnded = false;

    public void Victory()
    {
        Debug.Log("Match Won!");
    }

    public void GameOver()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            GameOverScreen.Setup();
        }
    }
}
