using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Inspector stuff.
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer renderer;

    // State.
    public CharacterState characterStateBackingField;

    // Input.
    private Vector2 movementDirection;
    private Vector2 mousePos;
    private bool mouseDown;

    public CharacterState CharacterState
    {
        get => characterStateBackingField;

        set
        {
            characterStateBackingField = value;

            var color = Color.white;

            switch (characterStateBackingField)
            {
                case CharacterState.Destructive:
                    color = Color.red;
                    break;
                case CharacterState.Builder:
                    color = Color.blue;
                    break;
                case CharacterState.Enlarger:
                    color = Color.magenta;
                    break;
                case CharacterState.Stupid:
                    color = Color.yellow;
                    break;
            }

            renderer.color = color;
        }
    }

    public void Die()
    {
        CharacterState = RandomState();
    }

    private void Awake()
    {
        CharacterState = RandomState();
    }

    private CharacterState RandomState()
    {
        return (CharacterState)Random.Range(0, (int)CharacterState.TypeCount);
    }

    private void Update()
    {
        Walk();

        if (mouseDown)
            Die();
    }

    private void LateUpdate()
    {
        movementDirection.x = Input.GetAxis("Horizontal");
		movementDirection.y = Input.GetAxis("Vertical");

        mouseDown = Input.GetMouseButtonDown(0);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Walk()
    {
        Vector3 velocity = new Vector3(movementDirection.x, movementDirection.y, 0f);
        Vector3 displacement = velocity * Time.deltaTime * speed;
        transform.localPosition += displacement;
    }
}

public enum CharacterState
{
    Destructive, 
    Builder, 
    Enlarger,
    Stupid,

    TypeCount
}