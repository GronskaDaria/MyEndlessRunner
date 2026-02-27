using System.Collections;
using UnityEngine;
using static Camera;

public class PlayerMovement : MonoBehaviour
{
    public SpawnManager spawnManager;
    public Rigidbody rb;
    public Animator animator;
    public Camera camShake;
    public GameObject Fade;
    [SerializeField] AudioSource collisionFX;

    public float forwardSpeed = 8f;
    public float horizontalSpeed = 6f;
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
        Vector3 forwardMove = Vector3.forward*forwardSpeed*Time.fixedDeltaTime;
        rb.MovePosition(rb.position+forwardMove);

        float horizontal = Input.GetAxis("Horizontal");
        Vector3 sideMove = Vector3.right*horizontal*horizontalSpeed*Time.fixedDeltaTime;

        Vector3 newPosition = rb.position+sideMove;

        newPosition.x=Mathf.Clamp(newPosition.x, leftLimit, rightLimit);

        rb.MovePosition(newPosition);
    }

    void Update()
    {
        Jump();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnTrigger"))
        {
            spawnManager.SpawnTriggerEntered();
        }
        if (other.CompareTag("Obstacle"))
        {
            StartCoroutine(OnEnterEnd());
        }
    }

    private void AnimationJump()
    {
        animator.SetTrigger("IsJump");
    }

    private void Jump()
    {
        isGrounded=Physics.Raycast(transform.position, Vector3.down, groundDistance);
        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            AnimationJump();
            rb.AddForce(Vector3.up*jumpForce, ForceMode.VelocityChange);
        }
        bool isRunning =isGrounded?true:false;
        animator.SetBool("IsRunning", isRunning);
    }

    IEnumerator OnEnterEnd() 
    {
        animator.SetBool("IsStumbled", true);
        collisionFX.Play();
        StartCoroutine(camShake.Shake(0.15f, 0.15f));
        yield return new WaitForSeconds(3);
        Fade.SetActive(true);
    }
} 
  