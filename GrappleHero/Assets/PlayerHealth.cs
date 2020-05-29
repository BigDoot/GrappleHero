using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int fullhealth = 1; // tentatively player only has 1hp
    public int health = 1;
    public float respawnTime = 1.5f;

    private PlayerMovement player;
    public Transform start;
    public GameObject Explode;
    private throwhook throwHook;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        throwHook = FindObjectOfType<throwhook>(); // find throwhook script
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") 
        {
            Debug.Log(collision.gameObject.name);
            Debug.Log("here");
            TakeDamage(1);
        }
    }



    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            StartCoroutine("respawndelay");

        }
    }

    public IEnumerator respawndelay()

    {
        Instantiate(Explode, player.transform.position, player.transform.rotation);
        Destroy(throwHook.curHook);
        throwHook.ropeActive = false;
        player.enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic; // to freeze player in place
        player.GetComponent<throwhook>().enabled = false; // prevent player from use grappling hook while dead
        player.GetComponent<Renderer>().enabled = false;
        player.GetComponent<BoxCollider2D>().enabled = false; // prevent further collisions
        player.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(respawnTime);
        player.transform.position = start.position;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        player.GetComponent<throwhook>().enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<CircleCollider2D>().enabled = true;
        health = fullhealth; // reset health
        player.enabled = true;

    }

}
