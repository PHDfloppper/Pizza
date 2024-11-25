using UnityEngine;
using System.Collections;
using Unity.Mathematics;
using System;

public class StartControlleur : MonoBehaviour
{

    [SerializeField]
    private GameObject[] mechants;
    [SerializeField]
    private float intervalSpawn;

    private Transform mechantParent;

    void Start()
    {
        StartCoroutine(GenererMechants());
        //part d'une position de tour, recule de deux parents pour chercher le gameObject Machant dans Carte
        mechantParent = transform.parent.parent.Find("Mechant"); //j'aime pas cette manière de faire mais en attendant de faire des recherches, je vais utiliser ça
        Debug.Log(mechantParent);

    }

    private IEnumerator GenererMechants()
    {
        // Pour chaque méchant dans le tableau
        foreach (GameObject mechant in mechants)
        {
            // Générer 5 instances de chaque méchant
            for (int i = 0; i < 5; i++)
            {
                GameObject mechant_ = Instantiate(mechant, transform.position, quaternion.identity, mechantParent); //quaternion.identity = pas de rotation source: https://docs.unity3d.com/ScriptReference/Quaternion-identity.html
                MainController.mechantsCible.Add(mechant_);
                yield return new WaitForSeconds(intervalSpawn);
            }
        }
    }
}
