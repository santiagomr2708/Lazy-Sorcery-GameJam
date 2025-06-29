
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Cable : MonoBehaviour
{

    public SpriteRenderer finalCable;
    public GameObject puntoOrigen;
    private Vector2 posicionOriginal;
    private Vector2 tamañoOriginal;

    public float NumeroConexiones;
    ControlEscenas controlEscenas;




    void Start()
    {


    }

    void Update()
    {


    }

    private void OnMouseDrag()
    {
        ActualizarPosicion();
        ActualizarRotacion();
        ActualizarTamaño();
        ComprobarConexion();
    }

    private void ActualizarPosicion()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }

    private void ActualizarRotacion()
    {
        Vector2 posicionActual = transform.position;
        Vector2 puntoOrigenVector = puntoOrigen.transform.position;

        Vector2 direccion = posicionActual - puntoOrigenVector;

        float angulo = Vector2.SignedAngle(Vector2.right * transform.lossyScale, direccion);

        transform.rotation = Quaternion.Euler(0, 0, angulo);
    }

    private void ActualizarTamaño()
    {
        Vector2 posicionActual = transform.position;
        Vector2 puntoOrigenVector = puntoOrigen.transform.position;

        float distancia = Vector2.Distance(puntoOrigenVector + new Vector2(-3, 0), posicionActual);

        finalCable.size = new Vector2(distancia, finalCable.size.y);
    }
    private void ComprobarConexion()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);

        foreach (Collider2D col in colliders)
        {
            if (col.gameObject != gameObject)
            {
                transform.position = col.transform.position;

                Cable otroCable = col.gameObject.GetComponent<Cable>();
                NumeroConexiones++;
                controlEscenas.NumeroConexiones();


                if (finalCable.color == otroCable.finalCable.color)
                {
                    Conectar();
                    otroCable.Conectar();
                    controlEscenas.NumeroConexiones();

                }
            }
        }

    }

    public void Conectar()
    {
        Destroy(this);
    }

}