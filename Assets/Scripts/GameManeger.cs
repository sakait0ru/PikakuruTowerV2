using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoSingleton<GameManeger>
{
    // このゲームが始まっているか
    bool stared = false;
    // スタートボタンが押されると消えるスプライト
    public GameObject startImages;

    [SerializeField]
    public Light directionalLight;

   // 敵の数
   [SerializeField]
    int enemyCount = 0;


    public void StartGame()
    {
        stared = true;
        directionalLight.intensity = 0.5f;
        Destroy(startImages);
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

    public void ResetGame()
    {
        SceneManager.LoadScene("stage01");
    }

}
