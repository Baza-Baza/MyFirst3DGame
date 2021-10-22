using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplesPickups : MonoBehaviour
{
    [SerializeField] int applesNumber;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckApples());
    }
    IEnumerator CheckApples()
    {
        yield return new WaitForSeconds(1f);
        if (applesNumber > SaveScript.applesLeft)
        {
            Destroy(gameObject);
        }
    }
}
    


