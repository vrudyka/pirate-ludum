using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBomb : MonoBehaviour
{
    private Transform mother;

   [SerializeField] private float cooldownTimer;

   [SerializeField] private float cooldown;

    private void Start()
    {
        mother = GameObject.FindGameObjectWithTag("MotherAI").GetComponent<Transform>();
    }

    private Vector3 CalculateVelosity(Vector3 origin, Vector3 target, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        // create a float the represents our distance

        float distanceY = distance.y;
        float fullDustanceXZ = distanceXZ.magnitude;

        float velocityXZ = fullDustanceXZ / time;
        float velocityY = distanceY / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= velocityXZ;
        result.y = velocityY;

        return result;
    }

    public void ShotOnDistance(Transform player, Rigidbody2D bompPrefab)
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer > 0) return;

        cooldownTimer = cooldown;

        Vector3 Vo = CalculateVelosity(mother.transform.position, player.transform.position, 1f);
       
        var obj = Instantiate(bompPrefab, transform.position, Quaternion.identity);
        obj.velocity = Vo;
    }
}
