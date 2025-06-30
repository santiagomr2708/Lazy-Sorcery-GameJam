using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine.SceneManagement;

public class ControlEscenas : MonoBehaviour
{
    Cable cableScript;

    void Update()
    {
   
    }
    public void NumeroConexiones()
    {
          if (cableScript.NumeroConexiones == 4)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
