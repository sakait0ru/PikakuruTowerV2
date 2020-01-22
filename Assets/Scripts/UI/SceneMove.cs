using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    // ステージ遷移用
    public void StageMove(string StageLevel)
    {
        SceneManager.LoadScene(StageLevel);
    }
}
