using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Text debugText;
    void Start()
    {
        debugText = GetComponent<Text>();
    }

    private void Update()
    {
        debugText.text = string.Format("Player position on Y: {0}",player.transform.position.y);
    }
}
