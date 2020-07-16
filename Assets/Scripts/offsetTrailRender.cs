using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offsetTrailRender : MonoBehaviour
{

    public Vector2 childOffSet;
    public Vector2 teenOffSet;
    public Vector2 elderOffSet;

    public PlayerBehaviour player;


    void Start()
    {
        
    }

    void Update()
    {
        if(player.GetPlayerType() == PlayerData.Type.CHILD)
        {
            if (player.getFacing())
            {
                childOffSet.x = Mathf.Abs(childOffSet.x);
            }
            else
            {
                childOffSet.x = Mathf.Abs(childOffSet.x)*-1;
            }
            transform.localPosition = childOffSet;
        }
        else if (player.GetPlayerType() == PlayerData.Type.TEEN)
        {
            if (player.getFacing())
            {
                teenOffSet.x = Mathf.Abs(teenOffSet.x);
            }
            else
            {
                teenOffSet.x = Mathf.Abs(teenOffSet.x) * -1;
            }
            transform.localPosition = teenOffSet;
        }
        else if (player.GetPlayerType() == PlayerData.Type.ELDER)
        {
            if (player.getFacing())
            {
                elderOffSet.x = Mathf.Abs(elderOffSet.x);
            }
            else
            {
                elderOffSet.x = Mathf.Abs(elderOffSet.x) * -1;
            }
            transform.localPosition = elderOffSet;
        }
    }
}
