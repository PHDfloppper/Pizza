using UnityEngine;

public class HUDTourController : MonoBehaviour
{
    private Vector3 position;
    [SerializeField]
    private GameObject[] toursPrefab;
    
    public void GetPosition(Vector3 pos)
    {
        position = pos;
    }

    public void Tour0()
    {
        toursPrefab[0] = Instantiate(toursPrefab[0], position, Quaternion.identity);
        toursPrefab[0].transform.SetParent(null, false);
        Destroy(gameObject);
    }

    public void Fermer()
    {
        Destroy(gameObject);
    }
}
