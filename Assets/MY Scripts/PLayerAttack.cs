using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PLayerAttack : MonoBehaviour
{
    public UnityEvent ShotEventBullet;
    public UnityEvent ShotEventBow;
    public float attackStamina = 10;
    [SerializeField] float maxStamina = 10;
    [SerializeField] float attackDrain = 2;
    [SerializeField] float attackRefill = 1;
    [SerializeField] AudioClip GunShot;
    [SerializeField] AudioClip CrossbowShot;
    private GameObject crosshair;
    private GameObject pointer;
    private AudioSource mySource;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        attackStamina = maxStamina;
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        pointer = GameObject.FindGameObjectWithTag("Pointer");
        crosshair.SetActive(false);
        pointer.SetActive(true);
        mySource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        CheckAnimtionWeapons();
        Debug.Log(attackStamina);
    }
    private void CheckAnimtionWeapons()
    {
        if (attackStamina < maxStamina)
        {
            attackStamina += attackRefill * Time.deltaTime; 
        }
        if (attackStamina < 0.1)
        {
            attackStamina = 0.1f;
        }
        if (attackStamina > 3)
        {
            if (SaveScript.haveKnife == true)
            {
                PlayerDamageMeleeWeapon("KnifeLMB", "KnifeRMB");
            }
            else if  (SaveScript.haveBat == true)
            {
                PlayerDamageMeleeWeapon("AxeLMB", "AxeRMB");
            }
            else if (SaveScript.haveAxe == true)
            {
                PlayerDamageMeleeWeapon("BattLMB", "BattRMB");
            }
            else if (SaveScript.haveGun == true)
            {
                PlayerDamageFireArms("AimGun", GunShot, ShotEventBullet, SaveScript.bullets);
            }
            else if (SaveScript.haveCrossBow == true)
            {
                PlayerDamageFireArms("AimGun", CrossbowShot, ShotEventBow, SaveScript.bow);
            }

        }
    }
    private void AttackStamina()
    {
        attackStamina -= attackDrain;
    }
    private void PlayerDamageMeleeWeapon(string leftTrigger, string rightTrigger)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger(leftTrigger);
            AttackStamina();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            anim.SetTrigger(rightTrigger);
            AttackStamina();
        }
    }
    private void PlayerDamageFireArms(string nameBool, AudioClip clipShot, UnityEvent myShell, int shells)
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            anim.SetBool(nameBool, true);
            crosshair.SetActive(true);
            pointer.SetActive(false);
            
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            anim.SetBool(nameBool, false);
            crosshair.SetActive(false);
            pointer.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (shells > 0)
            {
                myShell.Invoke();
                mySource.clip = clipShot;
                mySource.Play();
            }
        }
    }

}
