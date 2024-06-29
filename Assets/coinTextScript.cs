using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinTextScript : MonoBehaviour
{
    public TMP_Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        coinText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.SetText("Coins: " + PlayerPrefs.GetInt("coins") );
    }
}
