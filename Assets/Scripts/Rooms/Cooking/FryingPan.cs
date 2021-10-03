using UnityEngine;

public class FryingPan : MonoBehaviour
{
    public float timer = -1f;
    public float timeToFry;

    private bool once;

    private CookingController controller;

    private void Awake()
    {
        controller = FindObjectOfType<CookingController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name == "raw sirnik")
        {
            Destroy(collision.gameObject);
       
            timer = 0f;
        }

        if (collision.gameObject.name == "masher" && timer == -2f)
        {
            // turn.

            timer = -1f;
        }
    }

    private void Update()
    {
        if (timer == -1f)
            return;

        timer += Time.deltaTime;
    
        if (timer >= timeToFry)
        {
            if (once == true)
                controller.Winnn();

            controller.NextInQueue();

            timer = -2f;

            once = true;
        }
    }
}
