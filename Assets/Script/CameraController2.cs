using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    private float h;

    // Use this for initialization
    void Start()
    {
        offset = gameObject.transform.position - player.transform.position;
        // offset を y 方向と xz 方向に分解
        h = offset.y;
        offset.y = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // player の移動速度を取得（速度は RigidBody の持ち物）
        Vector3 v = player.GetComponent<Rigidbody>().velocity;
        // player が移動していれば、カメラを移動
        if (v.magnitude > 0.1f)
        {
            // xz 方向への移動に限定しておいて、その逆向きの単位ベクトルを作成し、offset の長さ分伸ばす
            v.y = 0;
            v = -v.normalized * offset.magnitude;

            // xz 上で速度と逆方向・y 方向には最初の高さ分だけ移動した場所にカメラを「なめらかに」動かす
            gameObject.transform.position = Vector3.MoveTowards(
                gameObject.transform.position,
                player.transform.position + new Vector3(0, h, 0) + v,
                0.1f);
        }

        // 動いた場所で、カメラを player に向かせる
        gameObject.transform.LookAt(player.transform.position);

    }

    void FixedUpdate()
    {

    }
}