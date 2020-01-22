using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasClone : MonoBehaviour
{
    // 複製するcanvas
    public GameObject canvas;

    // 設定するカメラ（Right）
    public Camera tagetCamera;

    private void Awake()
    {
        GameObject rCanvas = Instantiate(canvas);
        Canvas canvasData = rCanvas.GetComponent<Canvas>();
        canvasData.worldCamera = tagetCamera;
    }
}
