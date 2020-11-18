using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int hp = 5;

    public GameObject explosionHit;
    public GameObject explosionDie;

    protected bool canHit = true;

    public void getDamage(int num,Vector3 pos)
    {
        hp -= num;
        if (hp <= 0)
        {
            die();
        }
        else
        {
            if (explosionHit != null)
            {
                Instantiate(explosionHit, pos, transform.rotation);
            }
        }
    }

    public void die()
    {
        if (explosionDie != null)
        {
            Instantiate(explosionDie, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
            Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Attack"|| collision.collider.tag == "rocket")
        {
            if (canHit)
                getDamage(gameManager.instance.attack, collision.contacts[0].point);
        }
    }
}
