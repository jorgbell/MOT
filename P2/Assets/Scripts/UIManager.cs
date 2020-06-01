using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Image[] fullLives;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.setUIManager(this);        
    }

    // Update is called once per frame
    public void UpdateScore(int points)
    {
        scoreText.text = points.ToString();
    }
    public void LifeLost(int nLives)
    {
        fullLives[nLives].enabled = false;
    }

}
