using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    // 生成位置
    [Header("1に近いほどそこから出現しやすい")]
    public GameObject[] factoryPoint = new GameObject[4];

    // 生成するもの
    public GameObject createObject;

    private float time = 0.0f;
    private float createTime = 1.0f;

    // 何体敵を出すか
    public int EnemyMax = 10;
    private int EnemyNow = 0;

    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time > createTime)
        {
            time = 0.0f;
            // 一定時間がたったらランダムな生成位置からcreateObjectを生成
            // createEnemy();

            EnemyNow++;
            if(EnemyNow >= EnemyMax)
            {
                // Enemyの生成を止める
            }
        }
    }
}
