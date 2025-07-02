using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractableEstufa : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 startPos;
     TareasCompletadas tareasCompletadas;
    Vector3 destinoLibro;
    AudioSource audioSource;
    public AudioClip  sonidoEstufa;
    
    public bool moving5 = false;
    private bool yaReproducido = false;


    void Start()
    {
        
        
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
            
      GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager != null)
        {
        tareasCompletadas = gameManager.GetComponent<TareasCompletadas>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {




        if (moving5)
        {
            audioSource.PlayOneShot(sonidoEstufa);

            if (!yaReproducido)
            {
                audioSource.PlayOneShot(sonidoEstufa);
                yaReproducido = true;
                Destroy(this);
            }
            if (tareasCompletadas != null)
           {
               tareasCompletadas.estufaPrendida = true;
           }
            
            

        }

     
    }

    public void StartMoving5()
    {
        moving5 = true;
    }
    
}