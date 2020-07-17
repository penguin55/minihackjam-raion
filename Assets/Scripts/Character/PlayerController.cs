using UnityEngine;
public class PlayerController : PlayerBehaviour
{
    [SerializeField] private KeyCode moveRight = KeyCode.D;
    [SerializeField] private KeyCode moveLeft = KeyCode.A;
    [SerializeField] private KeyCode jump = KeyCode.Space;
    [SerializeField] private KeyCode attack = KeyCode.Q;

    private bool withAccelerate = true;

    private void Start()
    {
        info.UpdateType();
        UpdateState();
    }

    void Update()
    {
        if (GameManagement.freezing) return;

        if (withAccelerate) ControllerWithAccelerate();
        else ControllerWithoutAccelerate();

        if (Input.GetKeyDown(KeyCode.V)) withAccelerate = !withAccelerate;
        
        ControllAttack();
        LandingCheck();
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
        if (Input.GetKeyDown(jump) && !onJump)
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

    void ControllAttack()
    {
        if (canAttack && Input.GetKeyDown(attack))
        {
            Attack();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Moving"))
        {
            this.transform.parent = collision.collider.transform;
        }

        if (collision.gameObject.CompareTag("Ground") || collision.collider.tag.Equals("Moving") || collision.collider.tag.Equals("Destructible Object"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Moving"))
        {
            this.transform.parent = null;
        }

        if (collision.gameObject.CompareTag("Ground") || collision.collider.tag.Equals("Moving") || collision.collider.tag.Equals("Destructible Object"))
        {
            onGround = false;
        }
    }
}
