using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEraser : MonoBehaviour
{
    //�J�����̃I�u�W�F��t
    private GameObject mainCamera;

    //�J�����Ƃ̋���
    private float difference;

    // Start is called before the first frame update
    void Start()
    {
        //�J�����̃I�u�W�F�N�g���擾
        this.mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        //�A�C�e���ƃJ�����̈ʒu�̍��iz���W�j�����߂�
        this.difference =  this.transform.position.z - mainCamera.transform.position.z;

        //
        if (this.difference < 0f)
        {
            Destroy(gameObject);
        }
    }
}
