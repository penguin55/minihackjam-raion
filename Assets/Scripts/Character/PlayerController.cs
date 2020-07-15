using UnityEngine;
public class PlayerController : PlayerBehaviour
{
    [SerializeField] private KeyCode moveRight = KeyCode.D;
    [SerializeField] private KeyCode moveLeft = KeyCode.A;
    [SerializeField] private KeyCode jump = KeyCode.Space;

    private bool withAccelerate = true;

    private void Start()
    {
        info.UpdateType();
    }

    void Update()
    {
        if (withAccelerate) ControllerWithAccelerate();
        else ControllerWithoutAccelerate();

        if (Input.GetKeyDown(KeyCode.V)) withAccelerate = !withAccelerate;
    }

    private void FixedUpdate()
    {
        if (isJump)
        {
            isJump = false;
            Jump();
        }
    }

    void ControllerWithAccelerate()
    {
        if (Input.GetKeyDown(jump))
        {
            isJump = true;
        }

        if (Input.GetKey(moveLeft))
        {
            isAccelerating = true;
            if (directionMove != Vector2.left) timeMoveElapsed = 0;

            directionMove = Vector2.left;
            Facing(-1);
        }

        if (Input.GetKeyUp(moveLeft))
        {
            if (isAccelerating && directionMove == Vector2.left)
            {
                isAccelerating = false;
                if (timeMoveElapsed > timeToStop) timeMoveElapsed = timeToStop;
            }
        }

        if (Input.GetKey(moveRight))
        {
            isAccelerating = true;
            if (directionMove != Vector2.right) timeMoveElapsed = 0;

            directionMove = Vector2.right;
            Facing(1);
        }

        if (Input.GetKeyUp(moveRight))
        {
            if (isAccelerating && directionMove == Vector2.right)
            {
                isAccelerating = false;
                if (timeMoveElapsed > timeToStop) timeMoveElapsed = timeToStop;
            }
        }

        MoveAccelerate();
    }

    void ControllerWithoutAccelerate()
    {
        if (Input.GetKeyDown(jump))
        {
            isJump = true;
        }

        directionMove = Vector2.zero;

        if (Input.GetKey(moveLeft))
        {
            directionMove += Vector2.left;
            Facing(-1);
        }

        if (Input.GetKey(moveRight))
        {
            directionMove += Vector2.right;
            Facing(1);
        }

        MoveLinear();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Moving"))
        {
            this.transform.parent = collision.collider.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Moving"))
        {
            this.transform.parent = null;
        }
    }
}
