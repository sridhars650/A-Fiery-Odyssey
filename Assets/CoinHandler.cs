using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHandler : MonoBehaviour
{
    public PolygonCollider2D polygonCollider;
    public int value = 1; // change the coins value
    public int coins;
    public GameObject coinObject;

    // Start is called before the first frame update
    void Start()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();
        coins = PlayerPrefs.GetInt("coins");
        coinObject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            coins += value;
            PlayerPrefs.SetInt("coins", coins);
            coinObject.SetActive(false);
        }
    }

    
}
