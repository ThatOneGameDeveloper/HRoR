using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpForce;
    public float gravity;
    public Transform GroundCheck;
    public LayerMask layerMask;
    public bool isGrounded;
    public bool forceGround;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        float speed = 2000f;


        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            rb.AddForce(direction * speed * Time.deltaTime);
        }

        isGrounded = Physics.CheckSphere(GroundCheck.position, 0.1f, layerMask);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && forceGround)
        {
            rb.AddForce(Vector3.up * jumpForce);
            forceGround = false;
        }
        else
        {
            forceGround = true;
        }

        rb.AddForce(Vector3.down * gravity * Time.deltaTime);
    }
}
