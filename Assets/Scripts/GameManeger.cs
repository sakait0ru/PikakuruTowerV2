using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoSingleton<GameManeger>
{
    // このゲームが始まっているか
    bool stared = false;



   // 敵の数
   [SerializeField]
    int enemyCount = 0;


    public void StartGame()
    {
        stared = true;
    }

    public void SetStared(bool b)
    {
        stared = b;
    }

    public bool GetStared()
    {
        return stared;
    }

    public void AddEnemyCount()
    {
        // EnemyControllerで呼び出し
        enemyCount++;
    }

    public void DeathEnemyCount()
    {
        // EnemyHPで呼び出し
        enemyCount--;
    }


    public int GetEnemyCount()
    {
        return enemyCount;
    }

    // ゲームオーバーの処理
    public void ResetGame()
    {
        // 動きを止める

        // ゲームオーバいらない説あるな

        // 壁に張り付く、攻撃　赤くなる　10体出てくる　全部でてくるとボス　ボス倒してClear
        SceneManager.LoadScene("stage01");
    }

    // ゲームクリアの処理
    public void GameClear()
    {
        // 明るくする

        // スプライト出す
        
        // 
    }

}
