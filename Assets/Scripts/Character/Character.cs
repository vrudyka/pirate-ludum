using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    // Inspector stuff.
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer renderer;

    // State.
    private CharacterState characterStateBackingField;
    private AbstractCharacterAction actionExecuter;

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
                    {
                        color = Color.red;
                        actionExecuter = new Destructive();
                        break;
                    }
                case CharacterState.Builder:
                    {
                        color = Color.blue;
                        actionExecuter = new Builder();
                        break;
                    }
                case CharacterState.Enlarger:
                    {
                        color = Color.magenta;
                        actionExecuter = new Enlarger();
                        break;
                    }
                case CharacterState.Stupid:
                    {
                        color = Color.yellow;
                        actionExecuter = new Stupid();
                        break;
                    }
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
        DontDestroyOnLoad(gameObject);

        CharacterState = RandomState();
    }

    private CharacterState RandomState()
    {
        return (CharacterState)Random.Range(0, (int)CharacterState.TypeCount);
    }

    private void Update()
    {
        Walk();

        actionExecuter.UpdateAction();

        if (mouseDown)
        {
            ////SceneManager.LoadScene("Batya");
        }
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

    private void ExecuteStateAction()
    {
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