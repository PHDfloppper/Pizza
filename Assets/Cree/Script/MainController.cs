using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

//jsp si c'est une bonne idée d'avoir un Main mais pour faire ce que j'ai besoin, c'est ce qui me semble le plus simple.
public class MainController : MonoBehaviour
{
    public static List<GameObject> mechantsCible = new List<GameObject>();
    public static float points { get; private set; }

    public static void CleanMechant()
    {
        mechantsCible.RemoveAll(obj => obj == null);
    }

    public static bool MechantVide()
    {
        if(mechantsCible.Count <= 0) { return true; }
        else { return false; }
    }

    public static void AjouterPoint(float pts)
    {
        pts += points;
    }
}
