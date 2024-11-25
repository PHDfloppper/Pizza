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
        mechantParent = transform.parent.parent.Find("Mechant"); //j'aime pas cette mani�re de faire mais en attendant de faire des recherches, je vais utiliser �a
        Debug.Log(mechantParent);

    }

    private IEnumerator GenererMechants()
    {
        // Pour chaque m�chant dans le tableau
        foreach (GameObject mechant in mechants)
        {
            // G�n�rer 5 instances de chaque m�chant
            for (int i = 0; i < 5; i++)
            {
                GameObject mechant_ = Instantiate(mechant, transform.position, quaternion.identity, mechantParent); //quaternion.identity = pas de rotation source: https://docs.unity3d.com/ScriptReference/Quaternion-identity.html
                MainController.mechantsCible.Add(mechant_);
                yield return new WaitForSeconds(intervalSpawn);
            }
        }
    }
}
