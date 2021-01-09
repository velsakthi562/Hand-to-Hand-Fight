using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimation playerAnimation;
    private Rigidbody rb;

    public float walkSpeed;
    public float zSpeed;

    private float rotationY = -90f;

    private float rotationSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        RotationPlayer();
        PlayerWalk();
    }
    void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        rb.velocity= new Vector3(Input.GetAxisRaw("Horizontal") * (-walkSpeed),
            rb.velocity.y, Input.GetAxisRaw("Vertical")* (-zSpeed));
    }
    void RotationPlayer()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
        }
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotationY), 0f);
        }
    }
    void PlayerWalk()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            playerAnimation.Walk(true);
        }
        else
        {
            playerAnimation.Walk(false);
        }
    }
}
