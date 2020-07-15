﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSystem : MonoBehaviour
{

    private SpriteRenderer sr;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBehaviour player = collision.gameObject.GetComponent<PlayerBehaviour>();
        if(player.checkStar())
        {
            Debug.Log("menang");
            sr = collision.gameObject.GetComponent<SpriteRenderer>();
            StartCoroutine("FadeOut");
            player.nullStar();
        }
    }

    IEnumerator FadeOut()
    {
        for (float i = 1f; i >= 0.05f; i -= 0.05f)
        {
            Color c = sr.material.color;
            c.a = i;
            sr.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
