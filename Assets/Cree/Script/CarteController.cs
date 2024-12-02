using UnityEngine;

/// <summary>
/// script utilis� sur les "Carte"
/// </summary>
public class CarteController : MonoBehaviour
{
    //Gameobject contenant la prochaine Carte
    [SerializeField]
    private GameObject prochaineCarte;
    
    /// <summary>
    /// sert � switchet de Carte quand le joueur fini la Carte actuelle
    /// </summary>
    public void ProchaineCarte()
    {
        prochaineCarte.SetActive(true);
        gameObject.SetActive(false);
    }
}
