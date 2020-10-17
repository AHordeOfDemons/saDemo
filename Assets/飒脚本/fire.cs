using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    private float rotx;


    public void fire1(float wqndyd)
    {
        Vector2 dibua = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;//Camera.main.ScreenToWorldPoint()  你要是使用Camera.main的话它会直接调用带有MainCamera标签(tag)的摄像机组件。
        float rotz = Mathf.Atan2(dibua.y, dibua.x) * Mathf.Rad2Deg;//h弧度制转角度制
        rotx = 0;

        if (rotz < 180 && rotz > 90)
        {
           // transform.parent.localScale = new Vector3(-1, 1, 1);
        //    transform.localScale = new Vector3(0.7f, 0.5f, 0.5f);
            rotx = 180;
            rotz = -rotz;
            
        }
        else if (rotz < -90 && rotz > -180)
        {

            // transform.parent.localScale = new Vector3(-1, 1, 1);
           // transform.parent.localScale = new Vector3(-1, 1, 1);
           /// transform.localScale = new Vector3(0.7f, 0.5f, 0.5f);
            rotx = 180;
            rotx = 180;
            rotz = -rotz;
        }

        if (wqndyd == -1)
        {
            transform.localScale = new Vector3(-0.7f, 0.5f, 0.5f);
        }
        else 
        {
            transform.localScale = new Vector3(0.7f, 0.5f, 0.5f);
        }
        transform.rotation = Quaternion.Euler(rotx, 0, rotz); //旋转图片

    }

    void off()
    {
        transform.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("enemy"))
        {

            GameObject.Find("工具物体").GetComponent<工具>().death(other.gameObject.transform, transform.rotation);
            other.gameObject.SendMessage("death", transform.parent.position); 

        }

    }
}
