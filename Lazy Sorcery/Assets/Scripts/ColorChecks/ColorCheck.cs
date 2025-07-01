using UnityEngine;

public class ColorCheck : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     
    TareasCompletadas tareasCompletadas;
    public AudioClip sonidoCompletado;
    private AudioSource audioSource;
    private bool yaReproducido = false;
    
    // Update is called once per frame
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        GetComponent<Renderer>().material.color = Color.red;

        GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager != null)
        {
          tareasCompletadas = gameManager.GetComponent<TareasCompletadas>();
        }
    }
    void Update()
    {
        if (tareasCompletadas != null && tareasCompletadas.TareaPlatosCompletada)
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
