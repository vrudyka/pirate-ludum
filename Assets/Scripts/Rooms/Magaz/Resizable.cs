using UnityEngine;

public class Resizable : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxScale;
    [SerializeField] private float minScale;
    [SerializeField] private Vector2 resizeAxes;

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

    private void OnMouseOver()
    {
        if (!isHoldingMouseDown)
            return;

        scalingCoef = Mathf.PingPong(Time.time * speed, maxScale);
        var localScale = gameObject.transform.localScale;
        currentScale = localScale;
 
        var scaling = Mathf.Clamp(basicScale.x * scalingCoef, basicScale.x * minScale, basicScale.x * maxScale);
        var coefChanged = scaling / currentScale.x;

        if (resizeAxes.x <= 0 || resizeAxes.y <= 0)
        {
            var scaledVector =  resizeAxes * coefChanged;
            gameObject.transform.localScale = new Vector2(scaledVector.x <= 0 ? localScale.x : scaledVector.x, scaledVector.y <= 0 ? localScale.y : scaledVector.y);
        }
        else
        {
            gameObject.transform.localScale *= coefChanged;
        }
    }
}