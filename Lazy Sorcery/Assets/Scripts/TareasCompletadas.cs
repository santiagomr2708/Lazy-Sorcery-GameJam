using UnityEngine;
using TMPro;

public class TareasCompletadas : MonoBehaviour
{
    public TextMeshProUGUI TextoTareasCompletadas;
    public float cantidadTareasCompletadas = 0;
    public float CantidadPlatos;
    public float CantidadLibros;
    public float CantidadBotellas;
    public bool TareaPlatosCompletada = false;
    public bool tareaAspiradoraCompletada = false;
    public bool tareaLibroCompletada = false;
    public bool tareaBotellaCompletada = false;
    public bool tareaEstufaCompletada = false;
    private bool yaSumadoPlatos = false;
    private bool yaSumadoAspiradora = false;
    public bool yaSumadoLibro = false;
    public bool yaSumadoBotella = false;
    public bool estufaPrendida = false;
     public bool yaSumadoEstufa = false;
    

    VacuumAgent vacuumAgent;
    InteractableEstufa interactableEstufa;

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
        if (CantidadBotellas == 1)
        {
            tareaBotellaCompletada = true;
            if (!yaSumadoBotella)
            {
                cantidadTareasCompletadas += 1f;
                yaSumadoBotella = true;
                
            }
            
        }
        if (estufaPrendida == true)
        {
            tareaEstufaCompletada = true;
            if (!yaSumadoEstufa)
            {
                cantidadTareasCompletadas += 1f;
                yaSumadoEstufa = true;
                
            }
            
        }
      
        
        TextoTareasCompletadas.text = "Tareas completadas: " + cantidadTareasCompletadas;
    }
}
