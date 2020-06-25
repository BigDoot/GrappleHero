using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorCheck : MonoBehaviour
{

    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
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
                gameObject.GetComponentInParent<LockedDoor>().opened = true;
            }



    }
}
