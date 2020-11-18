using UnityEngine;
using System.Collections;

namespace K2Games
{
    //This is a bit of a hack to help the reset button in the shop to maintain it scale correctly
    public class ForceScale : MonoBehaviour
    {
        void Update()
        {
            transform.localScale = new Vector3(1 / transform.parent.localScale.x, 1 / transform.parent.localScale.y, 1 / transform.parent.localScale.z);
        }
    }
}