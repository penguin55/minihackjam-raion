using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PergerakanPlatform : MonoBehaviour
{
    [Tooltip("Pakai x = 1 buat gerak horizontal, y = 1 buat gerak vertikal. Keduanya buat diagonal")] 
    public Vector2 direction;

    [Tooltip("Biar jauh dan lebar pergerakan moving platformnya, geraknya pakai acuan titik tengah dari platform ini")]
    public float amplitudo;
    public float kecepatan;

    private Vector3 basePosition;

    private void Start()
    {
        basePosition = transform.position;
    }

    void Update()
    {
        transform.position = basePosition + (Vector3) (direction * amplitudo * Mathf.Sin((Time.time) * kecepatan));
    }
}
