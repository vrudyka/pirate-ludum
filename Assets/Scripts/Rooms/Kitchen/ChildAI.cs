using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;
using UnityEngine.Analytics;

public class ChildAI : MonoBehaviour
{
    private Transform player;

    [SerializeField] private float chaseRange;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float startWaitTime = 5f;
    [SerializeField] private Sprite[] babies;

    private float waitTime;
    private Collider2D spawnArea;
    private Vector2 randomDirection;

    private PatrolScript patrol;
    private ChaseScript chase;

    private void Start()
    {
        spawnArea = GameObject.FindGameObjectWithTag("SpawnZone").GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        var currentIndex = UnityEngine.Random.Range(0, babies.Length);
        GetComponent<SpriteRenderer>().sprite = babies[currentIndex];
    }

    private void FixedUpdate()
    {
        // PatrolTeretory();
        patrol = GetComponent<PatrolScript>();
        chase = GetComponent<ChaseScript>();

        patrol.PatrolTeretory(spawnArea, startWaitTime);

        if (patrol.targetInRange(player, movementSpeed) == true && IsOutOfArea() == true)
        {
            chase.ChaseTarget(player, chaseRange);
        }
    }

    private bool IsOutOfArea()
    {
        if (spawnArea.bounds.Contains(transform.position))
        {
            return true;
        }

        return false;
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
