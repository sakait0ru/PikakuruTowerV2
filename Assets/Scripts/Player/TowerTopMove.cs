using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTopMove : MonoBehaviour
{
    [SerializeField, Header("スポットイトのオブジェクト")]
    GameObject m_SpotLight;

    void Start()
    {
        
    }

    void Update()
    {
        if (m_SpotLight)
        {
            Vector3 myAngle = this.transform.localEulerAngles;

            Vector3 spotAngle = m_SpotLight.transform.localEulerAngles;
            myAngle.y = spotAngle.y;

            this.transform.localEulerAngles = myAngle;
        }
    } 
}
