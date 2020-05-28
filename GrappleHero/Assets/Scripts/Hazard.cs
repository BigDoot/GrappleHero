using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour
{

    private PlayerMovement player;
    public Transform start;
    public GameObject Explode;
    private throwhook throwHook;

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
        player.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1);
        player.transform.position = start.position;
        player.GetComponent<Renderer>().enabled = true;
        player.enabled = true;

    }
}
