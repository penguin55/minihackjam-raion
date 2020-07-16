using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollect : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerBehaviour player = collision.gameObject.GetComponent<PlayerBehaviour>();
                player.AddStar();
                AudioManager.Instance.PlaySFX("Collect");
                Destroy(this.gameObject);
        }
    }
}


