using System.Collections.Generic;
using UnityEngine;

public class ShootingParticles : MonoBehaviour
{
    public bool superModeOn;
    private int superCounter;
    private bool yeah;
    private int superTokens;

    public float speed;

    public GameObject particlePrefab;

    public float timer;
    private float time;

    public List<Transform> spawnPoints;
    private int spwnPointID = 0;

    private bool started;

    public void Commence()
    {
        started = true;
    }

    private void Update()
    {
        if (started == false)
            return;

        transform.Rotate(Vector3.back, Time.deltaTime * speed);

        time += Time.deltaTime;
        if (time >= timer)
        {
            time -= timer;

            var particle = PrefabUtils.InstantiateAndGetComponent<FlyingParticle>(particlePrefab);

            particle.transform.position = spawnPoints[spwnPointID].position;

            particle.SetDirection(particle.transform.position - transform.position);

            spwnPointID++;
            if (spwnPointID >= spawnPoints.Count)
            {
                spwnPointID = 0;
            }

            if (superModeOn == true)
            {
                superCounter += 1;

                superTokens = yeah ? 50 : 80;

                if (superCounter >= superTokens)
                {
                    speed = -speed;

                    yeah = !yeah;

                    superCounter = 0;
                }
            }
        }
    }
}
