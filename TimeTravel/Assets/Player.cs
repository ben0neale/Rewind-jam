using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRB;

    public float speed = 10f;
    public float jump = 100f;
    bool IsGrounded = false;
    float jumpTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            JumpNow();
        }

    }

    private void JumpNow()
    {
        while (jumpTime > 0)
        {
            transform.position += new Vector3(0, jump * Time.deltaTime, 0);
            jumpTime -= Time.deltaTime;
        }
        IsGrounded = false;
        jumpTime = 1f;      
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGrounded = true;
    }
}
