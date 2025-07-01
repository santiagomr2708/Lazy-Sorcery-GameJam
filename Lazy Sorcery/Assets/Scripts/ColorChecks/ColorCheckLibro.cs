using UnityEngine;

public class ColorCheckLibro : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     
    TareasCompletadas tareasCompletadas;
    public AudioClip sonidoCompletado;
    private AudioSource audioSource;
    private bool yaReproducido = false;
    // Update is called once per frame
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
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
    void Update()
    {
        if (tareasCompletadas != null && tareasCompletadas.tareaLibroCompletada)
        {
            GetComponent<Renderer>().material.color = Color.green;
            if (!yaReproducido)
            {
                audioSource.PlayOneShot(sonidoCompletado);
                yaReproducido = true;
            }
            
        }
    }
}

