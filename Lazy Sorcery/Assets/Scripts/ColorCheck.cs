using UnityEngine;

public class ColorCheck : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     
    TareasCompletadas tareasCompletadas;
    
    // Update is called once per frame
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;

        GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager != null)
        {
          tareasCompletadas = gameManager.GetComponent<TareasCompletadas>();
        }
    }
    void Update()
    {
        if (tareasCompletadas != null &&tareasCompletadas.TareaPlatosCompletada)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
