using TMPro;

using UnityEngine;

public class Goods : MonoBehaviour
{
    // Public fields

    [SerializeField] private SpriteRenderer goodsColor;
    [SerializeField] private int id;
    [SerializeField] private int spoilCoef;

    private float spoiledTimer;
    public bool isSpoiled;

    private void Awake()
    {
        goodsColor.color = Color.white;
        spoiledTimer = 255;
    }
    private void Update()
    {
        spoiledTimer -= (Time.deltaTime * spoilCoef);
        goodsColor.color = new Color(255/255f, spoiledTimer/255f, spoiledTimer/255f, 255/255f);

        if (spoiledTimer <= 0)
        {
            isSpoiled = true;
        }
    }
}