using UnityEngine;
using Unity.Mathematics;
using System.Collections;

public class PizzaController : MonoBehaviour
{
    [SerializeField]
    private GameObject pepperonPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(GenererPepperon());
    }

    private IEnumerator GenererPepperon()
    {
        while (true && !MainController.MechantVide())
        {
            GameObject pepperon = Instantiate(pepperonPrefab, transform.position, quaternion.identity, gameObject.transform);
            yield return new WaitForSeconds(0.2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
