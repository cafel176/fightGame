using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public weapons[] w;

    private Coroutine c;

    //0123，上下左右，4567从右上开始顺时针
    public void attack(int i)
    {
        w[i].gameObject.SetActive(true);
        w[i].attack();
    }

    public void circle()
    {
        if(gameManager.instance.nowWeapon==0)
            c = StartCoroutine(circle0(4));
        else if (gameManager.instance.nowWeapon == 1)
            c = StartCoroutine(circle0(1));
        else if (gameManager.instance.nowWeapon == 2)
            c = StartCoroutine(circle0(6));
    }

    public void stop()
    {
        StopCoroutine(c);
    }

    IEnumerator circle0(float time)
    {
        while(true)
        {
            yield return new WaitForSeconds(w[0].waitTime / time);
            w[0].gameObject.SetActive(true);
            w[0].attack();
            yield return new WaitForSeconds(w[4].waitTime / time);
            w[4].gameObject.SetActive(true);
            w[4].attack();
            yield return new WaitForSeconds(w[3].waitTime / time);
            w[3].gameObject.SetActive(true);
            w[3].attack();
            yield return new WaitForSeconds(w[5].waitTime / time);
            w[5].gameObject.SetActive(true);
            w[5].attack();
            yield return new WaitForSeconds(w[1].waitTime / time);
            w[1].gameObject.SetActive(true);
            w[1].attack();
            yield return new WaitForSeconds(w[6].waitTime / time);
            w[6].gameObject.SetActive(true);
            w[6].attack();
            yield return new WaitForSeconds(w[2].waitTime / time);
            w[2].gameObject.SetActive(true);
            w[2].attack();
            yield return new WaitForSeconds(w[7].waitTime / time);
            w[7].gameObject.SetActive(true);
            w[7].attack();
        }
    }
}
