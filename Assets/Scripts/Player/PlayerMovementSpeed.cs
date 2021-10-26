using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSpeed : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool isJumping = false;

    float jumpCounter;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y += gravity * Time.deltaTime;

        if(!isGrounded) transform.Translate(velocity * Time.deltaTime);

    }

    public void PerformJump()
    {
        if (isGrounded)
        {
            isGrounded = false;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }
    }

    public void StopJump()
    {
        if(!isGrounded)
        {
            if (velocity.y > 0f) velocity.y /= jumpHeight;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }
}
