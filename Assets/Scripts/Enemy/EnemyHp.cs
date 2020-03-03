using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField]
    private float enemyHP = 50;

    public bool isDead = false;

    public AudioClip sound1;

    public AudioSource audioSource;

    public GameObject kiraEfk;

    public bool notBoss = true;

    public GameObject efkDead;
    public AudioClip attacksound;
    bool isded = false;

    public BOSSController boscon;

    // Start is called before the first frame update
    void Start()
    {
        if (!audioSource)
        {
            audioSource = GetComponent<AudioSource>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (notBoss)
        {

            if (isDead)
            {
                var pos = transform.position;
                pos.y -= Time.deltaTime;
                transform.position = pos;

                if (pos.y < -5f)
                {
                    GameManeger.Instance.DeathEnemyCount();
                    // 敵が０で、生成し終えていたら
                    if (GameManeger.Instance.enemyFix && GameManeger.Instance.GetEnemyCount() <= 0)
                    {
                        //GameManeger.Instance.GameClear();
                        // ボスを出す
                        GameManeger.Instance.BossCreate();
                        Destroy(this.gameObject);
                    }
                    Destroy(this.gameObject);
                }
            }
        }
    }

    // ダメージ
    public void Damege()
    {
        if (notBoss)
        {

            if (GetComponent<EnemyController>().m_isSpawn)
            {
                enemyHP--;
            }
            if (enemyHP <= 0)
            {

                // 音とエフェクトの再生
                audioSource.PlayOneShot(sound1);
                Instantiate(kiraEfk, this.transform.position, Quaternion.identity);


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
        else
        {
            // ボスだったら
            enemyHP--;
            if (enemyHP <= 0 && !isded)
            {
                // 音出して消える
                audioSource.PlayOneShot(attacksound);

                efkDead.SetActive(true);
                this.gameObject.SetActive(false);
                boscon.m_bleakepoint++;
                isded = true;
            }
        }
    }
}
