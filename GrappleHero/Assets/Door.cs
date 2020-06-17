using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public LevelLoader lvlloader;

    // Start is called before the first frame update
    void Start()
    {
        lvlloader = FindObjectOfType<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lvlloader.LoadNextLevel();
    }
}
