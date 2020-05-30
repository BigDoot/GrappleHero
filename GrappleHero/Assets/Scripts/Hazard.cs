using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class Hazard : MonoBehaviour
{

    private PlayerMovement player;
    public Transform start;
    public GameObject Explode;
    public GameObject EnemyDeathEffect;
    private throwhook throwHook;
   // private GameObject enemy;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        throwHook = FindObjectOfType<throwhook>(); // find throwhook script
      //  enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine("respawndelay");
        }
        else if (other.tag == "Enemy")
        {
            Instantiate(EnemyDeathEffect, other.gameObject.transform.position, other.gameObject.transform.rotation);
            Destroy(other.gameObject);
        }
    }
    public IEnumerator respawndelay()

    {
        Instantiate(Explode, player.transform.position, player.transform.rotation);
        Destroy(throwHook.curHook);
        throwHook.ropeActive = false;
        player.enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<Renderer>().enabled = false;
        player.GetComponent<TrailRenderer>().enabled = false; // disable trail renderer
        yield return new WaitForSeconds(1);
        player.transform.position = start.position;
        player.GetComponent<Renderer>().enabled = true;
        player.GetComponent<TrailRenderer>().enabled = true;
        player.enabled = true;

    }
}
