﻿using UnityEngine;
using TMPro;

public class SampleInventory : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CoinText;

    private int CurrentCoins;

    public int CurrentCoins1 { get => CurrentCoins; set => CurrentCoins = value; }

    // Start is called before the first frame update
    void Start()
    {
        UpdateCoins();
    }

    // Add money or Lose money
    /// <summary>
    /// Positive Number to increase money, Negative number to decrease money
    /// </summary>
    /// <param name="money"></param>
    public void ModifiyCoins(int money)
    {
        CurrentCoins1 += money;
        UpdateCoins();
    }

    public void UpdateCoins() {
        //CoinText.text = "$" + CurrentCoins1.ToString();
    }
}
