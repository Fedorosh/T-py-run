using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSCoutner : MonoBehaviour
{
    private TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        Application.targetFrameRate = 70;
    }

    void Update()
    {
        text.text = string.Format("{0} FPS", (int)(1f / Time.unscaledDeltaTime));
    }
}
