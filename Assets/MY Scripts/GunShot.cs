using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.haveGun == true)
        { 
            if(Input.GetKey(KeyCode.Mouse1) && Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (SaveScript.bullets > 0)
                {
                    if (Physics.Raycast(transform.position, transform.forward, out hit, 3000))
                    {
                        if (hit.transform.Find("Body"))
                        {
                            hit.transform.GetComponentInChildren<EnemyDamage>().enemyHealth -= Random.Range(30, 101);
                            hit.transform.GetComponentInChildren<Animator>().SetTrigger("BigReact");
                            if (hit.transform.GetComponentInChildren<EnemyDamage>().enemyHealth < 0)
                            {
                                hit.transform.GetComponentInChildren<EnemyDamage>().Died();
                            }
                        }
                    }
                }
            }
        }
    }

}
