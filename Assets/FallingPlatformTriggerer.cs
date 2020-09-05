using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformTriggerer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FallingPlatform.fall = true;
    }

}
