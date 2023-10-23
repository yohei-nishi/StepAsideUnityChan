using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefab������
    public GameObject carPrefab;
    //coinPrefab������
    public GameObject coinPrefab;
    //cornPrefab������
    public GameObject conePrefab;
    //�X�^�[�g�n�_
    private int startPos = 80;
    //�S�[���n�_
    private int goalPos = 360;
    //�A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;

    //Unity�����̃Q�[���I�u�W�F�N�g
    private GameObject unitychan;
    //�A�C�e���̐����Ԋu
    int itemDistance = 15;
    //�A�C�e���̐�����
    int itemNum;
    //unity�����ƃA�C�e���̋���
    private float difference;
    //�A�C�e�������ꏊ
    private float[] itemPosZ;
    //itemPosZ�̔z��ԍ�
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        //unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");
        //�A�C�e���̌����v�Z
        this.itemNum= (goalPos - startPos) / itemDistance;
        //itemPosZ�̒�����itemNum�ɂ��Ď��Ԃ��쐬
        this.itemPosZ = new float[itemNum];
        //������starPosZ����
        itemPosZ[0] = startPos;
        //��2���ȍ~���v�Z
        for (int i = 1; i < itemPosZ.Length; i++)
        {
            itemPosZ[i] = itemPosZ[i - 1] + itemDistance;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        {
            //difference���v�Z���đ��
            if (index < itemPosZ.Length)
            {
                this.difference = itemPosZ[index] - unitychan.transform.position.z;
            }
            

            //�����ꏊ��50m��O�ɓ��B�����Ƃ���x�������O���o��
            if (index < itemPosZ.Length && this.difference <= 50)
            {
                //�ǂ̃A�C�e�����o���̂��������_���ɐݒ�
                int num = Random.Range(1, 11);
                if (num <= 2)
                {
                    //�R�[����x�������Ɉ꒼���ɐ���
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrefab);
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, itemPosZ[index]);
                    }
                }
                else
                {

                    //���[�����ƂɃA�C�e���𐶐�
                    for (int j = -1; j <= 1; j++)
                    {
                        //�A�C�e���̎�ނ����߂�
                        int item = Random.Range(1, 11);
                        //�A�C�e����u��Z���W�̃I�t�Z�b�g�������_���ɐݒ�
                        int offsetZ = Random.Range(-5, 6);
                        //60%�R�C���z�u:30%�Ԕz�u:10%�����Ȃ�
                        if (1 <= item && item <= 6)
                        {
                            //�R�C���𐶐�
                            GameObject coin = Instantiate(coinPrefab);
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, itemPosZ[index] + offsetZ);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            //�Ԃ𐶐�
                            GameObject car = Instantiate(carPrefab);
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, itemPosZ[index] + offsetZ);
                        }
                    }
                }

                //����index��
                index++;
            }

        }

       

    }
}
