﻿using UnityEngine;
using System.Collections;

public class throwhook : MonoBehaviour // can think of this script as the "weapon"
{

    public GameObject hook;


    public bool ropeActive;

    public GameObject curHook;

    public float ropeLength = 7f;

    public LayerMask grappleMask;

    public float boostForce = 1000f;

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
            if (ropeActive && gameObject.GetComponent<CharacterController2D>().m_Grounded == false)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, boostForce)); // boost player upwards when rope is withdrawn

            }

            //delete rope

            Destroy(curHook);

            ropeActive = false;
        }
       
        if (Input.GetButtonDown("Jump")) // alternative method to unhook which does not have boost
        {
            if (ropeActive)
            {
                Destroy(curHook);

                ropeActive = false;
            }
        }

    }
}