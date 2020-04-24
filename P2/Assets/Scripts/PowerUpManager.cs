﻿// ----------------------------------------------------------
// Material adicional de la práctica 2
// Motores de Videojuegos - FDI - UCM
// ----------------------------------------------------------
// Profesores: Marco Antonio Gómez Martín
//             Eva Ullán
// ----------------------------------------------------------

using UnityEngine;

/// <summary>
/// Componente pensado para ser añadido al jugador para gestionar
/// sus power-up's.
/// </summary>
/// Cada power-up es implementado con un componente distinto.
/// Un power-up estará habilitado si su componente está activado.
/// Por lo tanto todos los componentes que implementan power-up's
/// estarán deshabilitados desde el principio.
/// Este componente (en el jugador) añade un método ActivatePowerUp(string)
/// que recibe el nombre del power-up a activar (debe coincidir con
/// el nombre del componente) y lo activa. Si había un power-up previo
/// activo, lo desactiva.
public class PowerUpManager : MonoBehaviour {

    MonoBehaviour currentPowerUp;

    public void ActivatePowerUp (string powerUpName) {

        // Localiza el componente powerUpName asociado 
        MonoBehaviour powerUp = GetComponent (powerUpName) as MonoBehaviour;

        if (powerUp == null) {
            Debug.Log("Componente power-up " + powerUpName + " no encontrado. Se ignora.");
            return;
        }

        if (powerUp == currentPowerUp)
            // Ya está activo
            return;

        if (currentPowerUp != null)
            // Desactiva el power-up activo
            currentPowerUp.enabled = false;

        // Activa el power-up indicado
        powerUp.enabled = true;
        currentPowerUp = powerUp;

        Debug.Log("Componente power-up " + powerUpName + " activado.");
    }
}
