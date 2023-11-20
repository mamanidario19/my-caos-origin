using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puzzleManager : MonoBehaviour
{
    // Referencia al Transform del objeto A
    public Transform objetoATransform;
 
    // Referencia al Transform del jugador
    public Transform jugadorTransform;

    // Referencia al Canvas que contiene el minijuego
    public Canvas canvasMinijuego;

    // Lista de referencias a los tres objetos a monitorear
    public List<Image> imagenesParaMonitorear;

    public Text mensajeTexto;

    private bool minijuegoActivo = false;
    private bool mensajeMostrado = false;
    private void Start()
    {
        
        // Aseg�rate de que las referencias est�n asignadas antes de iniciar el juego
        if (objetoATransform == null || jugadorTransform == null || canvasMinijuego == null)
        {
            Debug.LogError("Falta asignar referencias en el PuzzleManager. Por favor, asigna las referencias desde el Inspector.");
            return;
        }

        // Desactiva el Canvas al iniciar el juego
        canvasMinijuego.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Verifica la posici�n del jugador y del objeto A en cada frame
        VerificarPosiciones();
    }

    private void VerificarPosiciones()
    {
        // Verifica si las posiciones del objeto A y del jugador est�n lo suficientemente cerca
        if (!minijuegoActivo && Vector3.Distance(objetoATransform.position, jugadorTransform.position) < 1.0f)
        {
            Debug.LogError("Abriendo puzzle.");

            // Activa el Canvas cuando las posiciones est�n lo suficientemente cerca
            ActivarMinijuego();
        }

    }

    // M�todo para activar el Canvas del minijuego
    public void ActivarMinijuego()
    {
        if (!minijuegoActivo)
        {
            canvasMinijuego.gameObject.SetActive(true);
            DesactivarObjetoColisionado();
            minijuegoActivo = true;

            // No es necesario iniciar la corutina, simplemente llama a DesactivarMinijuego despu�s de esperar 2 segundos
            Invoke("DesactivarMinijuego",1f);
        }
    }

    // M�todo para desactivar el objeto con el que colisionas
    private void DesactivarObjetoColisionado()
    {
        // Desactiva el Canvas cuando se llama a este m�todo
       // canvasMinijuego.gameObject.SetActive(false);
        minijuegoActivo = false;

        // Verifica si todos los objetos son visibles y el mensaje a�n no se ha mostrado
        if (ObjetosActivosYVisibles() && !mensajeMostrado)
        {
            // Muestra el mensaje "�Bien hecho!" y marca el mensaje como ya mostrado
            MostrarMensaje("�Bien hecho!");
            mensajeMostrado = true;
        }
    }

    // M�todo para desactivar el Canvas del minijuego
    public void DesactivarMinijuego()
    {
        // Desactiva el Canvas cuando se llama a este m�todo
        canvasMinijuego.gameObject.SetActive(false);
        minijuegoActivo = false;
    }

    // M�todo para verificar si los tres objetos est�n activos y visibles
    private bool ObjetosActivosYVisibles()
    {
        foreach (var imagen in imagenesParaMonitorear)
        {
            if (imagen == null || !imagen.gameObject.activeSelf || !EsVisible(imagen))
            {
                return false;
            }
        }
        return true;

    }

    // M�todo para verificar si una imagen es visible en el Canvas
    private bool EsVisible(Image imagen)
    {
        if (imagen == null)
        {
            return false;
        }

        // Verifica si la imagen est� activa en el Canvas
        if (!imagen.IsActive())
        {
            return false;
        }

        // Puedes agregar otras verificaciones espec�ficas de las im�genes aqu� si es necesario

        return true;
    }

    private void MostrarMensaje(string mensaje)
    {
        // Aqu� puedes implementar la l�gica para mostrar el mensaje en pantalla
        // Puedes utilizar UI Text, un panel con texto, o cualquier otro m�todo que prefieras
        mensajeTexto.gameObject.SetActive(true);
    }
}
