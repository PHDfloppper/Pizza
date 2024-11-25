using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PepperoniControlelr : MonoBehaviour
{
    [SerializeField]
    private float vitesse;

    private UnityEvent attaqueMechant = new UnityEvent();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        var mechant = other.gameObject.GetComponent<MechantController>();
        if (mechant != null)
        {
            attaqueMechant.RemoveAllListeners();
            attaqueMechant.AddListener(mechant.BaisserVie);
            attaqueMechant?.Invoke();
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (MainController.MechantVide())
        {
            Destroy(gameObject);
        }

        MainController.CleanMechant();

        if (!MainController.MechantVide())
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, MainController.mechantsCible[0].transform.position, (vitesse * Time.deltaTime)); //source: https://docs.unity3d.com/ScriptReference/Vector3.MoveTowards.html
        }
    }
}
