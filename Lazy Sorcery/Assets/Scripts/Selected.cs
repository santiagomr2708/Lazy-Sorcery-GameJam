using UnityEngine;

public class Selected : MonoBehaviour
{
    LayerMask mask;
    public float distancia = 1.5f;


    void Start()
    {
        mask = LayerMask.GetMask("Raycast Detect");
    }

    
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, mask))
        {
            if (hit.collider.tag == "Interactive Object")
            {
                hit.collider.transform.GetComponent<InteractiveObject>().ActivarObjeto();
            }
        }
    }
}
