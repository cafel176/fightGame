using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : weapons
{
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 move = gameManager.instance.boss.transform.position - transform.GetChild(i).position;
            transform.GetChild(i).GetChild(0).forward = move;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (!canAttack && timer > waitTime)
        {
            canAttack = true;
            gameObject.SetActive(false);
        }
    }

    override public void startAttack()
    {

    }
}
