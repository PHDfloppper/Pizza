using UnityEngine;
using System.Collections;
using Unity.Mathematics;

public class StartControlleur : MonoBehaviour
{

    [SerializeField]
    private GameObject[] mechants;
    [SerializeField]
    private float intervalSpawn;

    void Start()
    {
        StartCoroutine(GenererMechants());
    }

    private IEnumerator GenererMechants()
    {
        // Pour chaque méchant dans le tableau
        foreach (GameObject mechant in mechants)
        {
            // Générer 5 instances de chaque méchant
            for (int i = 0; i < 5; i++)
            {
                // Crée une instance du méchant à la position du GameObject
                Instantiate(mechant, transform.position, quaternion.identity); //quaternion.identity = pas de rotation source: https://docs.unity3d.com/ScriptReference/Quaternion-identity.html

                // Attendre 1 seconde avant de générer la prochaine instance
                yield return new WaitForSeconds(intervalSpawn);
            }
        }
    }
}
