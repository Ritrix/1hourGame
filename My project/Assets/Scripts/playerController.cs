using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    Rigidbody2D playerRigidBody;
    public InputAction rightAction;
    public InputAction leftAction;
    private int horizontal;
    Vector2 move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        leftAction.Enable();
        rightAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (rightAction.IsPressed())
        {
            move = Vector2.right;
        }
        else if (leftAction.IsPressed())
        {
            move = Vector2.left;
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(move);
        Vector2 position = (Vector2)transform.position + move * 3.0f * Time.deltaTime;
        playerRigidBody.MovePosition(position);
    }
}
