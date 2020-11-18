using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : weapons
{
    public Vector3 startPos;

    private Vector3 pos,move;
    private bool anima = false;

    private void Start()
    {
        pos = Vector3.zero;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime && !canAttack)
            canAttack = true;
        doSth();
    }

    override public void startAttack()
    {
        anima = true;
        move = (pos-startPos) / (waitTime / 3);
    }

    void doSth()
    {
        float x = 0.08f;
#if UNITY_EDITOR
        x = 0.4f;
#endif
        if (anima)
        {
            transform.localPosition += move * Time.deltaTime;
            if ((transform.localPosition - pos).sqrMagnitude < x)
            {
                move = (startPos-pos) * 2 / (waitTime / 3);
                transform.localPosition = pos;
            }
            else if (Mathf.Abs(timer - waitTime) < 0.05f)
            {
                transform.localPosition = startPos;
                anima = false;
                canAttack = true;
                gameObject.SetActive(false);
            }
        }
    }
}
