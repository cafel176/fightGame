using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void OnEnable()
    {
        gameObject.GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
    }
    
}
