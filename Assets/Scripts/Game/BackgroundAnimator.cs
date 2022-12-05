using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimator : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    private Renderer thisRenderer;

    void Start()
    {
        thisRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        Vector2 offset = new Vector2(Time.time * speed, 0);

        thisRenderer.material.mainTextureOffset = offset;
    }
}
