using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractableBotella : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 startPos;
     TareasCompletadas tareasCompletadas;
    Vector3 destinoBotella;
    float velocidadBotella = 2f;
    
    public bool moving4 = false;


    void Start()
    {
        startPos = transform.position;
        destinoBotella = GameObject.Find("DestinoBotella").transform.position;
        
            
      GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager != null)
        {
        tareasCompletadas = gameManager.GetComponent<TareasCompletadas>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {




        if (moving4)
        {
            Vector3 moverVector = Vector3.MoveTowards(startPos, destinoBotella, velocidadBotella);
            transform.position = moverVector;

            
            if (tareasCompletadas != null)
           {
               tareasCompletadas.CantidadBotellas += 1;
           }
            

        }

        if (Vector3.Distance(transform.position, destinoBotella) < 0.01f)
        {
            moving4 = false;
            Destroy(this);
           
        }

    }

    public void StartMoving4()
    {
        moving4 = true;
    }
    
}

