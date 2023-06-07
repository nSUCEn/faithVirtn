using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    // Variables to adjust movement speed and jump height
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpHeight = 2f;
    public float crouchHeight = 1f;
    public float rotateSpeed = 10f;

    // Variables to check if the character is grounded and crouching
    private bool isGrounded;
    private bool isCrouching;
    private float distToGround;

    // Rigidbody component for movement
    private Rigidbody rb;

    public Animator animator;
    public Transform childToRotate;
    // Start is called before the first frame update
    void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if character is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, distToGround );
        Debug.DrawLine(transform.position, transform.position + Vector3.down * distToGround, Color.red, 10f);
        if(isGrounded)
                animator.SetBool("IsJumping", false);

        // Crouching input
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = true;
            transform.localScale = new Vector3(1f, crouchHeight, 1f);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        /*// Jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            animator.SetBool("IsJumping", true);
        }
        */

        // Movement input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        Vector3 rotate = new Vector3(vertical, 0f, -horizontal);
        animator.SetBool("IsMoving", movement != Vector3.zero);

        if (isCrouching)
        {
            movement *= walkSpeed * 0.5f;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            movement *= runSpeed;
        }
        else
        {
            movement *= walkSpeed;
        }

        movement = Quaternion.Euler(0f, transform.eulerAngles.y, 0f) * movement;
        rb.MovePosition(rb.position + movement * Time.deltaTime);
        
        childToRotate.forward = Vector3.Slerp(childToRotate.forward, rotate, Time.deltaTime * rotateSpeed);
    }

}