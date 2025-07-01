using UnityEngine;
using TMPro;

public class TareasCompletadas : MonoBehaviour
{
    public TextMeshProUGUI TextoTareasCompletadas;
    public float cantidadTareasCompletadas = 0;
    public float CantidadPlatos;
    public float CantidadLibros;
    public bool TareaPlatosCompletada = false;
    public bool tareaAspiradoraCompletada = false;
    public bool tareaLibroCompletada = false;
    private bool yaSumadoPlatos = false;
    private bool yaSumadoAspiradora = false;
    public bool yaSumadoLibro = false;
    

    VacuumAgent vacuumAgent;

    void Start()
    {
       

        GameObject vaccum = GameObject.Find("VacuumCleaner");
        if (vaccum != null)
        {
        vacuumAgent = vaccum.GetComponent<VacuumAgent>();
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        if (CantidadPlatos >= 10f)
        {
            TareaPlatosCompletada = true;
            if (!yaSumadoPlatos)
            {
                cantidadTareasCompletadas += 1f;
                yaSumadoPlatos = true;
            }
            
            

        }
       

        if (vacuumAgent.returningHome == true)
        {
            tareaAspiradoraCompletada = true;
            if (!yaSumadoAspiradora)
            {
                cantidadTareasCompletadas += 1f;
                yaSumadoAspiradora = true;
                
            }
            
        }

         if (CantidadLibros == 1)
        {
            tareaLibroCompletada = true;
            if (!yaSumadoLibro)
            {
                cantidadTareasCompletadas += 1f;
                yaSumadoLibro = true;
                
            }
            
        }
      
        
        TextoTareasCompletadas.text = "Tareas completadas: " + cantidadTareasCompletadas;
    }
}
