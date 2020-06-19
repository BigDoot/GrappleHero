using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    private PlayerMovement player;
    private throwhook throwHook;
    public AudioManager audioManager;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        throwHook = FindObjectOfType<throwhook>(); // find throwhook script
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            audioManager.Play("Collect");
            //FindObjectOfType<AudioManager>().Play("Collect");
            Destroy(gameObject);
            player.goldCoins++;
        }
        else if (other.tag == "Grappling Hook")
        {
            FindObjectOfType<AudioManager>().Play("Collect");
            Destroy(gameObject);
            player.goldCoins++;
            Destroy(throwHook.curHook);
            throwHook.ropeActive = false;
        }
    }
}
