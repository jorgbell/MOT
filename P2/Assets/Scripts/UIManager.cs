using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Image[] fullLives;
    public Text scoreText,finishText;
    public GameObject finishPanel;
    void Start()
    {
        GameManager.instance.setUIManager(this);        //realizamos el saludo para indicar al gamemanager de la existencia de una UI
    }

    //método que modifica lo que se lee en el medidor de puntos
    public void UpdateScore(int points)
    {
        scoreText.text = points.ToString();
    }

    //método que elimina una vida del medidor de vidas
    public void LifeLost(int nLives)
    {
        fullLives[nLives].enabled = false;
    }

    //método que indica qué debe ocurrir cuando se acaba una pantalla
    public void FinishGame(bool playerWins)
    {
        if (finishPanel != null && finishText != null) //en caso de que queramos que haya diferencia entre ganar o perder y aparezca en pantalla
        {
            Time.timeScale = 0;//paramos el timescale para evitar que exista un input en el juego durante esta pantalla de ganar o perder
            if (playerWins)
                finishText.text = "Has Ganado";
            else
                finishText.text = "Has Perdido";
            finishPanel.SetActive(true);//activamos el panel que nos permitirá volver al menú
        }
        else
            GameManager.instance.ChangeScene("9_Menu");//si en la escena no existen paneles, será en una escena de Test y hará un pase automático
    }

    //método que indica cuántas vidas le quedan al jugador cuando se inicia un nuevo nivel
    public void RemainingLives(int lives)
    {
        for(int i = lives; i<3; i++)
            fullLives[i].enabled = false;
    }

}
