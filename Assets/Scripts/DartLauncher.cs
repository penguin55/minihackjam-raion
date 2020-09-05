using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartLauncher : MonoBehaviour
{
    public Rigidbody2D peluru;
    public int arah;
    public float kecepatan;
    public float jarakWaktu;

    float waktuSebelumnya;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - waktuSebelumnya > jarakWaktu)
        {
            waktuSebelumnya = Time.time;
            Shoot();
        }
    }

    void Shoot()
    {
        Rigidbody2D peluruBaru;
        peluruBaru = Instantiate(peluru, this.gameObject.transform.position, this.gameObject.transform.rotation);
        if (arah > 0)
        {
            peluruBaru.AddForce(Vector2.right * kecepatan, ForceMode2D.Impulse);
        }
        else
        {
            peluruBaru.AddForce(Vector2.left * kecepatan, ForceMode2D.Impulse);
        }
    }
}
