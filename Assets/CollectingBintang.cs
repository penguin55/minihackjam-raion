using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingBintang : MonoBehaviour
{
    public string usiaBintang;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);
        if (collision.collider.name == usiaBintang)
        {
            Destroy(this.gameObject);
        } 
        
    }
}


