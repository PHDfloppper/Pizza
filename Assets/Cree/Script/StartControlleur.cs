using UnityEngine;
using System.Collections;
using Unity.Mathematics;
using System;

public class StartControlleur : MonoBehaviour
{
    //tableau qui contient les prefabs des méchants
    [SerializeField]
    private GameObject[] mechants;
    //intervale d'instantiation des méchants en secondes
    [SerializeField]
    private float intervalSpawn;
    //le gameObject parent des méchants
    private Transform mechantParent;

    void Start()
    {
        //part d'une position de tour, recule de deux parents pour chercher le gameObject Machant dans Carte
        mechantParent = transform.parent.parent.Find("Mechant"); //j'aime pas cette manière de faire mais en attendant de faire des recherches, je vais utiliser ça

    }
    /// <summary>
    /// coroutine qui instantie des méchants selon le tableau de mechant
    /// </summary>
    /// <param name="nombreInstanceParMechant"></param>
    /// <returns></returns>
    public IEnumerator GenererMechants(float nombreInstanceParMechant)
    {
        foreach (GameObject mechant in mechants)
        {
            for (int i = 0; i < nombreInstanceParMechant; i++)
            {
                GameObject mechant_ = Instantiate(mechant, transform.position, quaternion.identity, mechantParent); //quaternion.identity = pas de rotation source: https://docs.unity3d.com/ScriptReference/Quaternion-identity.html
                MainController.mechantsCible.Add(mechant_);
                yield return new WaitForSeconds(intervalSpawn);
            }
        }
        MainController.roundStarted = true;
    }
}
