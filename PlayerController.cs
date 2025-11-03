using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 2.0f;
    public float runSpeed = 3.0f;
    public float crawlSpeed = 1.8f;
    public float pushPullSpeed = 1.5f;
    public float jumpForce = 5f;
    public float jumpForwardSpeed = 3f;
    public float rotationSpeed = 3f;

    public Transform cameraTransform;
    private CharacterController controller;
    private Animator animator;
    private Vector3 verticalVelocity;
    private bool isJumping = false;
    private Rigidbody interactingBody = null;
    private float pushPower = 50f;
    private bool isClimbing = false;
    private bool isOnClimbable = false;
    private float climbSpeed = 1.5f;
    public Transform climbTopPoint;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (isClimbing)
        {
            ClimbingUpdate();
            return;
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);
        bool isCrawling = Input.GetKey(KeyCode.C);
        bool isPushing = Input.GetKey(KeyCode.E);
        bool isPulling = Input.GetKey(KeyCode.Q);
        bool isHanging = Input.GetKey(KeyCode.F);
        bool climbPressed = Input.GetKeyDown(KeyCode.X);

        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        Vector3 moveInput = new Vector3(h, 0, v).normalized;
        Vector3 moveDir = Vector3.zero;

        if (moveInput.magnitude > 0.1f)
        {
            Vector3 camForward = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;
            camForward.y = 0; camRight.y = 0;
            camForward.Normalize();
            camRight.Normalize();

            moveDir = camForward * moveInput.z + camRight * moveInput.x;

            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        if (isCrawling)
        {
            currentSpeed = crawlSpeed;
            moveDir = transform.forward;
        }
        else if (isPushing)
        {
            currentSpeed = pushPullSpeed;
            moveDir = transform.forward;
        }
        else if (isPulling)
        {
            currentSpeed = pushPullSpeed;
            moveDir = -transform.forward;
        }

        if (isOnClimbable && climbPressed)
        {
            StartClimbing();
            return;
        }

        if (controller.isGrounded)
        {
            if (isJumping)
            {
                isJumping = false;
                animator.SetBool("isJumping", false);
            }

            verticalVelocity = Vector3.down;

            if (jumpPressed)
            {
                verticalVelocity.y = jumpForce;
                moveDir = transform.forward;
                isJumping = true;
                animator.SetBool("isJumping", true);
            }
        }
        else
        {
            verticalVelocity += Physics.gravity * Time.deltaTime;
        }

        Vector3 horizontalMove = moveDir * currentSpeed;
        if (isJumping)
        {
            horizontalMove += transform.forward * jumpForwardSpeed;
        }

        Vector3 totalMove = horizontalMove;
        totalMove.y = verticalVelocity.y;

        controller.Move(totalMove * Time.deltaTime);

        if (interactingBody != null && (isPushing || isPulling))
        {
            Vector3 pushDir = isPushing ? transform.forward : -transform.forward;
            interactingBody.AddForce(pushDir * pushPower * Time.deltaTime, ForceMode.Force);
        }
        else
        {
            interactingBody = null;
        }

        float blendSpeed = 0f;
        if (!isCrawling && !isPushing && !isPulling && !isHanging && !isJumping && !isClimbing)
        {
            blendSpeed = moveInput.magnitude > 0.1f ? (isRunning ? 1f : 0.5f) : 0f;
        }

        animator.SetFloat("Speed", blendSpeed);
        animator.SetBool("isCrawling", isCrawling);
        animator.SetBool("isPushing", isPushing);
        animator.SetBool("isPulling", isPulling);
        animator.SetBool("isHanging", isHanging);
        animator.SetBool("isOnStairs", false);
    }

    void ClimbingUpdate()
    {
        bool climbPressed = Input.GetKeyDown(KeyCode.X);

        if (climbPressed)
        {
            ExitClimbing(false);
            return;
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 climbMove = new Vector3(h, v, 0) * climbSpeed * Time.deltaTime;

        transform.Translate(climbMove, Space.Self);

        animator.SetBool("isClimbing", true);

        if (climbTopPoint != null && transform.position.y >= climbTopPoint.position.y)
        {
            ExitClimbing(true);
        }
    }

    void StartClimbing()
    {
        isClimbing = true;
        animator.SetBool("isClimbing", true);

        controller.enabled = false;
    }

    void ExitClimbing(bool reachedTop)
    {
        isClimbing = false;
        animator.SetBool("isClimbing", false);

        if (reachedTop)
            animator.SetTrigger("Climbed");
        else
            animator.SetTrigger("FallLand");

        controller.enabled = true;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!hit.gameObject.CompareTag("Moveable")) return;

        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic) return;

        interactingBody = body;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Climbable"))
            isOnClimbable = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Climbable"))
            isOnClimbable = false;
    }
}
