using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    private List<HoldingObjectType> stuffCollected = new List<HoldingObjectType>();

    public int particles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ссс");


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var holdingObj = collision.gameObject.GetComponent<HoldingObject>();
        if (holdingObj != null)
        {
            if (holdingObj.type == HoldingObjectType.Egg ||
                holdingObj.type == HoldingObjectType.Sir)
            {
                stuffCollected.Add(holdingObj.type);

                GameObject.Destroy(holdingObj.gameObject);
            }

            if (holdingObj.type == HoldingObjectType.Salt ||
                holdingObj.type == HoldingObjectType.Sugar)
            {
                var sp = holdingObj.GetComponent<ShootingParticles>();
                sp.Commence();
            }
        }
        Debug.Log("ueee");

        var flyingParticle = collision.gameObject.GetComponent<FlyingParticle>();
        if (flyingParticle != null)
        {
            particles += 1;
        }     
    }
}
