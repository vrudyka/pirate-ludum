using TMPro;

using UnityEngine;

public class Ball : MonoBehaviour
{
    // Public fields

    [SerializeField] private TextMeshProUGUI collectedItemsText;

    private Vector2 movementDirection;
    private Vector2 mousePos;
    private Vector3 dragDirection;
    private bool mouseDown;
    private bool mouseUp;
    private bool isAiming;
    private bool firstTimeVelocitySave;
    private float speed;
    private Vector2 savedVelocity;
    private Vector2 startingPos;
    private int collectedItems;
    private int spoiledItems;
    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDown = Input.GetMouseButton(0);
        mouseUp = Input.GetMouseButtonUp(0);

        SetDirection();

        if (mouseUp && isAiming)
        {
            isAiming = false;

            rigidbody.velocity = movementDirection * Time.deltaTime * speed;
        }

        collectedItemsText.text = $"{collectedItems}/7";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var BounceRate = 1.5f;

        if (!firstTimeVelocitySave)
        {
            savedVelocity = rigidbody.velocity;
            firstTimeVelocitySave = true;
        }

        rigidbody.velocity = new Vector2(rigidbody.velocity.x, savedVelocity.y);
        savedVelocity.y /= BounceRate;

        if (collision.gameObject.CompareTag("Goods"))
        {
            collectedItems++;
            spoiledItems = collision.gameObject.GetComponent<Goods>().isSpoiled == true ? spoiledItems + 1 : spoiledItems;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "verticalWall")
        {
            movementDirection.x *= -1;
        }
        else if (collision.gameObject.tag == "horizontalWall")
        {
            movementDirection.y *= -1;
        }
        else if (collision.gameObject.tag == "sphereCollider")
        {
            if (collision.gameObject.transform.position.x > gameObject.transform.position.x || collision.gameObject.transform.position.x < gameObject.transform.position.x)
            {
                movementDirection.y *= -1;
            }

            if (collision.gameObject.transform.position.y > gameObject.transform.position.y || collision.gameObject.transform.position.y < gameObject.transform.position.y)
            {
                movementDirection.x *= -1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Goods")
        {
            collectedItems++;
            spoiledItems = collider.gameObject.GetComponent<Goods>().isSpoiled == true ? spoiledItems + 1 : spoiledItems;
            Destroy(collider.gameObject);
        }
    }

    private void SetDirection()
    {
        if (!mouseDown)
            return;

        if (!isAiming)
        {
            startingPos = mousePos;
            isAiming = true;
        }

        dragDirection = mousePos - startingPos;
        speed = dragDirection.magnitude * 100;
        movementDirection = dragDirection.normalized * -1;
    }
}
