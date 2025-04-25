using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    Rigidbody2D playerRigidBody;
    public InputAction rightAction;
    public InputAction leftAction;
    public InputAction upAction;
    public float speed = 3.0f;
    public float jumpVel = 10.0f;
    private float horizontal = 1;
    bool grounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        leftAction.Enable();
        rightAction.Enable();
        upAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // left right movement
        if (rightAction.IsPressed())
        {
            playerRigidBody.linearVelocity = new Vector2(speed, playerRigidBody.linearVelocityY);
            horizontal = 1;
        }
        else if (leftAction.IsPressed())
        {
            playerRigidBody.linearVelocity = new Vector2(-speed, playerRigidBody.linearVelocityY);
            horizontal = -1;
        }
        else
        {
            // stop player when not inputting left and right
            playerRigidBody.linearVelocity = new Vector2(0, playerRigidBody.linearVelocityY);
        }

        // jump
        if (upAction.IsPressed())
        {
            if (grounded)
            {
                playerRigidBody.linearVelocity = new Vector2(playerRigidBody.linearVelocityX, jumpVel);
                grounded = false;
            }
        }
        // controllable jump height
        if (upAction.WasReleasedThisFrame())
        {
            playerRigidBody.linearVelocity = new Vector2(playerRigidBody.linearVelocityX, playerRigidBody.linearVelocityY / 2);
        }

        // flip character
        if (horizontal > 0.1f)
        {
            transform.localScale = Vector3.one;
        }
        else if(horizontal < -0.1f)
        {
            transform.transform.localScale = new Vector3(-1,1,1);
        }

        
    }

    // Checking if grounded
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
