using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    // 生成位置 前、右、左、後ろ
    [Header("1に近いほどそこから出現しやすい")]
    public GameObject[] factoryPoint = new GameObject[4];

    // 生成するもの
    public GameObject enemyObject;
        
    // 時間
    [SerializeField]
    private float time = 100.0f;
    private float createTime = 6.0f;

    // 何体敵を出すか
    public int EnemyMax = 10;
    private int EnemyNow = 0;

    void Start()
    {
        
    }

    void Update()
    {
        // ゲームがスタートしていて　かつ　敵の数が１００より少ない時
        if (GameManeger.Instance.GetStared() && GameManeger.Instance.GetEnemyCount() < 100)
        {
            time += Time.deltaTime;


            if (time > createTime)
            {
                time = 0.0f;
                // Enemyを生成
                CreateEnemy();

                if(createTime > 0.3f)
                {
                    createTime -= 0.2f;
                }
            }
        }
    }

    private void CreateEnemy()
    {
        const float range = 25;

        // 生成する位置からある程度ランダムにする
        float randomX = (Random.value * range) - (range / 2);
        float randomZ = (Random.value * range) - (range / 2);

        Vector3 selectPointPos = factoryPoint[0].transform.position;
        selectPointPos.x += randomX;
        selectPointPos.z += randomZ;
        selectPointPos.y = 0.03f;

        Instantiate(enemyObject, selectPointPos, Quaternion.identity);
    }
}
