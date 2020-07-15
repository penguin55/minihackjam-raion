using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingBintang : MonoBehaviour
{
    public PlayerData.Type usiaBintang;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerBehaviour player = collision.gameObject.GetComponent<PlayerBehaviour>();
            if (player.GetPlayerType() == usiaBintang)
            {
                player.AddStar();
                Destroy(this.gameObject);
            }
        }
    }
}


