using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.UIElements;

public class MechantController : MonoBehaviour
{
    //vie du mechant
    [SerializeField]
    private float vie;
    //montant d'argent donn� au joueur quand le mechant est tu� par le joueur
    [SerializeField]
    private float valeur;
    //contient les positions de la map qui indique le chemain � suivre au m�chant
    private List<Transform> positions = new List<Transform>();
    //la derni�re position atteinte par le m�chant
    private int currentPos;
    //d�part du m�chant
    private Transform startPos;
    //arriv� du mechant
    private Transform endPos;
    //prochaine position du m�chant
    private Transform objectif;
    //gameObject parent de "Pos"
    private GameObject posParent;
    //gameObject parant de "Position"
    private GameObject positionsGO;
    //vitesse de d�placement du m�chant
    [SerializeField]
    private float vitesse;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentPos = 0;

        //il doit surment avoir une meilleur fa�on de faire �a mais �a marche, faut juste que les maps soient tous fait de la m�me mani�re
        positionsGO = transform.parent.parent.Find("Positions").gameObject;

        //assigne les positions aux variables du script
        foreach (Transform _trans in positionsGO.GetComponentInChildren<Transform>())
        {
            if(_trans.gameObject.name == "Start")
            {
                startPos = _trans;
            }
            if( _trans.gameObject.name =="End")
            {
                endPos = _trans;
            }
            if( _trans.gameObject.name == "Pos")
            {
                posParent = _trans.gameObject;
            }
        }
        foreach(Transform _pos in posParent.GetComponentsInChildren<Transform>())
        {
            if (_pos != posParent.transform)
            {
                positions.Add(_pos);
            }
        }


        gameObject.transform.position = startPos.position;
        objectif = positions[0].transform;
    }

    /// <summary>
    /// d�truit le m�chant
    /// </summary>
    public void DestroyMechant()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// baisse la vie du m�chant
    /// </summary>
    /// <param name="degat"></param>
    public void BaisserVie(float degat)
    {
        vie -= degat;
        if(vie <= 0)
        {
            MainController.ModifierPoint(valeur);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// obtenir la prochaine position � atteindre pour le m�chant
    /// </summary>
    private void NewObjectif()
    {
        currentPos += 1;
        if (currentPos >= positions.Count)
        {
            objectif = endPos.transform;
        }
        else
        {
            objectif = positions[currentPos].transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position == objectif.position)
        {
            NewObjectif();
        }
        else
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, objectif.position, vitesse * Time.deltaTime); //source: https://docs.unity3d.com/ScriptReference/Vector3.MoveTowards.html
        }
    }
}
