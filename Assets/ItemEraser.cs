using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEraser : MonoBehaviour
{
    //カメラのオブジェ九t
    private GameObject mainCamera;

    //カメラとの距離
    private float difference;

    // Start is called before the first frame update
    void Start()
    {
        //カメラのオブジェクトを取得
        this.mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        //アイテムとカメラの位置の差（z座標）を求める
        this.difference =  this.transform.position.z - mainCamera.transform.position.z;

        //
        if (this.difference < 0f)
        {
            Destroy(gameObject);
        }
    }
}
