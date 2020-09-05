using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : FallingPlatformTriggerer
{

    public static bool fall;
    public float timeToFall;

    private void Update()
    {
        if (fall)
        {
            letsFall();
            fall = false;
        }
    }

    private void letsFall()
    {
        StartCoroutine(falling());
    }

    IEnumerator falling()
    {
        yield return new WaitForSeconds(timeToFall);
        FallingPlatform parentGO = gameObject.GetComponentInParent<FallingPlatform>();
        parentGO.gameObject.SetActive(false);
    }
}
