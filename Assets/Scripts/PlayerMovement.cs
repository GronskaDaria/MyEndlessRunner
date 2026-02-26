using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public SpawnManager spawnManager;
    public Rigidbody rb;

    public float forwardSpeed = 8f;
    public float horizontalSpeed = 3f;
    public float rightLimit = 5.5f;
    public float leftLimit = -5.5f;
    public bool canMove = true;

    public LayerMask groundLayer;
    public float groundDistance = 0.2f;
    private bool isGrounded;
    public float jumpForce = 6f;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!canMove)
        {
            return;
        }
        // ruch do przodu
        Vector3 forwardMove = Vector3.forward*forwardSpeed*Time.fixedDeltaTime;
        rb.MovePosition(rb.position+forwardMove);

        // ruch w bok
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 sideMove = Vector3.right*horizontal*horizontalSpeed*Time.fixedDeltaTime;
        rb.MovePosition(rb.position+sideMove);
    }

    void Update()
    {
        isGrounded=Physics.Raycast(transform.position, Vector3.down, 0.2f);

        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            rb.linearVelocity=new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnTrigger"))
        {
            spawnManager.SpawnTriggerEntered();
        }
    }
} 
  