using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenController : MonoBehaviour
{
    [SerializeField] private GameObject childPrefab;
    [SerializeField] private GameObject garbagePrefab;
    [SerializeField] private int childrenCount;
    [SerializeField] private int garbageAmount;

    private Collider2D childrenSpawnArea;
    private Collider2D garbageSpawnArea;

    private LostChildScript lostChildScript;
    private GarbageScript garbageScript;

    private System.Random rnd;

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume=0.5f;

    private void Start()
    {
        rnd = new System.Random();

        childrenSpawnArea = GameObject.FindGameObjectWithTag("SpawnZone").GetComponent<Collider2D>();
        garbageSpawnArea = GameObject.FindGameObjectWithTag("Floor").GetComponent<Collider2D>();

        SpawnObjectives(childPrefab, childrenSpawnArea, childrenCount);
        SpawnObjectives(garbagePrefab, garbageSpawnArea, garbageAmount);
    }

    private void LateUpdate()
    {
        lostChildScript = GameObject.FindGameObjectWithTag("LostChild").GetComponent<LostChildScript>();
        garbageScript = GameObject.FindGameObjectWithTag("Player").GetComponent<GarbageScript>();

        if (garbageScript.garbegeCount > 2 && this.lostChildScript.IsFoud == true)
        {
            Debug.Log("VICTORY!!!");
        }
    }

    private Vector2 GenerateRandomSpot(Collider2D spawnArea)
    {
        return new Vector2(rnd.Next((int)spawnArea.bounds.min.x, (int)spawnArea.bounds.max.x), rnd.Next((int)spawnArea.bounds.min.y, (int)spawnArea.bounds.max.y));
    }

    private void SpawnObjectives(GameObject prefab, Collider2D spawnArea, int objectivesCount)
    {
        for (int i = 0; i < objectivesCount; i++)
        {
            var coif = this.rnd.Next(-30, 30);
            var position = GenerateRandomSpot(spawnArea);
            GameObject.Instantiate(prefab, coif * position.normalized, Quaternion.identity);
        }
    }

}
