using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.UIElements;

public class MechantController : MonoBehaviour
{
    [SerializeField]
    private float vie;

    [SerializeField]
    private float valeur;

    private List<Transform> positions = new List<Transform>();
    private int currentPos;
    private Transform startPos;
    private Transform endPos;

    private Transform objectif;
    private GameObject posParent;
    private GameObject positionsGO;
    [SerializeField]
    private float vitesse;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentPos = 0;

        //il doit surment avoir une meilleur façon de faire ça mais ça marche, faut juste que les maps soient tous fait de la même manière
        positionsGO = GameObject.Find("Carte/Positions");

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

    public void DestroyMechant()
    {
        Destroy(gameObject);
        Debug.Log("allo3");
    }

    public void BaisserVie()
    {
        vie = -1;
        if(vie <= 0)
        {
            MainController.AjouterPoint(valeur);
            Destroy(gameObject);
        }
    }

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
