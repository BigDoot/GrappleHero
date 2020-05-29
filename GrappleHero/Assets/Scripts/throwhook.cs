using UnityEngine;
using System.Collections;

public class throwhook : MonoBehaviour // can think of this script as the "weapon"
{

    public GameObject hook;


    public bool ropeActive;

    public GameObject curHook;

    public float ropeLength = 7f;

    public LayerMask grappleMask;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (!ropeActive)
            {

               // RaycastHit2D hit = Physics2D.Raycast(destiny, Vector2.zero);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, destiny - (Vector2)transform.position, ropeLength, grappleMask); // shoot raycast from player to destiny of length ropeLength

                if (hit.collider != null)
                {
                    curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);            
                    curHook.GetComponent<RopeScript>().destiny = hit.point;

                    ropeActive = true;
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            //delete rope

            Destroy(curHook);

            ropeActive = false;
        }


    }
}