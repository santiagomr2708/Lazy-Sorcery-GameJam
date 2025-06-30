using UnityEngine;

public class TareasCompletadas : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float CantidadPlatos;
    public bool TareaPlatosCompletada = false;
    public AudioClip sonidoCompletado;
    private AudioSource audioSource;

    private bool sonidoReproducido = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (CantidadPlatos >= 10f)
        {
            TareaPlatosCompletada = true;
        }
        if (TareaPlatosCompletada && sonidoCompletado != null && !sonidoReproducido)
        {
          audioSource.PlayOneShot(sonidoCompletado);
          sonidoReproducido = true;
        }
    }
}
