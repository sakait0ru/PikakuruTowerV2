using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSlider : MonoBehaviour
{
    public Slider startSlider;

    private float time;

    public bool isStart = false;
    // Start is called before the first frame update
    void Start()
    {
        startSlider.gameObject.SetActive(false);
        time = 0;
        isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 触れた時
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Camera")
        {
            startSlider.value = 0;
            time = 0;
            startSlider.gameObject.SetActive(true);
        }
    }

    // 触れている間
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Camera")
        {
            time += Time.deltaTime;
            startSlider.value = (time / 3.0f);

            if (time > 3.0f)
            {
                // スタートする
                isStart = true;
            }
        }

    }

    // 離れた時
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Camera")
        {
            startSlider.gameObject.SetActive(false);
        }
    }

}
