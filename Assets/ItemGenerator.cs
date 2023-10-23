using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //Unityちゃんのゲームオブジェクト
    private GameObject unitychan;
    //アイテムの生成間隔
    int itemDistance = 15;
    //アイテムの生成個数
    int itemNum;
    //unityちゃんとアイテムの距離
    private float difference;
    //アイテム生成場所
    private float[] itemPosZ;
    //itemPosZの配列番号
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        //unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //アイテムの個数を計算
        this.itemNum= (goalPos - startPos) / itemDistance;
        //itemPosZの長さをitemNumにして実態を作成
        this.itemPosZ = new float[itemNum];
        //初項にstarPosZを代入
        itemPosZ[0] = startPos;
        //第2項以降を計算
        for (int i = 1; i < itemPosZ.Length; i++)
        {
            itemPosZ[i] = itemPosZ[i - 1] + itemDistance;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        {
            //differenceを計算して代入
            if (index < itemPosZ.Length)
            {
                this.difference = itemPosZ[index] - unitychan.transform.position.z;
            }
            

            //生成場所の50m手前に到達したとき一度だけログを出す
            if (index < itemPosZ.Length && this.difference <= 50)
            {
                //どのアイテムを出すのかをランダムに設定
                int num = Random.Range(1, 11);
                if (num <= 2)
                {
                    //コーンをx軸方向に一直線に生成
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrefab);
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, itemPosZ[index]);
                    }
                }
                else
                {

                    //レーンごとにアイテムを生成
                    for (int j = -1; j <= 1; j++)
                    {
                        //アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        //アイテムを置くZ座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(-5, 6);
                        //60%コイン配置:30%車配置:10%何もなし
                        if (1 <= item && item <= 6)
                        {
                            //コインを生成
                            GameObject coin = Instantiate(coinPrefab);
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, itemPosZ[index] + offsetZ);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            //車を生成
                            GameObject car = Instantiate(carPrefab);
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, itemPosZ[index] + offsetZ);
                        }
                    }
                }

                //次のindexへ
                index++;
            }

        }

       

    }
}
