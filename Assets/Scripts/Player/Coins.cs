using System;
using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coins;
    [SerializeField] private TMP_Text coinText;
    void Start()
    {
        coinText = GameObject.FindGameObjectWithTag("CoinText").GetComponent<TMP_Text>();
        coins = PlayerPrefs.GetInt("coins");
    }
    void FixedUpdate()
    {
        PlayerPrefs.SetInt("coins", coins);
        coinText.text = $"Coins: {coins}";
    }
}
