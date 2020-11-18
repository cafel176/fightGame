using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : enemy
{
    public GameObject explosionRocket;
    public GameObject shield;
    public GameObject[] enemys;

    public float deltaTime = 0.5f;
    public int maxNum = 8;
    public bool canSpawn = false;

    public float enemySpeed = 1.0f;

    private float timer = 0;

    void Start()
    {
        canHit = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (canSpawn)
        {
            if (timer > deltaTime)
            {
                timer = 0;
                startSpawnEnemy();
            }
        }
    }

    public void changeCanHit(bool a)
    {
        canHit = a;
        shield.SetActive(!a);
    }

    public void startSpawnEnemy()
    {
        int num = Random.Range(0, maxNum);
        for (int i = 0; i < num; i++)
        {
            int index = Random.Range(0, enemys.Length);
            spawnEnemy(index);
        }
    }

    public void spawnEnemy(int enemy)
    {
        float angle= Random.Range(-180.0f, 180.0f);
        GameObject g = Instantiate(enemys[enemy], transform.position, enemys[enemy].transform.rotation) as GameObject;
        g.transform.Rotate(0,0,angle);
        g.GetComponent<mover>().move = g.transform.up;
        g.GetComponent<mover>().speed *= enemySpeed;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Attack")
        {
            if (canHit)
                getDamage(gameManager.instance.attack, collision.contacts[0].point);
        }
        else if (collision.collider.tag == "rocket")
        {
            Instantiate(explosionRocket, collision.collider.transform.position, Quaternion.identity);
            Destroy(collision.collider.gameObject);
            if (canHit)
                getDamage(gameManager.instance.attack, collision.contacts[0].point);
        }
    }
}
