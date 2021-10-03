using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenSwaner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject childPrefab;
    private Collider2D spawnArea;

    void Start()
    {
        spawnArea = GameObject.FindGameObjectWithTag("SpawnZone").GetComponent<Collider2D>();
        SpawnChildren();
    }
    private Vector2 GenerateRandomSpot()
    {
        return new Vector2(UnityEngine.Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x), UnityEngine.Random.Range(spawnArea.bounds.min.y,spawnArea.bounds.max.y)).normalized;
    }

    private void SpawnChildren()
    {
        for (int i = 0; i < 3; i++)
        {
            var position = this.GenerateRandomSpot();
            Instantiate(this.childPrefab,10 * position.normalized, Quaternion.identity);
        }
    }
}
