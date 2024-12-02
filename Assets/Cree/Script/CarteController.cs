using UnityEngine;

/// <summary>
/// script utilisé sur les "Carte"
/// </summary>
public class CarteController : MonoBehaviour
{
    //Gameobject contenant la prochaine Carte
    [SerializeField]
    private GameObject prochaineCarte;
    
    /// <summary>
    /// sert à switchet de Carte quand le joueur fini la Carte actuelle
    /// </summary>
    public void ProchaineCarte()
    {
        prochaineCarte.SetActive(true);
        gameObject.SetActive(false);
    }
}
