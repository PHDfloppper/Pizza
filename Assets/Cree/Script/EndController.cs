using UnityEngine;
using UnityEngine.Events;

public class EndController : MonoBehaviour
{
    private UnityEvent destroy = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        var mechant = other.gameObject.GetComponent<MechantController>();
        if(mechant != null)
        {
            MainController.ModifierVie(-1f);
            destroy.RemoveAllListeners();
            destroy.AddListener(mechant.DestroyMechant);
            destroy?.Invoke();
        }
    }
}
