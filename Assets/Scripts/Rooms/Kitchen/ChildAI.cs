using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;
using UnityEngine.Analytics;

public class ChildAI : MonoBehaviour
{
    /*[SerializeField]*/ private Transform player;

    [SerializeField] private float chaseRange;
    [SerializeField] private float movementSpeed = 5f;

    private float waitTime; 
    [SerializeField] private float startWaitTime = 5f;

    private Collider2D spawnArea;
    private Vector2 randomDirection;

    private void Start()
    {
        spawnArea = GameObject.FindGameObjectWithTag("SpawnZone").GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        PatrolTeretory();

        if (targetInRange() == true && IsOutOfArea() == true)
        {
            ChaseTarget();
        }
    }

    private void ChaseTarget()
    {
        var direction = player.position - transform.position;
        float angle =  Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
         
        transform.eulerAngles = Vector3.forward * angle;

        transform.position = transform.position + new Vector3(direction.x, direction.y, 0) * movementSpeed * Time.deltaTime;
    }

    private bool targetInRange()
    {
        if (Vector2.Distance(transform.position, player.position) < chaseRange)
        {
            return true;
        }
        return false;
    }

    private bool IsOutOfArea()
    {
        if (spawnArea.bounds.Contains(transform.position))
        {
            return true;
        }

        return false;
    }

    private Vector2 GenerateRandomSpot()
    {
        return new Vector2(UnityEngine.Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x), UnityEngine.Random.Range(spawnArea.bounds.min.y,spawnArea.bounds.max.y)).normalized;
    }

    private void PatrolTeretory()
    {
        var f = randomDirection * 10;
        transform.position = Vector2.MoveTowards(transform.position, f, 3f * Time.deltaTime);

        if (Vector2.Distance(transform.position, f) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomDirection = GenerateRandomSpot();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Player") == true)
    //    {
    //        Debug.Log("CATCH");
    //    }
    //}

    //void OnCollisionEnter2D(Collision2D coll) {
    //    if (coll.gameObject.tag == "Player")
    //        Debug.Log("CATCH");

    //}
}
