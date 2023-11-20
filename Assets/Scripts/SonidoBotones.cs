using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonidoBotones : MonoBehaviour
{
    public AudioClip miAudioClip;
    private AudioSource miAudioSource;

    void Start()
    {
        miAudioSource = GetComponent<AudioSource>();

        // todos los botones en la escena.
        Button[] botones = FindObjectsOfType<Button>();

        // ReproducirSonidoOnClick cada botón.
        foreach (Button boton in botones)
        {
            boton.onClick.AddListener(ReproducirSonidoOnClick);
        }
    }


    void ReproducirSonidoOnClick()
    {
        // Verifica si el AudioSource y el AudioClip son válidos antes de reproducir el sonido.
        if (miAudioSource != null && miAudioClip != null)
        {
            // Reproduce el sonido.
            miAudioSource.PlayOneShot(miAudioClip);
        }
    }
}