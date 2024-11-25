using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlaceController : MonoBehaviour
{
    private Vector3 currentPosition;
    [SerializeField]
    private UnityEvent<Vector3> placerTour;
    [SerializeField]
    private GameObject hudToursPrefab;
    private GameObject hudToursInst;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPosition = transform.position;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return; //source de cette ligne: https://discussions.unity.com/t/prevent-mouse-clicking-through-ui/821839

        hudToursInst = Instantiate(hudToursPrefab, Vector3.zero, Quaternion.identity);
        hudToursInst.transform.SetParent(null, false);

        var hudTour = hudToursInst.GetComponent<HUDTourController>();
        placerTour.RemoveAllListeners();
        placerTour.AddListener(hudTour.GetPosition);
        placerTour?.Invoke(currentPosition);
    }
}
