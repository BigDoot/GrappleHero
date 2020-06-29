using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowEnemy : Enemy1
{
    public float speed = 3.0f;
    public bool MovingRight;
    public GameObject right;
    public GameObject left;

    // Update is called once per frame
    void Update()
    {
        if (MovingRight)
        {
            if (Vector3.Distance(transform.position, right.transform.position) <= 0) 
                // check if distance between crow and right turn gameobject is less than 0
            {
                MovingRight = false;
                MoveLeft();
            }
            else
            {
                MoveRight();
            }
        } else
        {
            if (Vector3.Distance(transform.position, left.transform.position) <= 0)
            {
                MovingRight = true;
                MoveRight();
            }
            else
            {
                MoveLeft();
            }
        }
    }

    void MoveRight()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.position = Vector3.MoveTowards(transform.position, right.transform.position, speed * Time.deltaTime);
        // moves crow towards right turn game object
    }

    void MoveLeft()
    {
        transform.eulerAngles = new Vector3(0, -180, 0); // flip sprite
        transform.position = Vector3.MoveTowards(transform.position, left.transform.position, speed * Time.deltaTime);
    }


    public override void Die()
    {
        GameObject bs = Instantiate(bloodstain, transform.position, Quaternion.identity);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(bs, bloodlifetime);
        camRipple.RippleEffect();
        VirtualCamera.GetComponent<SimpleCameraShakeInCinemachine>().shake();

    }
}
