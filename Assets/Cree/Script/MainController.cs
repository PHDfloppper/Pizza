using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

//jsp si c'est une bonne id�e d'avoir un Main mais pour faire ce que j'ai besoin, c'est ce qui me semble le plus simple et efficace.
public class MainController : MonoBehaviour
{
    //liste qui contient les mechants
    public static List<GameObject> mechantsCible = new List<GameObject>();
    //liste qui contient les tours, pas utile depuis l'ajout de la machine � �tat, � voir si je supprime
    public static List<GameObject> tours = new List<GameObject>();
    //float qui contient les points
    public static float points { get; private set; }
    //contient les vie restantes
    public static float vie { get; private set; }
    //manche actuelle du jeu
    public static float manche { get; private set; }
    //bool qui indique si le joueur peux commencer la round ou non
    private bool canPlayRound;
    //bool qui indique si la round est commenc� ou non
    public static bool roundStarted;
    //bool qui indique si le temps est acc�l�r� ou non
    private bool accelere;
    //contient le gameObject Start
    [SerializeField]
    private StartControlleur start;
    //unityEvent pour passer � la prochaine Carte
    [SerializeField]
    private UnityEvent prochainNiveau;
    //contient le nombre max de manche par Carte (set � 10)
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

    /// <summary>
    /// clean la liste de m�chant si y'a des m�chant null (donc quand les m�chants sont Destroy(), ils sont enlev�s de la liste)
    /// </summary>
    public static void CleanMechant()
    {
        mechantsCible.RemoveAll(obj => obj == null);
    }

    /// <summary>
    /// retourne si la liste de mechant est vide ou non
    /// </summary>
    /// <returns></returns>
    public static bool MechantVide()
    {
        if(mechantsCible.Count <= 0) { return true; }
        else { return false; }
    }

    /// <summary>
    /// commence la round, donc envoie les mechants sur le chemain
    /// </summary>
    /// <param name="context"></param>
    public void Play(InputAction.CallbackContext context)
    {
        Debug.Log("play");
        //source: https://discussions.unity.com/t/am-getting-multiple-key-events-in-new-input-system-only-one-should-be-firing/831905/2
        if (context.phase == InputActionPhase.Started && canPlayRound) // Ex�cute seulement en phase Started (quand la touche est appui�) car onPress ne marche pas pour quelconque raison 
        {
            Debug.Log("play if");
            Time.timeScale = 1.0f;
            canPlayRound = false;
            StartCoroutine(start.GenererMechants(GetNombreMechant()));
        }
    }

    /// <summary>
    /// acc�l�re ou ralenti le temps
    /// </summary>
    /// <param name="context"></param>
    public void AccelererTemps(InputAction.CallbackContext context) //il faut double-clique pour que �a marche (jsp pourquoi)
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

    /// <summary>
    /// modifie les points du joueur, vue que les points sont en private set
    /// </summary>
    /// <param name="pts"></param>
    public static void ModifierPoint(float pts)
    {
        points += pts;
    }

    /// <summary>
    /// modifie la vie du joueur, vue que la vie est en private set
    /// </summary>
    /// <param name="_vie"></param>
    public static void ModifierVie(float _vie)
    {
        vie += _vie;
    }

    /// <summary>
    /// pr�pare le jeu � passer � la prochaine carte, donc remet tout � 0
    /// </summary>
    public static void NextCarte()
    {
        vie = 100;
        points = 0;
        manche = 0;
        foreach (var p in tours)
        {
            Destroy(p);
            Debug.Log("nextcarte");
        }
        tours.RemoveAll(obj => obj == null);
    }

    /// <summary>
    /// pr�pare le jeu � recommencer la carte actuelle, donc remet tout � 0
    /// </summary>
    public static void Recommencer()
    {
        vie = 100;
        points = 200;
        manche = 1;
        Debug.Log("recommencer");
    }

    /// <summary>
    /// passe � la prochaine manche quand celle actuelle se termine, donc quand tout les m�chants sont d�truits
    /// </summary>
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
            Debug.Log("nouvellemanche");
        }
    }

    /// <summary>
    /// retourne le nombre de mechant � faire apparaitre selon la manche
    /// </summary>
    /// <returns></returns>
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
    }
}