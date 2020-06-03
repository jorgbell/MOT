﻿// ----------------------------------------------------------
// Material adicional de la práctica 2
// Motores de Videojuegos - FDI - UCM
// ----------------------------------------------------------
// Profesores: Marco Antonio Gómez Martín
//             Eva Ullán
// ----------------------------------------------------------

using UnityEngine;

/// <summary>
/// Componente utilizado para activar power-up's del jugador
/// cuando el objeto al que pertenecemos colisiona con él.
/// </summary>
/// Permite configurar el nombre del power-up (que coincidirá
/// con el nombre del componente que lo implementa).
/// 
/// El GameObject debería pertenecer a una capa física
/// que únicamente colisiona con el jugador. Si el componente
/// detecta una colisión con cualquier cosa que no sea el
/// jugador (capa física "Player"), dará un aviso y no hará
/// nada.
/// Para funcionar el GameObject del jugador debe tener
/// el componente que gestiona los power-up's (PowerUpManager)
public class ActivatePowerUpOnCollision : MonoBehaviour {

    [SerializeField]
    string powerUpName = null;

    int playerLayer;

    void Start() {

        if (powerUpName == null) {
            Debug.Log("Olvidaste configurar el nombre del power-up, así que me desactivo.");
            this.enabled = false;  
        } else {
            // Identificador de la capa física "Player"
            playerLayer = LayerMask.NameToLayer("Player");
        }
        
    }

    void OnCollisionEnter2D(Collision2D info) {

        GameObject other = info.gameObject; 

        if (other.layer != playerLayer) {
            Debug.Log("Un power-up se ha chocado con algo distinto al jugador." 
                + " Debes tener mal la configuración de las capas de colisión.");
            return;
        }

        PowerUpManager pum = other.GetComponent<PowerUpManager> ();

        if (pum == null) {
            Debug.Log("Jugador sin gestor de power-ups." 
                + " Se ignora el power-up conseguido.");
        }
        else {
            pum.ActivatePowerUp (powerUpName);
        }
    }
}
