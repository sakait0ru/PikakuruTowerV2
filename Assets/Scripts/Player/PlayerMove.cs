using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float m_Speed;
    
    void Start()
    {
        
    }

    void Update()
    {

        Vector3 angle = this.transform.localEulerAngles;

        // 入力
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            angle.x -= m_Speed;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            angle.x += m_Speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            angle.y -= m_Speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            angle.y += m_Speed;
        }
        // 入力終了

        this.transform.localEulerAngles = angle;

    }
}
