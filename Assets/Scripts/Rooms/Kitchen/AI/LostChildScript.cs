using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;

public class LostChildScript : MonoBehaviour
{
    public bool IsFoud;
    private Transform player;

    [SerializeField]
    private float chaseRange;
    [SerializeField]
    private float movementSpeed = 5f;
    [SerializeField]
    private float startWaitTime = 5f;

    private float waitTime;

    private Collider2D lostChildArea;

    private PatrolScript patrol;
    private ChaseScript chase;

    private Transform motherAI;

    // UnityEvent m_MyEvent;

    private void Start()
    {
        lostChildArea = GameObject.FindGameObjectWithTag("LostChildArea").GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        motherAI = GameObject.FindGameObjectWithTag("MotherAI").GetComponent<Transform>();
        patrol = GetComponent<PatrolScript>();
        chase = GetComponent<ChaseScript>();
    }

    private void FixedUpdate()
    {
        if (IsInOfArea() == true)
        {
            patrol.PatrolTeretory(lostChildArea, startWaitTime);
        }
    }

    private bool IsInOfArea()
    {
        if (lostChildArea.bounds.Contains(transform.position))
        {
            return true;
        }

        return false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.IsFoud = true;
            chase.ChaseTarget(motherAI, chaseRange);
            // m_MyEvent.AddListener(Ping);
        }
    }

    //void Ping()
    //{
    //    Debug.Log("Ping");
    //}
}