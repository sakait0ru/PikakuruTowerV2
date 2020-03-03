using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public GameObject cameraRight;
    public GameObject cameraLeft;

    public GameObject cameraCenter;


    // ステージ遷移用
    public void StageMove(string StageLevel)
    {
        SceneManager.LoadScene(StageLevel);
    }

    // カメラのOn/Off
    public void CameraChange()
    {

        if (GameManeger.Instance.isCameraVR)
        {
            // VRだったら
            GameManeger.Instance.isCameraVR = false;

            cameraRight.SetActive(false);
            cameraLeft.SetActive(false);

            cameraCenter.SetActive(true);
        }
        else
        {
            // VRじゃなかったらVRにする
            GameManeger.Instance.isCameraVR = true;

            cameraRight.SetActive(true);
            cameraLeft.SetActive(true);

            cameraCenter.SetActive(false);

        }
    }

}
