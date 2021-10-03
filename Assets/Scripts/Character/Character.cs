using UnityEngine;

public class Character : MonoBehaviour
{
    // Inspector stuff.
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer spriteRenderer;

    // State.
    private CharacterState characterStateBackingField;
    private AbstractCharacterAction actionExecuter;

    // Input.
    public Vector2 movementDirection;
    public Vector2 mousePos;
    public bool mouseDown;

    public static Character Instance = null;

    public CharacterState CharacterState
    {
        get => characterStateBackingField;

        set
        {
            characterStateBackingField = value;

            if (spriteRenderer == null)
            {
                return;
            }

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

            spriteRenderer.color = color;
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

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private CharacterState RandomState()
    {
        return (CharacterState)Random.Range(0, (int)CharacterState.TypeCount);
    }

    private void Update()
    {
        Walk();

        //actionExecuter.UpdateAction();

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