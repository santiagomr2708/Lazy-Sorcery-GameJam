using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Interactuable2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 startPos;
    public AudioClip sonidoPlato;
    private AudioSource audioSource;
    public TareasCompletadas tareasCompletadas;
    Vector3 destinoPlatos;
    float velocidadPlatos = 2f;
    
    public bool moving2 = false;


    void Start()
    {
        startPos = transform.position;
        destinoPlatos = GameObject.Find("DestinoPlato").transform.position;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
            
      GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager != null)
        {
        tareasCompletadas = gameManager.GetComponent<TareasCompletadas>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {




        if (moving2)
        {
            Vector3 moverVector = Vector3.MoveTowards(startPos, destinoPlatos, velocidadPlatos);
            transform.position = moverVector;

            if (sonidoPlato != null)
            {
                audioSource.PlayOneShot(sonidoPlato);
            }
            if (tareasCompletadas != null)
           {
               tareasCompletadas.CantidadPlatos += 1;
           }
            

        }

        if (Vector3.Distance(transform.position, destinoPlatos) < 0.01f)
        {
            moving2 = false;
           
        }

    }

    public void StartMoving2()
    {
        moving2 = true;
    }
    
}
