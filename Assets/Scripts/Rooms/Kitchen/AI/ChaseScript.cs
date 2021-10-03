using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseScript : MonoBehaviour
{
    public void ChaseTarget(Transform player, float movementSpeed)
    {
        var direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.eulerAngles = Vector3.forward * angle;

        transform.position = transform.position + new Vector3(direction.x, direction.y, 0) * movementSpeed * Time.deltaTime;
    }
}
