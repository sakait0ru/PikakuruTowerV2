using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSController : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_velocity;

    [SerializeField]
    private Transform m_target;

    public GameObject m_mesh;

    // 出現したか
    public bool m_isSpawn = false;

    public float m_time = 0;

    public GameObject[] points = new GameObject[4];

    bool m_Dead = false;

    public int m_bleakepoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (!m_target)
        {
            m_target = GameObject.Find("Tower").transform;
        }
        GetComponent<Animator>().enabled = false;

        var meshPos = m_mesh.transform.position;
        meshPos.y = -0.5f;
        m_mesh.transform.position = meshPos;

        // ターゲットの方向を向く
        var aim = m_target.position - this.transform.position;
        aim.y = 0.0f;
        var look = Quaternion.LookRotation(aim);
        this.transform.localRotation = look;


    }

    // Update is called once per frame
    void Update()
    {
        if (!m_Dead)
        {
            // 下からでてくる
            if (m_time <= 4.0f && !m_isSpawn)
            {
                m_time += Time.deltaTime;

                var meshPos = m_mesh.transform.localPosition;
                meshPos.y = (m_time / 4.0f) - 0.5f;
                m_mesh.transform.localPosition = meshPos;
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
                vec *= 0.5f;//移動を遅く
                transform.position += vec *= Time.deltaTime;

                // 向き
                var aim = m_target.position - this.transform.position;
                aim.y = 0.0f;
                var look = Quaternion.LookRotation(aim);
                this.transform.localRotation = look;

                if (m_bleakepoint >= 4)
                {
                    // 死んでいる
                    m_Dead = true;
                    // ゲームクリアの演出を始める
                    GameManeger.Instance.GameClear();
                    m_time = 0;
                }
            }

        }
        else
        {
            //　だんだん小さくなって倒れて死ぬ
            m_time += Time.deltaTime;
            if(m_time <= 2.0f)
            {
                float raito = m_time / 2.0f;
                float sc = 13.0f - (12.0f * raito);
                transform.localScale = new Vector3(sc, sc, sc);
            }else
            {
                // 3秒以上、倒れて沈む
                Destroy(this.gameObject);
            }

            // 死んでいる時の行動
        }
    }
}
