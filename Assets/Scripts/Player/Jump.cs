using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpHeight;
    public float jumpSpeed;
    public float minimalJumpOffset;
    private float minimalJumpOffsetTemp;

    private bool isJumping = false;
    private float jumpValue;

    public bool IsOnTheGround { get; set; } = false;

    private Rigidbody2D playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        jumpValue = 0f;
        minimalJumpOffsetTemp = minimalJumpOffset;
    }

    private void OnEnable()
    {
        jumpValue = 0f;
        isJumping = false;
    }

    public void StartJumping()
    {
        if(IsOnTheGround)
        {
            minimalJumpOffsetTemp = minimalJumpOffset;
            //playerRigidbody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            isJumping = true;
            IsOnTheGround = false;
        }

    }
    public void StopJumping()
    {
        if(!IsOnTheGround)
        {
            jumpValue = 0f;
            isJumping = false;
        }
    }

    private void Update()
    {
        if (isJumping) { if (playerRigidbody.gravityScale != 0f) playerRigidbody.gravityScale = 0f; }
        else if (playerRigidbody.gravityScale != 1f) playerRigidbody.gravityScale = 1f;
    }

    private void LateUpdate()
    {
        if(isJumping && jumpValue < jumpHeight)
        {
            playerRigidbody.transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed * minimalJumpOffsetTemp);
            if(minimalJumpOffsetTemp != 0f) minimalJumpOffsetTemp = 0f;
            playerRigidbody.transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed);
            jumpValue += Time.deltaTime * jumpSpeed;
        }
        if (jumpValue >= jumpHeight) isJumping = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if (!IsOnTheGround) IsOnTheGround = true;
            if (isJumping) isJumping = false;
            if (jumpValue != 0f) jumpValue = 0f;
        }
    }
}
