using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PergerakanPlatform : MonoBehaviour
{
    [Tooltip("Pakai x = 1 buat gerak horizontal, y = 1 buat gerak vertikal. Keduanya buat diagonal")] 
    public Vector2 direction;

    [Tooltip("Biar jauh dan lebar pergerakan moving platformnya, geraknya pakai acuan titik tengah dari platform ini")]
    private float amplitudo;
    
    public float pointA;
    public float pointB;
    public float kecepatan;

    private Vector3 basePosition;



    private void Start()
    {
        amplitudo = (Mathf.Abs(pointA - pointB))/2;
        if (direction.x == 1)
        {
            transform.position = new Vector3(amplitudo/2, transform.position.y, 0);
            basePosition = new Vector3(whoIsBigger()+amplitudo, transform.position.y, 0);
        }
        else if (direction.y == 1)
        {
            transform.position = new Vector3(transform.position.x, amplitudo/2, 0);
            basePosition = new Vector3(transform.position.x, whoIsBigger() + amplitudo, 0);
        }
    }

    void Update()
    {
        transform.position = basePosition + (Vector3) (direction * amplitudo * Mathf.Sin((Time.time) * kecepatan));
    }

    private float whoIsBigger()
    {
        if (pointA > pointB)
        {
            return pointB;
        }
        else
        {
            return pointA;
        }
    }
}
