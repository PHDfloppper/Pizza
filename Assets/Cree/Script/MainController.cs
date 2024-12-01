using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

//jsp si c'est une bonne idée d'avoir un Main mais pour faire ce que j'ai besoin, c'est ce qui me semble le plus simple.
public class MainController : MonoBehaviour
{
    public static List<GameObject> mechantsCible = new List<GameObject>();
    public static List<GameObject> tours = new List<GameObject>();
    public static float points { get; private set; }
    public static float vie { get; private set; }
    public static float manche { get; private set; }

    private bool canPlayRound;
    public static bool roundStarted;

    private bool accelere;

    [SerializeField]
    private StartControlleur start;

    [SerializeField]
    private UnityEvent prochainNiveau;

    [SerializeField]
    private float nombreMaxManche;

    void Start()
    {
        NouvelleManche();
        roundStarted = false;
        canPlayRound = true;
        vie = 100f;
        accelere = true;
        points += 150;
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
        Debug.Log("play");
        //source: https://discussions.unity.com/t/am-getting-multiple-key-events-in-new-input-system-only-one-should-be-firing/831905/2
        if (context.phase == InputActionPhase.Started && canPlayRound) // Exécute seulement en phase Started (quand la touche est appuié) car onPress ne marche pas pour quelconque raison 
        {
            Debug.Log("play if");
            Time.timeScale = 1.0f;
            canPlayRound = false;
            StartCoroutine(start.GenererMechants(GetNombreMechant()));
        }
    }

    public void AccelererTemps(InputAction.CallbackContext context) //il faut double-clique pour que ça marche (jsp pourquoi)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (accelere)
            {
                Time.timeScale = 3.0f;
                accelere = false;
            }
            else if (!accelere)
            {
                Time.timeScale = 1.0f;
                accelere = true;
            }
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

    public static void NextCarte()
    {
        vie = 100;
        points = 0;
        manche = 0;
        foreach (var p in tours)
        {
            Destroy(p);
        }
        tours.RemoveAll(obj => obj == null);
    }

    public static void Recommencer()
    {
        vie = 100;
        points = 200;
        manche = 1;
    }

    private void NouvelleManche()
    {
        points += 50;
        manche += 1;
        canPlayRound = true;
        roundStarted = false;
        accelere = true;
        if(manche == nombreMaxManche+1)
        {
            NextCarte();
            prochainNiveau?.Invoke();
        }
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
        mechantsCible.RemoveAll(obj => obj == null);
        Debug.Log(canPlayRound);
    }
}