using System;
using System.Collections.Generic;
using UnityEngine;

public class CookingController : MonoBehaviour
{
    // Сир (400 г) перекладіть в невелику скляну або пластикову миску
    // Додайте дрібку солі,
    //                одне яйце,
    //                3 ст. л. цукру,
    //                і 10 г ванільного цукру.

    // Після того, як ви покладете всі інгредієнти до миски, перемішайте їх до отримання однорідної маси.
    // Для цього найкраще використовувати звичайну виделку,
    //                                             ложку або
    //                                             товкучку для картоплі.

    // До отриманої сирної суміші додайте 3 ст. л. пшеничного борошна

    // Make circles

    // Fry

    // Turn

    // Serve with jam

    [SerializeField] private GameObject _exitTriggerGameObject;

    public GameObject cookingThings;
    public GameObject cursor;

    public List<HoldingObjectStuff> queueThings;
    public int queueNumber;

    private Character character;
    public GameObject holdingObj;

    public FireSwitch fireSwitch;

    private void Awake()
    {
        character = FindObjectOfType<Character>();

        fireSwitch.switched += FireSwitchSwitched;

        NextInQueue();
    }

    private void FireSwitchSwitched()
    {
        NextInQueue();

        // Fireeee
    }

    public void NextInQueue()
    {
        foreach (var obj in queueThings)
        {
            obj.obj.SetHighlight(false);
        }

        queueThings[queueNumber].obj.SetHighlight(true);

        queueNumber++;
    }

    public void Winnn()
    {
        _exitTriggerGameObject.SetActive(true);
    }

    private void Update()
    {
        cursor.transform.position = character.mousePos;

        if (character.mouseDown == true)
        {
            if (holdingObj != null)
            {
                holdingObj.transform.parent = null;

                holdingObj = null;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (holdingObj == null)
        {
            var holdingObjComp = collision.gameObject.GetComponent<HoldingObject>();
            if (holdingObjComp == null)
                return;

            if (holdingObjComp.type == HoldingObjectType.Bowl ||
                holdingObjComp.type == HoldingObjectType.Switch ||
                holdingObjComp.type == HoldingObjectType.Pan)
                return;

            holdingObj = collision.gameObject;

            collision.gameObject.transform.parent = character.transform;
        }
    }

    [Serializable]
    public class HoldingObjectStuff
    {
        public HoldingObjectType type;
        public HoldingObject obj;
    }
}
