using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractableLibro : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 startPos;
     TareasCompletadas tareasCompletadas;
    Vector3 destinoLibro;
    float velocidadPlatos = 2f;
    
    public bool moving3 = false;


    void Start()
    {
        startPos = transform.position;
        destinoLibro = GameObject.Find("DestinoLibro").transform.position;
        
            
      GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager != null)
        {
        tareasCompletadas = gameManager.GetComponent<TareasCompletadas>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {




        if (moving3)
        {
            Vector3 moverVector = Vector3.MoveTowards(startPos, destinoLibro, velocidadPlatos);
            transform.position = moverVector;

            
            if (tareasCompletadas != null)
           {
               tareasCompletadas.CantidadLibros += 1;
           }
            

        }

        if (Vector3.Distance(transform.position, destinoLibro) < 0.01f)
        {
            moving3 = false;
            Destroy(this);
           
        }

    }

    public void StartMoving3()
    {
        moving3 = true;
    }
    
}

