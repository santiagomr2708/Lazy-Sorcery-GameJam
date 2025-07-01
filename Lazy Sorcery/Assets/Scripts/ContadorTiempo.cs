using UnityEngine;
using TMPro;
using System.Collections;

public class ContadorTiempo : MonoBehaviour
{
    public TextMeshProUGUI textoContador;
    public int tiempoActual = 3;

    void Start()
    {
        StartCoroutine(ContarRegresivamente());
    }

    IEnumerator ContarRegresivamente()
    {

        while (tiempoActual >= 0)
        {
            textoContador.text = $"{tiempoActual}";
            yield return new WaitForSeconds(1f); // Espera 1 segundo
            tiempoActual--;
        }

        
    }
}