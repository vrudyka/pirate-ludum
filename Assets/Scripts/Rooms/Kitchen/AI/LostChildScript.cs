using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;

public class LostChildScript : MonoBehaviour
{
    private Transform player;

    [SerializeField]
    private float chaseRange;
    [SerializeField]
    private float movementSpeed = 5f;
    [SerializeField]
    private float startWaitTime = 5f;

    private float waitTime;

    private Collider2D spawnArea;

    private PatrolScript patrol;

    private void Start()
    {
        spawnArea = GameObject.FindGameObjectWithTag("SpawnZone").GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        patrol = GetComponent<PatrolScript>();
    }

    private void FixedUpdate()
    {
        patrol.PatrolTeretory(spawnArea, startWaitTime);

        //if (patrol.targetInRange(player, movementSpeed) == true && IsOutOfArea() == true)
        //{
        //    chase.ChaseTarget(player, chaseRange);
        //}
    }

    private bool IsOutOfArea()
    {
        if (spawnArea.bounds.Contains(transform.position))
        {
            return true;
        }

        return false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}