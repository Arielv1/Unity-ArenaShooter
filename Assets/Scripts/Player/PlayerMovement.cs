using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 4f;
    public float movementSpeedBase = 10f;
    public float movementSpeedSprint = 20f;
    public float movementSpeedCrouch = 5f;

    private Rigidbody rigidBody;
    private Vector3 movementDirection;

    private float checkRadius = 0.75f;
    [SerializeField] Transform groundChecker;
    [SerializeField] LayerMask groundLayer;

    private float yScaleCrouch;
    private float yScaleBase;

    private float realSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        realSpeed = movementSpeedBase;
        yScaleBase = this.transform.localScale.y;
        yScaleCrouch = yScaleBase / 4;
    }

    // Update is called once per frame
    void Update()
    {
        Crouch();
        Sprint();    
        MoveInputs();
        Jump();
    }

    // Used on rigidbody when movement vector is updated to appear smoother
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidBody.MovePosition(transform.position + movementDirection.normalized * realSpeed * Time.deltaTime);

    }
    void MoveInputs()
    {
        // read movement inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movementDirection = transform.right * x + transform.forward * z; 
    }

    void Jump()
    {
        bool isGrounded = Physics.OverlapSphere(groundChecker.position,
                                                checkRadius,
                                                groundLayer).Length > 0;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Crouch()
    {
        Vector3 newScale = this.transform.localScale;
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            realSpeed = movementSpeedCrouch;
            newScale.y = yScaleCrouch;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            realSpeed = movementSpeedSprint;
            newScale.y = yScaleBase;
        }
        this.transform.localScale = newScale;

    }

    void Sprint()
    {
        // TODO - add sprint bar maybe ?
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            realSpeed = movementSpeedSprint;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            realSpeed = movementSpeedBase;
        }
    }

}