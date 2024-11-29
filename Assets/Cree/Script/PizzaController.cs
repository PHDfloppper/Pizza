using UnityEngine;
using Unity.Mathematics;
using System.Collections;

public class PizzaController : MonoBehaviour
{
    [SerializeField]
    private GameObject pepperonPrefab;

    [SerializeField]
    private float cadenceSecondes;

    private bool mechantPresent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mechantPresent = false;
    }

    private IEnumerator GenererPepperon()
    {
        while (!MainController.MechantVide())
        {
            GameObject pepperon = Instantiate(pepperonPrefab, transform.position, quaternion.identity, gameObject.transform);
            yield return new WaitForSeconds(cadenceSecondes);
        }
        mechantPresent = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!MainController.MechantVide() && !mechantPresent)
        {
            mechantPresent = true;
            StartCoroutine(GenererPepperon());
        }
    }
}
