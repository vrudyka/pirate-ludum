using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    private List<HoldingObjectType> stuffCollected = new List<HoldingObjectType>();

    public int numOfparticles;

    public GameObject saltBar;
    public GameObject sugarBar;
    public GameObject wiskBar;

    public int particles;

    private CookingController controller;

    private HoldingObjectType saltOrSugar;
    private bool once;

    public GameObject rawSirnik;
    private Character character;

    private void Awake()
    {
        rawSirnik.SetActive(false);

        saltBar.transform.localScale = Vector3.zero;
        sugarBar.transform.localScale = Vector3.zero;
        wiskBar.transform.localScale = Vector3.zero;

        controller = FindObjectOfType<CookingController>();
        character = FindObjectOfType<Character>();
    }

    private void Update()
    {
        float p = (float)particles / numOfparticles;

        if (p <= 1f)
        {
            if (HoldingObjectType.Salt == saltOrSugar)
            {
                saltBar.transform.localScale = new Vector3(p, 0.5f, 1f);
            }
            if (HoldingObjectType.Sugar == saltOrSugar)
            {
                sugarBar.transform.localScale = new Vector3(p, 0.5f, 1f);
            }
        }

        if (p > 0.33f && p < 0.66f)
        {
            if (once == false)
            {
                controller.NextInQueue();

                once = true;
            }
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

                controller.NextInQueue();
            }

            if (holdingObj.type == HoldingObjectType.Salt ||
                holdingObj.type == HoldingObjectType.Sugar)
            {
                var sp = holdingObj.GetComponent<ShootingParticles>();
                sp.Commence();

                if (saltOrSugar != holdingObj.type)
                {
                    particles = 0;

                    once = false;
                }

                saltOrSugar = holdingObj.type;
            }
        }

        var flyingParticle = collision.gameObject.GetComponent<FlyingParticle>();
        if (flyingParticle != null)
        {
            if (flyingParticle.type == Condiment.Salt && HoldingObjectType.Salt == saltOrSugar)
            {
                particles += 1;
            }
            if (flyingParticle.type == Condiment.Sugar && HoldingObjectType.Sugar == saltOrSugar)
            {
                particles += 1;
            }
        }

    }

    private Vector3 movementCache;
    public float timeMixing;
    public float neededMixingTime;

    private void OnTriggerStay2D(Collider2D collision)
    {
        var holdingObj = collision.gameObject.GetComponent<HoldingObject>();
        if (holdingObj != null)
        {
            if (holdingObj.type == HoldingObjectType.Fork ||
                holdingObj.type == HoldingObjectType.Masher)
            {
                if (holdingObj.transform.position != movementCache)
                {
                    timeMixing += Time.deltaTime;

                    var t = timeMixing / neededMixingTime;

                    if (t > 1f)
                    {
                        controller.NextInQueue();
                        controller.NextInQueue();
                    }

                    wiskBar.transform.localScale = new Vector3(Mathf.Clamp(t, 0f, 1f), 0.5f, 1f);
                }

                movementCache = holdingObj.transform.position;
            }
        }

        //Debug.Log($"ayeee {character.mouseDown == true} {collision.gameObject.name} {controller.queueNumber}");

        if (character.mouseDown == true && collision.gameObject.name == "Character" && controller.queueNumber == 8)
        {
            rawSirnik.SetActive(true);

            controller.holdingObj = rawSirnik;

            rawSirnik.transform.parent = collision.gameObject.transform;
        }
    }
}
