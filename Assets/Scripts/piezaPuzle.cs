using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class piezaPuzle : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    Image image;

    public bool pressed;
    public Transform zonaDeInteres;
    public GameObject objetoAActivar;
    // Tolerancia para verificar la zona de interés
    public float toleranciaDeBloqueo = 80f;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
        VerificarZonaDeInteres();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    private void VerificarZonaDeInteres()
    {
        // Convierte las posiciones actuales de la imagen y de la zona de interés a coordenadas del mundo.
        Vector3 posicionImagen = transform.position;
        Vector3 posicionZonaInteres = zonaDeInteres.position;

        // Verifica si las posiciones de la imagen y la zona de interés están lo suficientemente cerca.
        if (Vector3.Distance(posicionImagen, posicionZonaInteres) < toleranciaDeBloqueo)
        {
            Debug.Log("Estoy en la zona correcta.");
            gameObject.SetActive(false);

            if (objetoAActivar != null)
            {
                objetoAActivar.SetActive(true);
            }
        }
    }
}