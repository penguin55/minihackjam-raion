using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour
{
    [SerializeField] private KeyCode keyToChange;
    [SerializeField] private ParticleManager particleChange;
    private PlayerBehaviour player;

    private void Update()
    {
        if (player != null)
        {
            if (Input.GetKeyDown(keyToChange))
            {
                AudioManager.Instance.PlaySFX("Transforming");
                player.GetNextType();
                particleChange.enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<PlayerBehaviour>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = null;
        }
    }
}
