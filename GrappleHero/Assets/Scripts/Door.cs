using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private PlayerMovement player;

    public LevelLoader lvlloader;

    // Start is called before the first frame update
    void Start()
    {
        lvlloader = FindObjectOfType<LevelLoader>();
        player = FindObjectOfType<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.keys > 0)
        {
            player.keys--;
            lvlloader.LoadNextLevel();
        }

    }
}
