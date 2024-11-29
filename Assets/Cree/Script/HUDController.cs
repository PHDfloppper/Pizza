using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nbVie;
    [SerializeField]
    private TextMeshProUGUI nbPoint;
    [SerializeField]
    private TextMeshProUGUI round;
    void Update()
    {
        nbVie.SetText($"{MainController.vie}");
        nbPoint.SetText($"{MainController.points}$");
        round.SetText($"{MainController.manche}");
    }
}
