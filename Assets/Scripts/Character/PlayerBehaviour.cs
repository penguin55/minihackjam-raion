using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] protected PlayerInfo info;
    [SerializeField] protected Rigidbody2D rigid;

    protected bool isJump;
    protected Vector2 directionMove;

    protected void Move()
    {
        transform.Translate(info.ActivePlayerData.movementSpeed * directionMove * Time.deltaTime);
    }

    protected void Jump()
    {
        rigid.AddForce(Vector2.up * info.ActivePlayerData.jumpPower);
    }

    public void GetNextType()
    {
        info.GetNextType();
    }

    public void AddStar()
    {
        info.ActivePlayerData.starCollects++;
    }

    public int checkStar()
    {
        return info.ActivePlayerData.starCollects;
    }

    public void nullStar()
    {
        info.ActivePlayerData.starCollects = 0;
    }

    public PlayerData.Type GetPlayerType()
    {
        return info.ActivePlayerData.type;
    }
}
