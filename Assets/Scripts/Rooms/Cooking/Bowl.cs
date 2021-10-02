using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    private List<HoldingObjectType> stuffCollected = new List<HoldingObjectType>();

    public int numOfparticles;

    public GameObject minBar;
    public GameObject modBar;
    public GameObject maxBar;

    public int particles;

    private void Awake()
    {
        minBar.transform.localScale = Vector3.zero;
        modBar.transform.localScale = Vector3.zero;
        maxBar.transform.localScale = Vector3.zero;
    }
    
    private void Update()
    {
        float p = (float)particles / numOfparticles;

        if (p < 0.33f)
        {
            minBar.transform.localScale = new Vector3(p / 0.33f, 0.5f, 1f);
        }
        if (p > 0.33f && p < 0.66f)
        {
            modBar.transform.localScale = new Vector3((p - 0.33f) / 0.33f, 0.5f, 1f);
        }
        if (p > 0.66f && p < 1f)
        {
            maxBar.transform.localScale = new Vector3((p - 0.66f) / 0.33f, 0.5f, 1f);
        }
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

        var flyingParticle = collision.gameObject.GetComponent<FlyingParticle>();
        if (flyingParticle != null)
        {
            particles += 1;
        }
    }
}
