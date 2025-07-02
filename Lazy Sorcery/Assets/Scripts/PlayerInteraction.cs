using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Camera cam;               // Arrastra aqu� tu Main Camera
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
            if (hit.collider.CompareTag("Vacuum"))
            {
                var vac = hit.collider.GetComponent<VacuumAgent>();
                if (vac != null)
                    vac.StartMoving();
            }
            else if (hit.collider.CompareTag("Interactable"))
            {
                // Busca un componente Movable en el objeto golpeado
                var m = hit.collider.GetComponent<MovableObject>();
                if (m != null)
                    m.StartMoving();

                var a = hit.collider.GetComponent<Interactuable2>();
                if (a != null)
                {
                    a.StartMoving2();

                }
                var b = hit.collider.GetComponent<InteractableLibro>();
                if (b != null)
                {
                    b.StartMoving3();

                }
                var c = hit.collider.GetComponent<InteractableBotella>();
                if (c != null)
                {
                    c.StartMoving4();

                } 
                var d = hit.collider.GetComponent<InteractableEstufa>();
                if (d != null)
                {
                    d.StartMoving5();
                    
                }     
            }
        }
    }
}

