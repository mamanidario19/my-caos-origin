using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Obtén la entrada del teclado.
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcula el vector de movimiento.
        Vector2 movimiento = new Vector2(movimientoHorizontal, movimientoVertical);

        // Normaliza el vector de movimiento para evitar movimientos más rápidos en diagonales.
        movimiento.Normalize();

        // Mueve al jugador.
        MoverJugador(movimiento);
    }

    void MoverJugador(Vector2 direccion)
    {
        // Mueve al jugador utilizando el Rigidbody2D.
        rb.velocity = new Vector2(direccion.x * speed, direccion.y * speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el jugador choca con una pared.
        if (collision.gameObject.CompareTag("Borde"))
        {
            // Detiene el movimiento del jugador cuando choca con una pared.
            rb.velocity = Vector2.zero;
            Debug.Log("Chocó con una pared.");
        }
    }
}
