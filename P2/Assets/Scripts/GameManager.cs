using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int playerLives, playerPoints,nBricks;
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
        playerLives = 3;
        playerPoints = 0;
        nBricks = 0;
        if (thisUI != null) thisUI.UpdateScore(playerPoints);
    }

    public void setUIManager(UIManager UI)
    {
        thisUI = UI;
    }
    public bool PlayerLoseLife()
    {
        playerLives--;
        Debug.Log("Vidas: "+playerLives);
        if (thisUI != null) thisUI.LifeLost(playerLives);
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
    }
}
