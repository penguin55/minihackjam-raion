using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPointMovement : MonoBehaviour
{
    //[Tooltip("Pakai x = 1 buat gerak horizontal, y = 1 buat gerak vertikal. Keduanya buat diagonal")] 
    //public Vector2 direction;

    //[Tooltip("Biar jauh dan lebar pergerakan moving platformnya, geraknya pakai acuan titik tengah dari platform ini")]
    //public float amplitudo;
    public float kecepatan;

    public Transform pointA;
    public Transform pointB;

    private Vector3 targetPos;
    private Vector3 targetRef;

    private void Start()
    {
        int i = 0;
        foreach(Transform child in transform)
        {
            child.position = new Vector3(child.position.x, pointA.position.y, child.position.z);

            while (i == 0)
            {
                targetRef = child.position;
                i = 1;
            }
        }
    }

    void Update()
    {
        //transform.position = basePosition + (Vector3) (direction * amplitudo * Mathf.Sin((Time.time) * kecepatan));
        posCheck();
    }

    void posCheck()
    {
        if (targetRef.Equals(pointA.transform.position))
        {
            print("yyet");
            targetPos = pointB.transform.position;
            foreach (Transform child in transform)
            {
                child.position = Vector3.Lerp(child.position, targetPos, Time.deltaTime * kecepatan);
            }
        }
        else if(targetRef.Equals(pointB.transform.position))
        {
            print("yyet");
            targetPos = pointA.transform.position;
            foreach (Transform child in transform)
            {
                child.position = Vector3.Lerp(child.position, targetPos, Time.deltaTime * kecepatan);
            }
        }
    }
}
