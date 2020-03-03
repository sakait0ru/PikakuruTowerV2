using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossCreate : MonoBehaviour
{
    float time = 0;

    float crateTime = 4.0f;

    public AudioSource mainBGM;
    public AudioClip sairen;
    public AudioClip bossBGM;

    public Light directionalLight;

    public GameObject images;

    public GameObject bossPrefub;

    // Start is called before the first frame update
    void Start()
    {
        // 音を変える
        mainBGM.Stop();
        mainBGM.volume = 1;
        mainBGM.PlayOneShot(sairen);

        // スプライト出現
        images.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;


        // 色を赤にする
        float raito = Mathf.PingPong(time, 0.5f);
        Color newCol = Color.white;
        newCol.g -= raito;
        newCol.b -= raito;


        directionalLight.color = newCol;

        //directionalLight


        if (time <= crateTime)
        {
        }
        else
        {
            mainBGM.Stop();
            mainBGM.volume = 0.4f;
            mainBGM.clip = bossBGM;
            mainBGM.Play();

            // ボスを作成
            Instantiate(bossPrefub, new Vector3(0,0,22), Quaternion.identity);

            // 光を戻す
            directionalLight.color = Color.white;
            // スプライト削除
            images.SetActive(false);
            // このコンポーネントを削除
            Destroy(GetComponent<BossCreate>());
        }
    }
}
