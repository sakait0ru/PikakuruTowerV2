using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField]
    private float enemyHP = 50;

    public bool isDead = false;

    public AudioClip sound1;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            var pos = transform.position;
            pos.y -= Time.deltaTime;
            transform.position = pos;

            if(pos.y < -5f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    // ダメージ
    public void Damege()
    {
        if (GetComponent<EnemyController>().m_isSpawn)
        {
            enemyHP--;
        }
        if(enemyHP <= 0)
        {
            GameManeger.Instance.DeathEnemyCount();

            audioSource.PlayOneShot(sound1);

            // 動きを止める
            Destroy(GetComponent<EnemyController>());
            // 当たり判定削除
            Destroy(GetComponent<BoxCollider>());
            Destroy(GetComponent<Rigidbody>());
            // 死亡フラグたてる
            isDead = true;

            // 角度９０にする
            Vector3 z90 = new Vector3(0, 0, 90);
            var qz90 = Quaternion.Euler(z90);
            transform.rotation *= qz90;
            // ちょっと上に移動する
            var pos = transform.position;
            pos.y = pos.y + 0.5f;
            transform.position = pos;
        }
    }
}
