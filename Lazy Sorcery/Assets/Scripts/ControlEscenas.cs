using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine.SceneManagement;

public class ControlEscenas : MonoBehaviour
{
    Cable cableScript;
    ContadorTiempo contadorTiempo;

    void Start()
    {
            GameObject obj = GameObject.Find("GameManager");
           if (obj != null)
          {
            contadorTiempo = obj.GetComponent<ContadorTiempo>();
          }
    }

    void Update()
    {
        if (contadorTiempo.tiempoActual == 0)
        {
            SceneManager.LoadScene("GameOver");
        }

   
    }
    public void NumeroConexiones()
    {
          if (cableScript.NumeroConexiones == 4)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
