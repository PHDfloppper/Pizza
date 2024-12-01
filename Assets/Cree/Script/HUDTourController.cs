using System.Collections;
using UnityEngine;

public class HUDTourController : MonoBehaviour
{
    private Vector3 position;
    [SerializeField]
    private GameObject[] toursPrefab;

    private Animator menuAnimator;

    void Start()
    {
        menuAnimator = gameObject.GetComponent<Animator>();
        menuAnimator.SetTrigger("OuvertureTrigger");
    }
    public void GetPosition(Vector3 pos)
    {
        position = pos;
    }

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

    private void Fermer()
    {
        menuAnimator.SetTrigger("FermtureTrigger");
    }

    public void Detruire()
    {
        Destroy(gameObject);
    }
}
