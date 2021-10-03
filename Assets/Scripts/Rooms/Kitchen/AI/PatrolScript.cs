using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{
   // [SerializeField] private float startWaitTime = 5f;

    private Vector2 randomDirection;
    private float waitTime;

    public void PatrolTeretory(Collider2D spawnArea, float startWaitTime)
    {
        var f = randomDirection * 10;
        transform.position = Vector2.MoveTowards(transform.position, f, 3f * Time.deltaTime);

        if (Vector2.Distance(transform.position, f) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomDirection = GenerateRandomSpot(spawnArea);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    public bool targetInRange(Transform player, float chaseRange)
    {
        if (Vector2.Distance(transform.position, player.position) < chaseRange)
        {
            return true;
        }
        return false;
    }

    private Vector2 GenerateRandomSpot(Collider2D spawnArea)
    {
        return new Vector2(UnityEngine.Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x), UnityEngine.Random.Range(spawnArea.bounds.min.y,spawnArea.bounds.max.y)).normalized;
    }
}
