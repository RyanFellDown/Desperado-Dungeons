using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    Text counterText;
    public int coinCounterAmount;

    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Set the current number of coins to display
        if (counterText.text != CoinScript.totalCoins.ToString())
        {
            counterText.text = CoinScript.totalCoins.ToString();
        }
        coinCounterAmount = int.Parse(counterText.text);
    }

    public int NumberOfCoins()
    {
        return coinCounterAmount;
    }

    public void SubtractCoins(int coins)
    {
        coinCounterAmount = coinCounterAmount - coins;
        CoinScript.totalCoins = CoinScript.totalCoins - coins;
    }
}
