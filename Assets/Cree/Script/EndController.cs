using UnityEngine;
using UnityEngine.Events;

public class EndController : MonoBehaviour
{
    private UnityEvent destroy = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("allo1");
        var mechant = other.gameObject.GetComponent<MechantController>();
        if(mechant != null)
        {
            Debug.Log("allo2");
            destroy.RemoveAllListeners();
            destroy.AddListener(mechant.DestroyMechant);
            destroy.Invoke();
        }
    }
}
