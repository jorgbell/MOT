using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int playerLives, playerPoints,nBricks;      
    bool lost;      //variable de control para poder hacer el paso de nivel
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
    void Start()
    {
        //inicializamos todas las variables en el start para cuando se inicialice el Gamemanager.
        nBricks = 0;
        playerLives = 3;
        playerPoints = 0;
        lost = false;
    }

    //Saludo (setter) del UI Manager de la escena
    public void setUIManager(UIManager UI)
    {
        thisUI = UI;
        thisUI.UpdateScore(playerPoints);   //Aprovechamos el saludo de la UI para hacer la primera comprobación de la puntuación y las vidas
        thisUI.RemainingLives(playerLives);
        lost = false;   //Aprovechamos también el saludo para re-inicializar esta variable debido a que una nueva UI == cambiar de nivel
    }

    //método que sirve para restar una vida, dar acciones en el caso de que no nos queden vidas, e indicar a la bola si puede o no reaparecer en pantalla
    public bool PlayerLoseLife()
    {
        playerLives--;
        Debug.Log("Vidas: "+playerLives);
        if (thisUI != null) //Si existe una UI, restar vidas además modifica ésta, y existirá la posibilidad de reiniciar la partida
        {
            thisUI.LifeLost(playerLives);
            if (playerLives == 0)   //Hacemos esta comprobación aquí dentro ya que si no tiene la UI, no queremos que se haga el método resetGame
            {
                lost = true;    //lost=true permite que la destrucción de los bloques al cambiar de escena no se identifique como una victoria
                LevelFinished(false);
            }
        }
        return (playerLives > 0);
    }

    //método que se llama cada vez que se gana puntos
    public void AddPoints(int points)
    {
        playerPoints += points;
        Debug.Log("Puntos: "+playerPoints);
        if (thisUI != null) thisUI.UpdateScore(playerPoints);   //Si existe una UI, quitamos un corazón
    }

    //método que se llama cada vez que se crea un bloque
    public void AddBrick() 
    {
        nBricks++;
        Debug.Log("Numero Bricks: "+nBricks);
    }

    //método que se llama cada vez que se destruye un bloque, además de identificar qué hacer en caso de que se llegue a una victoria acabando con todos los bloques
    public void BrickDestroyer()
    {
        nBricks--;
        Debug.Log("Numero Bricks: "+nBricks);
        if (thisUI != null && !lost && nBricks == 0)    //sólo reiniciaremos en el caso de haber UI Y que se destruyan todos los bloques DEBIDO A UNA VICTORIA, no al cambio de escena
            LevelFinished(true);
    }

    //método para cambiar de escenas
    public void ChangeScene(string name)
    {
        Time.timeScale = 1; //Reiniciamos el timescale por si se ha modificado en otra escena
        SceneManager.LoadScene(name);        
    }

    //método que nos indica qué debe ocurrir una vez se ha acabado una pantalla
    void LevelFinished(bool playerWins)
    {
        //si el jugador se encuentra en la escena de Nivel1 y gana, debe hacer un pase automático a la anterior sin resetear los valores de puntuación ni vidas.
        if (playerWins && SceneManager.GetActiveScene().name == "Level1") ChangeScene("Level2");
        else //en caso contrario, podrá ganar o perder, pero tendrá que pausar y resetear el juego
        {
            ResetGame();
            thisUI.FinishGame(playerWins);
        }

    }

    //método auxiliar para reiniciar las variables de vidas y puntos
    void ResetGame()
    {
        playerLives = 3;
        playerPoints = 0;
    }
}
