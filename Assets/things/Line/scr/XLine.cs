using UnityEngine;
using System.Collections;

public class XLine : MonoBehaviour
{
	public GameObject Line;
	public GameObject FXef;//激光击中物体的粒子效果
    public float width = 0.5f;
    public float length = 8;

    void Update ()
    {
		RaycastHit hit;
		Vector3 Sc;// 变换大小
		Sc.x= width;
		Sc.z= width;
        //发射射线，通过获取射线碰撞后返回的距离来变换激光模型的y轴上的值
        FXef.SetActive(true);
        if (Physics.Raycast(transform.position, this.transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "boss")
            {
                Debug.DrawLine(this.transform.position, hit.point);
                Sc.y = hit.distance;
                FXef.transform.position = hit.point;//让激光击中物体的粒子效果的空间位置与射线碰撞的点的空间位置保持一致；
            }
            else
            {
                Sc.y = length;
                FXef.transform.position = transform.position+ Sc.y*transform.forward;
            }
		}
		//当激光没有碰撞到物体时，让射线的长度保持为500m，并设置击中效果为不显示
		else{
			Sc.y= length;
            FXef.transform.position = transform.position + Sc.y * transform.forward;
        }
			
		Line.transform.localScale=Sc;
            
	}
}
