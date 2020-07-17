using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingBintang : MonoBehaviour
{
    public PlayerData.Type usiaBintang;
    [SerializeField] protected ParticleSystem partikel;
    public SpriteRenderer sprite;
    public Collider2D collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerBehaviour player = collision.gameObject.GetComponent<PlayerBehaviour>();
            if (player.GetPlayerType() == usiaBintang)
            {
                player.AddStar();
                AudioManager.Instance.PlaySFX("Collect");
                partikel.Play();
                sprite.enabled = false;
                collider.enabled = false;
                Destroy(this.gameObject, 1.14f);
            }
        }
    }
}


