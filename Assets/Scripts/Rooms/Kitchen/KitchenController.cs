using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenController : MonoBehaviour
{
    [SerializeField] private GameObject childPrefab;
    [SerializeField] private GameObject garbagePrefab;
    [SerializeField] private int childrenCount;
    [SerializeField] private int garbageCount;

    private Collider2D childrenSpawnArea;
    private Collider2D garbageSpawnArea;

    private System.Random rnd;

    private void Start()
    {
        rnd = new  System.Random();

        childrenSpawnArea = GameObject.FindGameObjectWithTag("SpawnZone").GetComponent<Collider2D>();
        garbageSpawnArea = GameObject.FindGameObjectWithTag("Floor").GetComponent<Collider2D>();

        SpawnObjectives(childPrefab, childrenSpawnArea, childrenCount);
        SpawnObjectives(garbagePrefab, garbageSpawnArea, garbageCount);
    }

    private Vector2 GenerateRandomSpot(Collider2D spawnArea)
    {
        return new Vector2(rnd.Next((int)spawnArea.bounds.min.x, (int)spawnArea.bounds.max.x), rnd.Next((int)spawnArea.bounds.min.y, (int)spawnArea.bounds.max.y));
    }

    private void SpawnObjectives(GameObject prefab, Collider2D spawnArea, int objectivesCount)
    {
        for (int i = 0; i < objectivesCount; i++)
        {
            var coif = this.rnd.Next(-50, 50);
            var position = GenerateRandomSpot(spawnArea);
            Instantiate(prefab, coif * position.normalized, Quaternion.identity);
        }
    }

}