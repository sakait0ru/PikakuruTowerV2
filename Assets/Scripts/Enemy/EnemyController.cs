using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 中心に寄ってくる　角度もタワーの方向を向く

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_velocity;

    [SerializeField]
    private Transform m_target;

    public GameObject m_mesh;

    // 出現したか
    public bool m_isSpawn = false;

    public float m_time = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(!m_target)
        {
            m_target = GameObject.Find("Tower").transform;
        }

        GameManeger.Instance.AddEnemyCount();

        GetComponent<Animator>().enabled = false;

        // メッシュを下にする
        var meshPos = m_mesh.transform.position;
        meshPos.y = -1;
        m_mesh.transform.position = meshPos;
    }

    // Update is called once per frame
    void Update()
    {

        // 下からでてくる
        if (m_time <= 4.0f && !m_isSpawn)
        {
            m_time += Time.deltaTime;

            var meshPos = m_mesh.transform.position;
            meshPos.y = (m_time / 4.0f) -0.5f;
            m_mesh.transform.position = meshPos;
        }
        else
        {
            m_isSpawn = true;
            GetComponent<Animator>().enabled = true;
        }


        if (m_isSpawn)
        {
            // 移動
            m_velocity = (m_target.position - transform.position);
            var vec = m_velocity.normalized;
            vec.y = 0;
            transform.position += vec *= Time.deltaTime;

            // 向き
            var aim = m_target.position - this.transform.position;
            aim.y = 0.0f;
            var look = Quaternion.LookRotation(aim);
            this.transform.localRotation = look;
        }
    }

    // 壁に触れたら攻撃する
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tower")
        {
            GameManeger.Instance.ResetGame();
        }
    }
}
