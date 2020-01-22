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



    // Start is called before the first frame update
    void Start()
    {
        if(!m_target)
        {
            m_target = GameObject.Find("Tower").transform;
        }

        GameManeger.Instance.AddEnemyCount();
    }

    // Update is called once per frame
    void Update()
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

    // タワーに触れたらゲームオーバー
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tower")
        {
            GameManeger.Instance.ResetGame();
        }
    }
}
