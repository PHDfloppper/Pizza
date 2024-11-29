using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

//jsp si c'est une bonne idée d'avoir un Main mais pour faire ce que j'ai besoin, c'est ce qui me semble le plus simple.
public class MainController : MonoBehaviour
{
    public static List<GameObject> mechantsCible = new List<GameObject>();
    public static float points { get; private set; }
    public static float vie { get; private set; }
    public static float manche { get; private set; }

    private bool canPlayRound;
    public static bool roundStarted;

    [SerializeField]
    private StartControlleur start;

    void Start()
    {
        Time.timeScale = 0.0f;
        NouvelleManche();
        roundStarted = false;
        canPlayRound = true;
        vie = 100f;
    }

    public static void CleanMechant()
    {
        mechantsCible.RemoveAll(obj => obj == null);
    }

    public static bool MechantVide()
    {
        if(mechantsCible.Count <= 0) { return true; }
        else { return false; }
    }

    public void Play(InputAction.CallbackContext context)
    {
        //source: https://discussions.unity.com/t/am-getting-multiple-key-events-in-new-input-system-only-one-should-be-firing/831905/2
        if (context.phase == InputActionPhase.Started && canPlayRound) // Exécute seulement en phase Started (quand la touche est appuié) car onPress ne marche pas pour quelconque raison 
        {
            Debug.Log("Play() exécuté");
            Time.timeScale = 1.0f;
            canPlayRound = false;
            StartCoroutine(start.GenererMechants(GetNombreMechant()));
        }
    }

    public static void ModifierPoint(float pts)
    {
        points += pts;
    }

    public static void ModifierVie(float _vie)
    {
        vie += _vie;
    }

    private void NouvelleManche()
    {
        points += 200;
        manche += 1;
        canPlayRound = true;
        roundStarted = false;
    }
    private float GetNombreMechant()
    {
        return manche * 10;
    }

    void Update()
    {
        if(mechantsCible.Count <= 0 && roundStarted)
        {
            NouvelleManche();
        }
        Debug.Log(roundStarted);

    }
}
