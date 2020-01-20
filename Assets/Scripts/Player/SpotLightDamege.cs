using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightDamege : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
    }

    // 触れた時
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHp>().Damege();
        }
    }
    
    // 触れている間
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHp>().Damege();
        }
    }
}
