using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpHeight;

    public bool IsOnTheGround { get; set; } = false;

    private Rigidbody2D playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void PerformJump()
    {
        if(IsOnTheGround)
        {
            playerRigidbody.AddForce(new Vector2(0, jumpHeight),ForceMode2D.Impulse);
            IsOnTheGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if (!IsOnTheGround)
                IsOnTheGround = true;
        }
    }
}
