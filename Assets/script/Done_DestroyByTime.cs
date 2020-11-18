using UnityEngine;
using System.Collections;

public class Done_DestroyByTime : MonoBehaviour
{
	public float lifetime;

	void Start ()
	{
        if(transform.parent!=null)
            Destroy(transform.parent.gameObject, lifetime);
        else
            Destroy(gameObject, lifetime);
	}
}
