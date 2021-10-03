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

    public bool _isCanMove;

    public static Character Instance = null;


    public void Die()
    {
        
    }

    private void Awake()
    {
        
    }

    private void Start()
    {
        AllowMove();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Dialog.OnDialogStarted += BanMove;
        Dialog.OnDialogEnded += AllowMove;
    }


    private void OnDisable()
    {
        Dialog.OnDialogStarted -= BanMove;
        Dialog.OnDialogEnded -= AllowMove;
    }


    private void Update()
    {
        if (_isCanMove)
        {
            Walk();
        }

        //actionExecuter.UpdateAction();

        if (mouseDown)
        {
            ////SceneManager.LoadScene("Batya");
        }
    }

    private void AllowMove()
    {
        _isCanMove = true;
    }

    private void BanMove()
    {
        _isCanMove = false;
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