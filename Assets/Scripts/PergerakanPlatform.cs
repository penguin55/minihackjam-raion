using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PergerakanPlatform : MonoBehaviour
{
    public float amplitudo;
    public float kecepatan;

    void Update()
    {
        transform.position = new Vector3(amplitudo * Mathf.Sin((Time.time)*kecepatan), this.transform.position.y, 0f);
    }
}
