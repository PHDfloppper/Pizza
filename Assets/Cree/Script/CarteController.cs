using UnityEngine;

public class CarteController : MonoBehaviour
{
    [SerializeField]
    private GameObject prochaineCarte;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ProchaineCarte()
    {
        prochaineCarte.SetActive(true);
        gameObject.SetActive(false);
    }
}
