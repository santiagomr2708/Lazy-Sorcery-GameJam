using UnityEngine;

public class AudioGameOver : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip sonidoGameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        
        audioSource.PlayOneShot(sonidoGameOver);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
