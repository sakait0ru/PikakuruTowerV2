using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    public GyroController gyroCon;

    public GameObject cameraObject;

    void Start()
    {
        if (!gyroCon)
        {
            gyroCon = GameObject.Find("CameraController").GetComponent<GyroController>();
        }

        if (!cameraObject)
        {
            cameraObject = GameObject.Find("Dive_Camera");
        }
    }

    void Update()
    {
        var cameraRot = cameraObject.transform.rotation;
        Vector3 rot = cameraRot.eulerAngles;
        if (rot.x <= 20 && rot.x >= -20 &&
            rot.y <= 20 && rot.y >= -20)
        {
            //Debug.Log("aaa");

            // Aボタンを押した時にする
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // ジャイロの角度保存
                //gyroCon.

                // gameをスタートさせる
                GameManeger.Instance.StartGame();

                // このコンポーネントを消す
                Destroy(GetComponent<StartPanel>());
            }
        }
    }
}
