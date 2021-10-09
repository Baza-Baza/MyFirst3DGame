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
    private void Start ()
    {
        fpsArms = GameObject.FindWithTag("Arms");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (hitActive == false)
            {
                hitActive = true;
                bloodAnim.SetTrigger("Blood");
                SaveScript.playerHealth -= weaponDamage;
                SaveScript.healthChanged = true;
                myPlayer.Play();
                fpsArms.GetComponent<PLayerAttack>().attackStamina -= 2.0f;
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
}
