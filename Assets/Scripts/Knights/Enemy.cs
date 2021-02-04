using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //PUBLIC VARIABLES
    public string knightName;
    public float timeToWait, frightenedTime;
    public Transform target;
    public GameObject[] myPath, randomPositions;
    public GameObject myParticle;
    public bool roaming, canExit, frightenedState;

    //PROTECTED VARIABLES
    protected NavMeshAgent navMeshAgent;
    protected Animator anim;
    protected Player player;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        roaming = false;
    }

    protected IEnumerator scatter(float time)
    {
        float timer = 0f;
        int i = 0;
        while (timer < time && i < myPath.Length)
        {
            timer += Time.deltaTime;
            navMeshAgent.SetDestination(myPath[i].transform.position);
            if ((transform.position - myPath[i].transform.position).magnitude < 1f)
            {
                i += 1;
            }
            yield return null;
        }
        yield return null;
    }

    protected IEnumerator frightened(float time)
    {
        frightenedState = true;
        myParticle.SetActive(true);
        float timer = 0f;
        int i = 0;
        while (timer < time && i < myPath.Length && frightenedState)
        {
            timer += Time.deltaTime;
            //int rnd = Random.Range(0, randomPositions.Length);
            navMeshAgent.SetDestination(randomPositions[i].transform.position);
            if ((transform.position - randomPositions[i].transform.position).magnitude < 1f)
            {
                i += 1;
            }
            yield return null;
        }
        frightenedState = false;
        FindObjectOfType<GameMaster>().frightened = false;
        myParticle.SetActive(false);
        yield return null;
    }

    protected IEnumerator waitingTime(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        canExit = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(8))
        {
            if (frightenedState)
            {
                FindObjectOfType<Inventory>().setPoints(200);
                transform.position = FindObjectOfType<GameMaster>().transform.position;
                frightenedState = false;
                //Destroy(this.gameObject);
            } //Hacemos que el enemigo pierda y spawnee en la base, acumulando además puntos para el jugador
            else
            {
                FindObjectOfType<GameMaster>().substractLife();
            }
        }
    }
}
