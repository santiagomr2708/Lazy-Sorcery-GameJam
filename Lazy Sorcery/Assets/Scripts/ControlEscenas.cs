using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine.SceneManagement;

public class ControlEscenas : MonoBehaviour
{
    
    ContadorTiempo contadorTiempo;

    TareasCompletadas tareasCompletadas;

    void Start()
    {
        GameObject obj = GameObject.Find("GameManager");
        if (obj != null)
        {
            contadorTiempo = obj.GetComponent<ContadorTiempo>();
        }
        GameObject obje = GameObject.Find("GameManager");
           if (obje != null)
          {
            tareasCompletadas = obj.GetComponent<TareasCompletadas>();
          }
          
          
    }

    void Update()
    {
        if (contadorTiempo.tiempoActual == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
       if (tareasCompletadas.cantidadTareasCompletadas == 5)
        {
            SceneManager.LoadScene("Victory");
        }
   
    }
      
}
