using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    // スタートの条件用
    public GameObject cameraObject;

    private bool isStartButtonPush = false;

    // ゲームが始まるまでの秒数
    private float startTime = 3;
    // スタート押してからの時間
    private float time = 0;

    [SerializeField]
    public Light directionalLight;
    // スタートボタンが押されると消えるスプライト
    public GameObject startImages;
    private SpriteRenderer[] images;

    void Start()
    {
        if (!cameraObject)
        {
            cameraObject = GameObject.Find("Dive_Camera");
        }

        images = new SpriteRenderer[startImages.transform.childCount];
        for (int i = 0; i < startImages.transform.childCount; i++)
        {
            SpriteRenderer imgObj = startImages.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            if (imgObj)
            {
                images[i] = imgObj;
            }
        }
    }

    void Update()
    {
        var cameraRot = cameraObject.transform.rotation;
        Vector3 rot = cameraRot.eulerAngles;
        //if ((rot.y <= 50.0f) && (rot.y >= -50.0f))
        //{

            // Aボタンを押した時にする
            if (Input.GetKeyDown(KeyCode.Q) && !isStartButtonPush)
            {
                isStartButtonPush = true;
            }
        //}

        // ゲームが始まっている時
        if (isStartButtonPush)
        {
            if (time < startTime)
            {
                float ratio = time / startTime;

                // ライトを暗くする
                directionalLight.intensity = 1.0f - (0.5f * ratio);

                // fogを黒くする
                Color newCol = Color.white;
                newCol.r -= ratio;
                newCol.g -= ratio;
                newCol.b -= ratio;

                RenderSettings.fogColor = newCol;

                Material m = new Material(RenderSettings.skybox);
                m.SetColor("_FogCol", newCol);
                RenderSettings.skybox = m;

                // スタートUIを徐々にけす
                Color newCol2 = Color.white;
                newCol2.a = 1.0f - ratio;
                for (int i = 0;i < images.Length; i++)
                {
                    images[i].color = newCol2;
                }
                // スポットを点灯させる

                time += Time.deltaTime;
            }
            else
            {
                // gameをスタートさせる
                GameManeger.Instance.StartGame();

                // このコンポーネントを消す
                Destroy(GetComponent<StartPanel>());
            }


        }
        // 何秒で始まるか
        // 

        // 全部終わったらこのコーポネントを削除する。


    }
}
