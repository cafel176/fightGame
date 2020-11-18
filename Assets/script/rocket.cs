using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : weapons
{
    public GameObject rockets;
    public float rocketSpeed = 50;

    private void Start()
    {
#if UNITY_EDITOR
        rocketSpeed = 5;
#endif
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime && !canAttack)
            canAttack = true;
    }

    override public void startAttack()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject g = Instantiate(rockets, transform.GetChild(i).position, Quaternion.identity) as GameObject;
            Vector3 move = gameManager.instance.boss.transform.position - transform.GetChild(i).position;
            g.transform.up = move;
            g.GetComponent<mover>().move = g.transform.up;
            g.GetComponent<mover>().speed = rocketSpeed * Time.deltaTime / (waitTime * 0.5f);
        }
    }
}
