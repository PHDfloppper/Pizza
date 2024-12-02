using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlaceController : MonoBehaviour
{
    //position actuelle de la place
    private Vector3 currentPosition;
    //unityevent qui donne la position actuelle de la place à HUDTour
    [SerializeField]
    private UnityEvent<Vector3> placerTour;
    //prefab du hud de tour
    [SerializeField]
    private GameObject hudToursPrefab;
    //instance du hud de tour
    private GameObject hudToursInst;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPosition = transform.position;
    }

    /// <summary>
    /// ouvre le hud de tour quand le joueur clique sur la place
    /// </summary>
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
