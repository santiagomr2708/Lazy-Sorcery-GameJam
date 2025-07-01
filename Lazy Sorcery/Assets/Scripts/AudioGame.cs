using UnityEngine;

public class AudioGame : MonoBehaviour
{
    AudioSource audioSource;
    ContadorTiempo contadorTiempo;
    public AudioClip sonidoGame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.PlayOneShot(sonidoGame);
        
        GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager != null)
        {
          contadorTiempo = gameManager.GetComponent<ContadorTiempo>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (contadorTiempo.tiempoActual < 11)
        {
            audioSource.pitch = 1.5f;
        }
    }
}



