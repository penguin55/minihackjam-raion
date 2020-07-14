using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingBintang : MonoBehaviour
{
    public PlayerData.Type usiaBintang;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            PlayerBehaviour player = collision.gameObject.GetComponent<PlayerBehaviour>();
            if(player.GetPlayerType() == usiaBintang)
            {
                player.AddStar();
                Destroy(this.gameObject);
            }
        }
    }
}


