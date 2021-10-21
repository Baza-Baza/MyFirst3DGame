using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponDAmage : MonoBehaviour
{
    [SerializeField] Animator bloodAnim;
    [SerializeField] int weaponDamage = 1;
    [SerializeField] AudioSource myPlayer;
    private bool hitActive;
    private GameObject fpsArms;
    private bool canAttack = false;
    private void Start ()
    {
        StartCoroutine(StartElements());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (canAttack == true)
            {
                if (hitActive == false)
                {
                    hitActive = true;
                    bloodAnim.SetTrigger("Blood");
                    SaveScript.playerHealth -= weaponDamage;
                    SaveScript.healthChanged = true;
                    myPlayer.Play();
                    SaveScript.attackStamina -= 2.0f;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (hitActive == true)
            {
                hitActive = false;
            }
        }
    }
    IEnumerator StartElements()
    {
        yield return new WaitForSeconds(0.1f);
        bloodAnim = SaveScript.bloodAnim;
        myPlayer = SaveScript.stabPlayer;
        canAttack = true;

    }
}
