using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GarbageScript : MonoBehaviour
{
    public int coinsCount = 0;

    // [SerializeField] TextMeshProUGUI textCoins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player") 
        {
            coinsCount+=1;
            // textCoins.text = coinsCount.ToString();
            Debug.Log("PICK COIN");
            Destroy(this.gameObject);
        }
    }
}