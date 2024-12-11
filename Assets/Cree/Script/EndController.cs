using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// script utilisé sur les gameobject "End" dans chaque Carte
/// </summary>
public class EndController : MonoBehaviour
{
    //unityEvent qui appel la fonction destroy de chaque mechant
    private UnityEvent destroy = new UnityEvent();

    [SerializeField]
    private GameObject hudFin;

    /// <summary>
    /// se déclanche quand un méchant entre dans le collider de End
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        var mechant = other.gameObject.GetComponent<MechantController>();
        if(mechant != null)
        {
            MainController.ModifierVie(-1f);
            if(MainController.vie <= 0)
            {
                Time.timeScale = 0.0f;
                hudFin.SetActive(true);
            }
            destroy.RemoveAllListeners();
            destroy.AddListener(mechant.DestroyMechant);
            destroy?.Invoke();
        }
    }
}
