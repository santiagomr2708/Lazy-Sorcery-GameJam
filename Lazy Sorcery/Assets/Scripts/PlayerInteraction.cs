using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Camera cam;               // Arrastra aquí tu Main Camera
    public float maxDistance = 10f;  // Alcance del rayo

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            TryInteract();
    }

    void TryInteract()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                // Busca un componente Movable en el objeto golpeado
                var m = hit.collider.GetComponent<MovableObject>();
                if (m != null)
                    m.StartMoving();
            }
        }
    }
}

