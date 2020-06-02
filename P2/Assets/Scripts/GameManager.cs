using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int playerLives, playerPoints,nBricks;
    bool lost;
    public static GameManager instance;
    UIManager thisUI;
    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
                }
        else
            Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        nBricks = 0;
        playerLives = 3;
        playerPoints = 0;
        lost = false;
    }

    public void setUIManager(UIManager UI)
    {
        thisUI = UI;
        thisUI.UpdateScore(playerPoints);
        thisUI.RemainingLives(playerLives);
        lost = false;
    }
    public bool PlayerLoseLife()
    {
        playerLives--;
        Debug.Log("Vidas: "+playerLives);
        if (thisUI != null) thisUI.LifeLost(playerLives);
        if (playerLives == 0)
        {
            lost = true;
            LevelFinished(false);
        }
        return (playerLives > 0);
    }
    public void AddPoints(int points)
    {
        playerPoints += points;
        Debug.Log("Puntos: "+playerPoints);
        if (thisUI != null) thisUI.UpdateScore(playerPoints);
    }
    public void AddBrick() 
    {
        nBricks++;
        Debug.Log("Numero Bricks: "+nBricks);
    }
    public void BrickDestroyer()
    {
        nBricks--;
        Debug.Log("Numero Bricks: "+nBricks);
        if (!lost && nBricks == 0)
            LevelFinished(true);
    }
    public void ChangeScene(string name)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(name);        
    }

    void LevelFinished(bool playerWins)
    {
        if (playerWins && SceneManager.GetActiveScene().name == "Level1") ChangeScene("Level2");
        else
        {
            ResetGame();
            if (thisUI != null) thisUI.FinishGame(playerWins);
        }

    }

    void ResetGame()
    {
        playerLives = 3;
        playerPoints = 0;
    }
}
