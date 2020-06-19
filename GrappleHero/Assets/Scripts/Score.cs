using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text text;
    private PlayerMovement player;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        text.text = "Crystals: " + player.crystals + "\nKeys: " + player.keys + "\nGold Coins: " + player.goldCoins;
    }
}