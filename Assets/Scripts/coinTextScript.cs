using UnityEngine;
using TMPro;

public class coinTextScript : MonoBehaviour
{
    public TMP_Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        coinText = GetComponent<TMP_Text>();
        UpdateCoinText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        coinText.SetText("Coins: " + PlayerPrefs.GetInt("coins"));
    }
}
