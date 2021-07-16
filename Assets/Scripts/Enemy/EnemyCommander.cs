using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCommander : MonoBehaviour
{
    private float timeToChangeDirection =5f;
    private UnityEngine.AI.NavMeshAgent agent;
    UnityEngine.AI.NavMeshPath path;
    public float timeForNewPath = 5f;
    bool inCoRoutine;
    Vector3 target;
    bool validPath;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        path = new UnityEngine.AI.NavMeshPath();
    }

    // Update is called once per frame
    void Update()
    {
        if(!inCoRoutine)
        {
            StartCoroutine(DoSomthing());
        }
        // timeToChangeDirection -= Time.deltaTime;
        //  if (timeToChangeDirection <= 0) {
        //      ChangeDirection();
        //  }
 
        // GetComponent<Rigidbody>().velocity = transform.up * 2;
        // agent.destination = transform.up;
        // agent.destination = new Vector3()

    }

    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-20,20);
        float z = Random.Range(-20,20);
        Vector3 pos = new Vector3(x,0,z);
        return pos;
    }
    IEnumerator DoSomthing()
    {
        inCoRoutine = true;
        yield return new WaitForSeconds(timeForNewPath);
        GetNewPath();
        validPath = agent.CalculatePath(target,path);
        while (!validPath)
        {
            yield return new WaitForSeconds(0.01f);
            GetNewPath();
            validPath = agent.CalculatePath(target,path);
        }
        inCoRoutine = false;
    }
    void GetNewPath()
    {
        target = getNewRandomPosition();
        animator.SetBool("isWalking", true);
        agent.SetDestination(target);
    }
}
