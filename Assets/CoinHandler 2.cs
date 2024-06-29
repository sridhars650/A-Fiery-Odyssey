using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHandler : MonoBehaviour
{
    public PolygonCollider2D polygonCollider;
    public int value = 1; // change the coin's value
    public int coins;
    public GameObject coinObject;
    private bool collected = false; // Flag to ensure the coin is collected only once

    // Start is called before the first frame update
    void Start()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();
        coinObject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        coins = PlayerPrefs.GetInt("coins");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collected && collision.gameObject.layer == 3)
        {
            collected = true; // Set the flag to true
            coins += value;
            PlayerPrefs.SetInt("coins", coins);
            coinObject.SetActive(false);
        }
    }

    [ContextMenu("Reset Coins")]
    public void resetCoins()
    {
        PlayerPrefs.SetInt("coins",0);
    }
}
