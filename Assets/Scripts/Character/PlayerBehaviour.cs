using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] protected PlayerInfo info;
    [SerializeField] protected Rigidbody2D rigid;
    [SerializeField] protected SpriteRenderer renderer;
    [SerializeField] protected Animator animator;


    protected bool isJump;
    protected Vector2 directionMove;
    protected bool onJump;
    protected bool onGround;

    protected float timeMoveElapsed;
    protected bool isAccelerating;
    [SerializeField] protected float timeToAccelerate;
    [SerializeField] protected float timeToStop;


    protected void MoveAccelerate()
    {
        if (isAccelerating)
        {
            Accelerate();
            Move(timeMoveElapsed / timeToAccelerate);
        }
        else
        {
            Stop();
            Move(timeMoveElapsed / timeToStop);
        }
    }

    protected void MoveLinear()
    {
        Move(1);
    }

    protected void Jump()
    {
        onJump = true;
        rigid.AddForce(Vector2.up * info.ActivePlayerData.jumpPower, ForceMode2D.Impulse);
        animator.SetTrigger("Jump");
    }

    protected void Facing(int direction)
    {
        if (direction > 0)
        {
            renderer.flipX = false;
        }

        if (direction < 0)
        {
            renderer.flipX = true;
        }
    }

    protected void LandingCheck()
    {
        if (onGround && onJump && rigid.velocity.y == 0)
        {
            onJump = false;
            animator.SetTrigger("Landing");
        }
    }

    private void Move(float accelerate)
    {
        transform.Translate(info.ActivePlayerData.movementSpeed * directionMove * Time.deltaTime * accelerate);

        if (accelerate == 0)
        {
            animator.SetBool("Idle", true);
        } else
        {
            animator.SetBool("Idle", false);
        }
    }

    private void Accelerate()
    {
        timeMoveElapsed += Time.deltaTime;

        if (timeMoveElapsed >= timeToAccelerate) timeMoveElapsed = timeToAccelerate;
    }

    private void Stop()
    {
        timeMoveElapsed -= Time.deltaTime;

        if (timeMoveElapsed <= 0) timeMoveElapsed = 0;
    }

    public void GetNextType()
    {
        info.GetNextType();
        renderer.sprite = info.ActivePlayerData.defaultSprite;
        animator.runtimeAnimatorController = info.ActivePlayerData.animator;

        animator.SetBool("Idle", true);
    }

    public void AddStar()
    {
        info.ActivePlayerData.starCollects++;
    }

    public bool checkStar()
    {
        foreach (PlayerData dataInfo in info.PlayersData)
        {
            if (dataInfo.starCollects == 0) return false;
        }

        return true;
    }

    public void nullStar()
    {
        info.ActivePlayerData.starCollects = 0;
    }

    public PlayerData.Type GetPlayerType()
    {
        return info.ActivePlayerData.type;
    }

    public void WalkAnimationSync()
    {
        //AudioManager.Instance.PlaySFX("Walk");
        //Baru dummy
    }
}
