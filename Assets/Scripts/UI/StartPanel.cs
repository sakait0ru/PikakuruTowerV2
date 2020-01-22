using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    public GyroController gyroCon;

    void Start()
    {
        if (!gyroCon)
        {
            //何も設定さていなかった時は取得
            gyroCon = GameObject.Find("CameraController").GetComponent<GyroController>();

        }
    }

    void Update()
    {
        // Aボタンを押した時にする
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Destroy(this.gameObject);

            // ジャイロの角度保存
            //gyroCon.
        }
    }
}
