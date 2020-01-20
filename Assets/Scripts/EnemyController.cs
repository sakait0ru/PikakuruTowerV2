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
        
    }

    // Update is called once per frame
    void Update()
    {

        // 移動
        m_velocity += (m_target.position - transform.position);
        m_velocity *= 0.25f;
        m_velocity.y = 0;
        transform.position += m_velocity *= Time.deltaTime;

        // 向き
        var aim = m_target.position - this.transform.position;
        var look = Quaternion.LookRotation(aim);
        this.transform.localRotation = look;
    }
}
