using UnityEngine;
using UnityEngine.AI;

public class VacuumAgent : MonoBehaviour
{
    private NavMeshAgent agent;
    private bool isActive = false;
    private Vector3 homePosition;
    public float collectDistance = 1f;
    public bool returningHome = false;

    AudioSource audioSource;
    public AudioClip sonidoVaccum;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }


    }

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;
        homePosition = transform.position; // Guardamos posici�n inicial
    }

    // Llamar desde PlayerInteraction
    public void StartMoving()
    {
        if (isActive) return;
        isActive = true;
        agent.isStopped = false;
        returningHome = false;
        GoToNextTrash();
        audioSource.PlayOneShot(sonidoVaccum);
    }

    void GoToNextTrash()
    {
        audioSource.PlayOneShot(sonidoVaccum);
        var trashes = GameObject.FindGameObjectsWithTag("Trash");
        if (trashes.Length == 0)
        {
            // No hay m�s basura: volver a casa
            returningHome = true;
            agent.SetDestination(homePosition);
            return;
        }

        // Elegir basura m�s cercana
        Transform nearest = null;
        float minDist = Mathf.Infinity;
        foreach (var t in trashes)
        {
            float d = Vector3.Distance(transform.position, t.transform.position);
            if (d < minDist)
            {
                minDist = d;
                nearest = t.transform;
            }
        }

        if (nearest != null)
            agent.SetDestination(nearest.position);
    }

    void Update()
    {
        if (!isActive) return;

        if (agent.pathPending) return;

        // Si estamos yendo a casa y llegamos...
        if (returningHome && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            isActive = false;
            returningHome = false;
            return;
        }

        // Si estamos recogiendo basura y llegamos a ella...
        if (!returningHome && agent.remainingDistance <= collectDistance)
        {
            // Destruir basura cercana
            Collider[] hits = Physics.OverlapSphere(transform.position, collectDistance);
            foreach (var c in hits)
            {
                if (c.CompareTag("Trash"))
                {
                    Destroy(c.gameObject);
                    break;
                }
            }
            // Buscar siguiente o volver a casa
            GoToNextTrash();
        }
    }
}



