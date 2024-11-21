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
        // Pour chaque m�chant dans le tableau
        foreach (GameObject mechant in mechants)
        {
            // G�n�rer 5 instances de chaque m�chant
            for (int i = 0; i < 5; i++)
            {
                // Cr�e une instance du m�chant � la position du GameObject
                Instantiate(mechant, transform.position, quaternion.identity); //quaternion.identity = pas de rotation source: https://docs.unity3d.com/ScriptReference/Quaternion-identity.html

                // Attendre 1 seconde avant de g�n�rer la prochaine instance
                yield return new WaitForSeconds(intervalSpawn);
            }
        }
    }
}
