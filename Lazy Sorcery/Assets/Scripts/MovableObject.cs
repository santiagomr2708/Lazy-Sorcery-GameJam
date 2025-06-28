using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public float distance = 2f;    // cuánto se mueve a cada lado
    public float speed = 2f;       // velocidad de ida y vuelta

    private Vector3 startPos;
    private bool moving = false;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (moving)
        {
            float x = Mathf.PingPong(Time.time * speed, distance) - (distance / 2f);
            transform.position = startPos + new Vector3(x, 0, 0);
        }
    }

    public void StartMoving()
    {
        moving = true;
    }
}

