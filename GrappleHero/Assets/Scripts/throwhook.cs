using UnityEngine;
using System.Collections;

public class throwhook : MonoBehaviour
{


    public GameObject hook;


    public bool ropeActive;

    GameObject curHook;

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

                RaycastHit2D hit = Physics2D.Raycast(destiny, Vector2.zero);

                if (hit != null && hit.collider != null)
                {
                    curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);

                    curHook.GetComponent<RopeScript>().destiny = destiny;

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