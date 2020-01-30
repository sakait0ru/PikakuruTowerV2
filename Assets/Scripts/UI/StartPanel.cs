using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
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
    // スタートがはじまると消えるオブジェクトの親
    public GameObject startObject;

    public StartSlider startslider;
    void Start()
    {
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

        // Aボタンを押した時にする
        // スライダーが1以上になったとき
        if (startslider.isStart && !isStartButtonPush)
        {
            isStartButtonPush = true;
            Destroy(startObject);
        }

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
                // BGM 再生


                Destroy(startObject);
                // このコンポーネントを消す
                Destroy(GetComponent<StartPanel>());
            }


        }


    }
}
