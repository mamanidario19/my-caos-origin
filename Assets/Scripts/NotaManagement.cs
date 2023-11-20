using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotaManagement : MonoBehaviour
{
    public float interactionDistance = 1f;
    public GameObject notaCanvas; // Asigna el objeto Canvas en Unity que contiene los mensajes.
    private Transform player;
    private bool isNoteActive = false;
    private AudioClip agarrar;
    void Start()
    {
        // Busca el GameObject con la etiqueta "Player" y obtiene su transform.
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("No se encontr� el jugador en la escena.");
        }
        if (notaCanvas == null)
        {
            Debug.LogError("Asigna el objeto Canvas en el inspector de Unity.");
        }
    }

    void Update()
    {
        // Verifica si el jugador est� lo suficientemente cerca y presiona la tecla "E".
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerInRange())
        {
            // Llama a la funci�n para hacer que la nota desaparezca.
            InteractWithNote();
        }
    }

    bool IsPlayerInRange()
    {
        // Calcula la distancia entre el jugador y la nota.
        float distance = Vector2.Distance(transform.position, player.position);
        Debug.Log("Distancia al jugador: " + distance);
        // Retorna true si el jugador est� dentro de la distancia de interacci�n.
        return distance <= interactionDistance;
    }

    void InteractWithNote()
    {
        if (notaCanvas != null)
        {
            // Activa o desactiva el Canvas que contiene los mensajes.

            AudioManager.Instance.EjecutarSonido(agarrar);
            notaCanvas.SetActive(!isNoteActive);
            isNoteActive = !isNoteActive;
            player.GetComponent<PlayerMovement>().enabled = false;
        }
        else
        {
            Debug.LogError("El objeto Canvas no est� asignado.");
        }
    }

    public void CloseNote()
    {
        // Cierra la nota cuando se hace clic en el bot�n de cerrar.
        if (notaCanvas != null)
        {
            notaCanvas.SetActive(false);
            isNoteActive = false;
            player.GetComponent<PlayerMovement>().enabled = true;
            Destroy(gameObject);
        }
    }
}
