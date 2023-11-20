using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SENSORES1 : MonoBehaviour
{
    public Transform player;
    public GameObject btnPliegue1;
    public GameObject colliders1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player && other.gameObject == colliders1)
        {
            // El jugador ha entrado en colliders1, desactiva btnPliegue1
            btnPliegue1.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player && other.gameObject == colliders1)
        {
            // El jugador ha salido de colliders1, activa btnPliegue1
            btnPliegue1.SetActive(true);
        }
    }
}