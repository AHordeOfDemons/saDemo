using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 工具 : MonoBehaviour
{
    public GameObject a0;
    public GameObject a1;
    public GameObject a2;
    public GameObject a3;

    public GameObject xue;

    public void death(Transform victim, Quaternion e)  //death（受害者，攻击旋转角度）
    {

        Quaternion qqqq = e;
        Vector3 wwww = victim.position;
        random(qqqq,wwww);
        Instantiate(xue,victim);
    }


    void random(Quaternion qqqq,Vector3 wwww)   //随机渲染预制体（血）
    {
        int val = Random.Range(0, 4); //随机函数
        if (val == 0)
        {
            Instantiate(a0, wwww, qqqq);
        }
        if (val == 1)
        {
            Instantiate(a1, wwww, qqqq);
        }
        if (val == 2)
        {
            Instantiate(a2, wwww, qqqq);
        }
        if (val == 3)
        {
            Instantiate(a3, wwww, qqqq);
        }
    }


}
