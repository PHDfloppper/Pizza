using System.Collections;
using UnityEngine;

public class HUDTourController : MonoBehaviour
{
    //position où on va ajouter une tour
    private Vector3 position;
    //contient les prefabs de tours
    [SerializeField]
    private GameObject[] toursPrefab;
    //contient l'Animator des animations du HUDTour
    private Animator menuAnimator;

    void Start()
    {
        menuAnimator = gameObject.GetComponent<Animator>();
        menuAnimator.SetTrigger("OuvertureTrigger");
    }
    /// <summary>
    /// obtient la position de la place là où on veut mettre la tour
    /// </summary>
    /// <param name="pos"></param>
    public void GetPosition(Vector3 pos)
    {
        position = pos;
    }

    /// <summary>
    /// ajouter la tour 0 (dans ce cas-ci, la pizza)
    /// </summary>
    public void Tour0()
    {
        if (MainController.points >= 200)
        {
            MainController.ModifierPoint(-200);
            toursPrefab[0] = Instantiate(toursPrefab[0], position, Quaternion.identity);
            toursPrefab[0].transform.SetParent(null, false);
            MainController.tours.Add(toursPrefab[0]);
            menuAnimator.SetTrigger("FermtureTrigger");
        }
    }

    /// <summary>
    /// ajouter la tour 1 (dans ce cas-ci, les frites)
    /// </summary>
    public void Tour1()
    {
        if (MainController.points >= 150)
        {
            MainController.ModifierPoint(-150);
            toursPrefab[1] = Instantiate(toursPrefab[1], position, Quaternion.identity);
            toursPrefab[1].transform.SetParent(null, false);
            MainController.tours.Add(toursPrefab[1]);
            menuAnimator.SetTrigger("FermtureTrigger");
        }
    }

    /// <summary>
    /// ajouter la tour 2 (dans ce cas-ci, le soda)
    /// </summary>
    public void Tour2()
    {
        if (MainController.points >= 250)
        {
            MainController.ModifierPoint(-250);
            toursPrefab[2] = Instantiate(toursPrefab[2], position, Quaternion.identity);
            toursPrefab[2].transform.SetParent(null, false);
            MainController.tours.Add(toursPrefab[2]);
            menuAnimator.SetTrigger("FermtureTrigger");
        }
    }

    /// <summary>
    /// ferme le hud de tour
    /// </summary>
    private void Fermer()
    {
        menuAnimator.SetTrigger("FermtureTrigger");
    }

    /// <summary>
    /// supprime le hud de tour
    /// </summary>
    public void Detruire()
    {
        Destroy(gameObject);
    }
}
