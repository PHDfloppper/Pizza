using UnityEngine;
using Unity.Mathematics;
using System.Collections;

public class PizzaController : MonoBehaviour
{
    //prefab du projectile
    [SerializeField]
    private GameObject pepperonPrefab;
    //cadence de tire de la tour
    [SerializeField]
    private float cadenceSecondes;
    //son de tire
    [SerializeField]
    private AudioSource lancerSon;

    //machine � �tat qui indique l'�tat du projectile
    public enum PepperoniState
    {
        Waiting,     // En attente d'un ennemi.
        Generating,  // G�n�ration de projectile
        Completed    // pr�t � �tre destroy()
    }
    //l'�tat actuele de la machine � �tat
    private PepperoniState currentState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = PepperoniState.Waiting;
    }
    //coroutine qui g�n�re un projectile
    private IEnumerator GenererPepperon()
    {
        while (!MainController.MechantVide())
        {
            GameObject pepperon = Instantiate(pepperonPrefab, transform.position, quaternion.identity, gameObject.transform);
            lancerSon.Play();
            yield return new WaitForSeconds(cadenceSecondes);
        }
        currentState = PepperoniState.Waiting;
    }

    // Update is called once per frame
    void Update()
    {
        if(MainController.manche == 3)
        {
            currentState = PepperoniState.Completed;
        }
        switch (currentState)
        {
            case PepperoniState.Waiting:
                if (!MainController.MechantVide())
                {
                    currentState = PepperoniState.Generating;
                    StartCoroutine(GenererPepperon());
                }
                break;

            case PepperoniState.Generating:
                break;

            case PepperoniState.Completed:
                Destroy(gameObject);
                break;
        }
    }
}
