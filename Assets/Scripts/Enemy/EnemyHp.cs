﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField]
    private float enemyHP = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ダメージ
    public void Damege()
    {
        enemyHP--;
        if(enemyHP <= 0)
        {
            GameManeger.Instance.DeathEnemyCount();
            Destroy(this.gameObject);
        }
    }
}
