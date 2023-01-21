using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    //public delegate void FollowAction();
    //public static event FollowAction OnFollow;
    //public delegate void NoFollowAction();
    //public static event NoFollowAction OnNoFollow;
    public Animator animationEnemy;
    public float life = 100;
    private NavMeshAgent enemy;
    public Transform[] nodo;
    private int index = 0;
    public bool followPlayer;
    private GameObject player;
    private float distanceToPlayer;
    public float distanceToFollowPlayer = 10;
    public float distanceToFollowPath = 2;
    bool stop = false;
    public float radius = 5.0f;
    void Start()
    {
        animationEnemy = GetComponent<Animator>();
        enemy = GetComponent<NavMeshAgent>();
        if (nodo == null || nodo.Length == 0)
        {
            transform.gameObject.GetComponent<AI>().enabled = false;
        }
        else
        {
            enemy.destination = nodo[0].position;
            player = FindObjectOfType<PlayerController>().gameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= distanceToFollowPlayer && followPlayer && stop == false)
        {
            RotationEnemy();
            FollowPlayer();
            //walkEnemy = true;
            //OnFollow();
            //animationEnemy.SetFloat("XSpeed", 1f);
            //animationEnemy.SetFloat("YSpeed", 0.01f);
        }
        else
        {
            //walkEnemy = false;
            //animationEnemy.SetBool("Run", walkEnemy);
            EnemyPath();
            //animationEnemy.SetFloat("XSpeed", 1f);  
            //animationEnemy.SetFloat("YSpeed", 0.01f);
            //OnNoFollow();

        }
    }

    public void EnemyPath()
    {

        enemy.destination = nodo[index].position;
        animationEnemy.SetFloat("XSpeed", 1.0f);
        animationEnemy.SetFloat("YSpeed", 0.01f);
        if (Vector3.Distance(transform.position, nodo[index].position) <= distanceToFollowPath)
        {
            if (nodo[index] != nodo[nodo.Length - 1])
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
    }
    public void FollowPlayer()
    {
        Vector3 movePos = player.transform.position;
        movePos = Vector3.MoveTowards(movePos, transform.position, radius);
        //enemy.destination = player.transform.position;
        enemy.SetDestination(movePos);
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= radius)
        {
            //stop = true;
            animationEnemy.SetFloat("XSpeed", 0.0f);
            animationEnemy.SetFloat("YSpeed", 0.5f);
        }
        else
        {
            //stop = false;
        }
    }
    public void RotationEnemy()
    {
        //stop = false;
        float angleRadian = Mathf.Atan2(player.transform.position.x - transform.position.x, player.transform.position.z - transform.position.z);
        float angleGrades = (180 / Mathf.PI) * angleRadian;
        transform.rotation = Quaternion.Euler(0, angleGrades, 0);
    }
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Bullet2");
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //Debug.Log("Bullet");
            life = life - 10;
            Debug.Log(life);
            if(life <= 0)
            {
                life = 0;
                Destroy(gameObject, 0.1f);
            }
        }
    }
}
