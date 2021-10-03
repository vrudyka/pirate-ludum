using System;
using UnityEngine;

public class FlyingParticle : MonoBehaviour
{
    public Condiment type;

    public float speed;

    private Vector3 displacement;

    private float timer;

    private void Update()
    {
        var dt = Time.deltaTime;

        transform.Rotate(Vector3.back, dt * speed);

        if (displacement != Vector3.zero)
        {
            transform.localPosition += displacement * dt;
        }

        timer += dt;
        if (timer > 2f)
        {
            Destroy(gameObject);
        }
    }

    internal void SetDirection(Vector3 direction)
    {
        var normalizedDir = direction.normalized;

        var velocity = new Vector3(normalizedDir.x, normalizedDir.y, 0f);
        displacement = velocity * speed;
    }
}

public enum Condiment
{
    Salt, 
    Sugar
}