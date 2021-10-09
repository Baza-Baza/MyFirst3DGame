using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent navMesh;
    private Animator anim;
    private Transform theTarget;
    private float distanceToTarget;
    private int targetNumber = 1;
    private bool isStopped;
    private bool randomizer = true;
    private int nextTargetNumber;


    [SerializeField] int maxTargetNumber;
    [SerializeField] float stopDistance = 2.0f;
    [SerializeField] List<Transform> targets;
    [SerializeField] float waitTime = 2.0f;



    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        theTarget = targets[targetNumber - 1]; 
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(theTarget.position, transform.position);
        if (distanceToTarget > stopDistance)
        {
            navMesh.isStopped = false;
            anim.SetInteger("State", 0);
            navMesh.SetDestination(theTarget.position);
            nextTargetNumber = targetNumber;
            navMesh.speed = 1.6f;
        }
        if (distanceToTarget < stopDistance)
        {
            navMesh.isStopped = true;
            anim.SetInteger("State", 1);
            StartCoroutine(LookAround());
           
    }
    IEnumerator LookAround()
    {
        yield return new WaitForSeconds(waitTime);
            if (!isStopped)
            {
                isStopped = true;
                if (randomizer == true)
                {
                    randomizer = false;
                    targetNumber = Random.Range(1, maxTargetNumber);

                    if (targetNumber == nextTargetNumber)
                    {
                        targetNumber++;

                        if (targetNumber >= maxTargetNumber)
                        {
                            targetNumber = 1;
                        }
                    }
                }
                theTarget = targets[targetNumber - 1];

                yield return new WaitForSeconds(waitTime);
                isStopped = false;
                randomizer = true;
            }            
        }
    }
}
