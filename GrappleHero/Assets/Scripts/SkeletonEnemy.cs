using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemy : Enemy1
{
    public Animator animator;


    new public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            animator.Play("Skeleton_Death");
            Die();
        }
    }

    new public void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject, 5f); // delay destroying of enemy to allow animation to play
    }


}