using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;


public enum AnimEnemyAttack
{ 
    knife,
    bat, 
    axe
};
public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent nav;
    private NavMeshHit hit;
    private bool blocked = false;
    private bool runToPLayer = false;
    private float distanceToPlayer;
    private bool isCheking = true;
    private int failCheckes = 0;
    private GameObject damageZone;
    private UnityEvent<bool> checkRunToPLayerEvent;
    private Transform player;

    [SerializeField] Animator anim;
    [SerializeField] GameObject enemy;
    [SerializeField] float maxRange = 35.0f;
    [SerializeField] int maxCheckes = 3;
    [SerializeField] float chaseSpeed = 8.0f;
    [SerializeField] float wakSpeed = 1.6f;
    [SerializeField] float attackDitance = 2.3f;
    [SerializeField] float attackRotateSpeed = 2.0f;
    [SerializeField] float checkTime = 3.0f;
    [SerializeField] GameObject chaseMusic;
    [SerializeField] GameObject bloodUI;
    public AnimEnemyAttack animEnemyAttack;
    private bool canRun = false;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponentInParent<NavMeshAgent>();
        damageZone = GameObject.FindGameObjectWithTag("DamageZone");       
        StartCoroutine(StartElements());
        damageZone = GameObject.FindGameObjectWithTag("DamageZone");
        if (checkRunToPLayerEvent == null)
            checkRunToPLayerEvent = new UnityEvent<bool>();
        checkRunToPLayerEvent.AddListener(CheckRunToPLayer);
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canRun == true)
        {
            if (damageZone.GetComponent<EnemyDamage>().hasDied == true)
            {
                chaseMusic.SetActive(false);
            }
            distanceToPlayer = Vector3.Distance(player.position, enemy.transform.position);
            if (distanceToPlayer < maxRange)
            {
                if (isCheking == true)
                {
                    isCheking = false;
                    blocked = NavMesh.Raycast(transform.position, player.position, out hit, NavMesh.AllAreas);

                    if (blocked == false)
                    {
                        Debug.Log("I can see thr Player");
                        runToPLayer = true;
                        failCheckes = 0;
                    }
                    if (blocked == true)
                    {
                        Debug.Log("I can't seen the Player");
                        runToPLayer = false;
                        anim.SetInteger("State", 1);
                        failCheckes++;
                    }

                    StartCoroutine(CheckedTime());
                }
                checkRunToPLayerEvent.Invoke(runToPLayer);
            }
        }
       
    }
    private void CheckRunToPLayer(bool Check)
    {
        if (Check == true)
        {
            enemy.GetComponent<EnemyMove>().enabled = false;
            if (damageZone.GetComponent<EnemyDamage>().hasDied == false)
            {
                chaseMusic.SetActive(true);
            }
            if (distanceToPlayer > attackDitance)
            {
                nav.isStopped = false;
                anim.SetInteger("State", 2);
                nav.acceleration = 24;
                nav.SetDestination(player.position);
                nav.speed = chaseSpeed;
                bloodUI.SetActive(false);
            }
            if (distanceToPlayer < attackDitance - 0.5f)
            {
                nav.isStopped = true;
                Debug.Log("I'm attacking");
                if (animEnemyAttack == AnimEnemyAttack.axe)
                {
                    anim.SetInteger("State", 3);
                }
                else if(animEnemyAttack == AnimEnemyAttack.bat)
                {
                    anim.SetInteger("State", 4);
                }
                else if (animEnemyAttack == AnimEnemyAttack.knife)
                {
                    anim.SetInteger("State", 5);
                }
                nav.acceleration = 180;
                bloodUI.SetActive(true);

                Vector3 pos = (player.position - enemy.transform.position).normalized;
                Quaternion posRot = Quaternion.LookRotation(new Vector3(pos.x, 0, pos.z));
                enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, posRot, Time.deltaTime * attackRotateSpeed);
            }
        }
        else if (Check == false)
        {
            nav.isStopped = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            runToPLayer = true;
        }
        else if (other.gameObject.CompareTag("Pknife"))
        {
            anim.SetTrigger("smallReact");
        }
        else if (other.gameObject.CompareTag("Paxe"))
        {
            anim.SetTrigger("BigReact");
        }
        else if (other.gameObject.CompareTag("Pbat"))
        {
            anim.SetTrigger("BigReact");
        }
        else if (other.gameObject.CompareTag("Pcrossbow"))
        {
            anim.SetTrigger("BigReact");
        }
    }
    IEnumerator CheckedTime()
    {
        yield return new WaitForSeconds(checkTime);
        isCheking = true;

        if (failCheckes > maxCheckes)
        {
            enemy.GetComponent<EnemyMove>().enabled = true;
            nav.isStopped = false;
            nav.speed = wakSpeed;
            failCheckes = 0;
            chaseMusic.SetActive(false);
        }
    }
    IEnumerator StartElements()
    {
        yield return new WaitForSeconds(0.1f);
        player = SaveScript.player;
        bloodUI = SaveScript.bloodScreen;
        chaseMusic = SaveScript.chase;
        chaseMusic.SetActive(false);
        canRun = true;

    }
}


