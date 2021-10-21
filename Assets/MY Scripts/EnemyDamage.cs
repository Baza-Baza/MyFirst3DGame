using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDamage : MonoBehaviour
{
    public  float enemyHealth = 100.0f;
    private float damageToEnemy = 50.0f;
    private AudioSource audioEnemyDetect;
    [SerializeField] AudioSource stabAudio;
    public  bool hasDied;
    private bool damageOn =false;
    private Animator anim;
    [SerializeField] GameObject knifeBloodSpray;
    [SerializeField] GameObject batBloodSpray;
    [SerializeField] GameObject axeBloodSpray;
    // Start is called before the first frame update
    void Start()
    {
        audioEnemyDetect = GetComponent<AudioSource>();
        anim = GetComponentInParent<Animator>();
        StartCoroutine(StartElements());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pknife"))
        {
            Damage(10.0f);
            knifeBloodSpray.SetActive(true);
        }
        if (other.gameObject.CompareTag("Pbat"))
        {
            Damage(15.0f);
            batBloodSpray.SetActive(true);
        }
        if (other.gameObject.CompareTag("Paxe"))
        {
            Damage(20.0f);
            axeBloodSpray.SetActive(true);
        }
        if (other.gameObject.CompareTag("Pcrossbow"))
        {
            Damage(50.0f);
            Destroy(other.gameObject, 0.05f);
        }
    }

    private void Damage(float damage)
    {
        damageToEnemy = damage;
        enemyHealth -= damageToEnemy;
        audioEnemyDetect.Play();
        stabAudio.Play();
        if (damageOn == true)
        {
            if (enemyHealth <= 0)
            {
                Died();
            }
        }
    }
    public void Died()
        {
            if (hasDied == false)
            {
                anim.SetTrigger("Death");
                anim.SetBool("IsDied", true);
                hasDied = true;
                Destroy(this.transform.parent.gameObject, 25f);
            SaveScript.enemiesOnScreen--;
            }
        }
    IEnumerator StartElements()
    {
        yield return new WaitForSeconds(0.1f);
        stabAudio = SaveScript.stabPlayer;
        knifeBloodSpray = SaveScript.knifeBloodSpray;
        batBloodSpray = SaveScript.batBloodSpray;
        axeBloodSpray = SaveScript.axeBloodSpray;
        knifeBloodSpray.SetActive(false);
        batBloodSpray.SetActive(false);
        axeBloodSpray.SetActive(false);
        damageOn = true;
        
    }
}

