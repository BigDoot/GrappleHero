using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Enemy1 : MonoBehaviour
{
    public int health = 2;
    public GameObject deathEffect;
    public GameObject bloodstain;
    public float knockbackFromWep = 2500f;
    public float bloodlifetime = 10f;

    public CinemachineVirtualCamera VirtualCamera;


    public virtual void TakeDamage(int damage)
    {
        VirtualCamera.GetComponent<SimpleCameraShakeInCinemachine>().smallshake();
        health -= damage;

        if (health <= 0)
        {
            Die();
            
        }
    }

    public virtual void Die()
    {
        GameObject bs = Instantiate(bloodstain, transform.position, Quaternion.identity);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(bs, bloodlifetime);
        VirtualCamera.GetComponent<SimpleCameraShakeInCinemachine>().shake();
    }


}
