using UnityEngine;

public class Resizable : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private float maxScale = 3;
    [SerializeField] private float minScale = 0.3f;

    private Vector3 basicScale;
    private Vector3 currentScale;
  
    private bool isHoldingMouseDown;
    private float scalingCoef;

    private void OnMouseUp()
    {
        currentScale = gameObject.transform.localScale;
        isHoldingMouseDown = false;
    }

    private void OnMouseDown() => isHoldingMouseDown = true;

    private void Start()
    {
        basicScale = gameObject.transform.localScale;
    }

    void OnMouseOver()
    {
        if (!isHoldingMouseDown)
            return;

        scalingCoef = Mathf.PingPong(Time.time * speed, maxScale);
        currentScale = gameObject.transform.localScale;
 
        var scaling = Mathf.Clamp(basicScale.x * scalingCoef, basicScale.x * minScale, basicScale.x * maxScale);
        var coefChanged = scaling / currentScale.x;

        gameObject.transform.localScale *= coefChanged;
    }
}