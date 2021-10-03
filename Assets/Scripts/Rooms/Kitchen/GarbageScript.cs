using UnityEngine;
using TMPro;


public class GarbageScript : MonoBehaviour
{
    public int garbegeCount = 0;

    [SerializeField] TextMeshProUGUI textGarbage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Garbege") 
        {
            garbegeCount += 1;
            textGarbage.text = garbegeCount.ToString();
            Destroy(collision.gameObject);
        }
    }
}