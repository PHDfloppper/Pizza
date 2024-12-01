using UnityEngine;
using Unity.Mathematics;
using System.Collections;

public class PizzaController : MonoBehaviour
{
    [SerializeField]
    private GameObject pepperonPrefab;

    [SerializeField]
    private float cadenceSecondes;

    private bool mechantPresent;

    [SerializeField]
    private AudioSource lancerSon;

    public enum PepperoniState
    {
        Waiting,     // En attente d'un ennemi.
        Generating,  // Génération du pepperoni.
        Completed    // Génération terminée.
    }
    private PepperoniState currentState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mechantPresent = false;
        currentState = PepperoniState.Waiting;
    }

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
        //if (!MainController.MechantVide() && !mechantPresent)
        //{
        //    mechantPresent = true;
        //    StartCoroutine(GenererPepperon());
        //}
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
