using UnityEngine;
public class PlayerController : PlayerBehaviour
{
    [SerializeField] private KeyCode moveRight = KeyCode.D;
    [SerializeField] private KeyCode moveLeft = KeyCode.A;
    [SerializeField] private KeyCode jump = KeyCode.Space;

    private void Start()
    {
        info.UpdateType();
    }

    void Update()
    {
        Controller();
    }

    private void FixedUpdate()
    {
        if (isJump)
        {
            isJump = false;
            Jump();
        }
    }

    void Controller()
    {
        if (Input.GetKeyDown(jump))
        {
            isJump = true;
        }

        directionMove = Vector2.zero;

        if (Input.GetKey(moveLeft))
        {
            directionMove += Vector2.left;
        }

        if (Input.GetKey(moveRight))
        {
            directionMove += Vector2.right;
        }
    }
}
