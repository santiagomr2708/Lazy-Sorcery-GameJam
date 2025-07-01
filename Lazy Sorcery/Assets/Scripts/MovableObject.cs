using UnityEngine;

public class MovableObject : MonoBehaviour
{
    [Header("Destino (rellénalos en el Inspector)")]
    public float positionX;
    public float positionY;
    public float positionZ;

    [Header("Movimiento")]
    public float speed = 2f;    // unidades por segundo

    private Vector3 targetPos;
    private bool moving = false;

    // Llamar desde PlayerInteraction
    public void StartMoving()
    {
        // Calcula el Vector3 destino con los valores del Inspector
        targetPos = new Vector3(positionX, positionY, positionZ);
        moving = true;
    }

    void Update()
    {
        if (!moving) return;

        // Mueve hacia targetPos
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            speed * Time.deltaTime
        );

        // Si llegó, para el movimiento
        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
            moving = false;
    }
}



