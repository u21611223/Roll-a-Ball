//Code by 21611223ns
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTurn : MonoBehaviour {
    //加速度用変数
    float vector = 0;
    //最高速度用変数
    public float MaxSpeed;

    // 移動
    void Update()
    {
        //3.5秒後に"turn_obj"を呼び出す
        Invoke("turn_obj", 3.5f);
    }

    void turn_obj()
        {
        vector += 0.01f;
        if(vector<=MaxSpeed)
            //回転をさせる
            transform.Rotate(new Vector3(0f, vector, 0f));
        else
            //MaxSppedで動作させる
            transform.Rotate(new Vector3(0f, MaxSpeed, 0f));
    }

}
