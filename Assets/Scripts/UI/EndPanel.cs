using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndPanel : MonoBehaviour
{
    // ゲームが始まるまでの秒数
    private float endTime = 3;
    // おわりの時間
    private float time = 0;
    [SerializeField]
    public Light directionalLight;

    // 出すオブジェクト
    public GameObject endObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time < endTime)
        {
            float ratio = time / endTime;

            // ライトを暗くする
            directionalLight.intensity = 0.5f + (0.5f * ratio);

            // fogを黒くする
            Color newCol = Color.black;
            newCol.r += ratio;
            newCol.g += ratio;
            newCol.b += ratio;

            RenderSettings.fogColor = newCol;

            Material m = new Material(RenderSettings.skybox);
            m.SetColor("_FogCol", newCol);
            RenderSettings.skybox = m;

            time += Time.deltaTime;
        }
        else
        {
            // スプライトとエフェクトをだす
            endObject.SetActive(true);
        }
    }
}
