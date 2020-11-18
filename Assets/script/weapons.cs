using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapons : MonoBehaviour
{
    public bool canAttack = true;

    public float waitTime = 1;

    protected float timer = 0;
    protected AudioSource _audio;

    public void attack()
    {
        if (canAttack)
        {
            canAttack = false;
            timer = 0;
            if (_audio == null)
                _audio = gameObject.GetComponent<AudioSource>();
            _audio.volume = gameManager.instance.SE / 100;
            _audio.Play();
            startAttack();
        }
    }

    virtual public void startAttack()
    {
    }
}
