
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Cinemachine2D : MonoBehaviour
{

    public static Cinemachine2D cinemachine;

    private Vector2 velocity;

    public GameObject target; //Object which will following
    private Rigidbody2D velocityControl;
    private Camera cam;

    public float baseSpeed;
    private float speedMove;

    #region Bounding Cam

    #region SizeCam
    public Vector2 sizeCam;
    #endregion

    public Transform maxBound;
    public Transform minBound;
    #endregion

    private void Start()
    {
        cinemachine = this;
        velocityControl = target.GetComponent<Rigidbody2D>();
        speedMove = baseSpeed;
        cam = transform.GetComponent<Camera>();
    }

    private void Update()
    {
        speedMove = baseSpeed;
        if (cam.orthographic)
        {
            try
            {

                float posX = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref velocity.x, speedMove);
                float posY = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref velocity.y, speedMove);

                transform.position = new Vector3(posX, posY, -10);

                if (/** Bounding Cam Here */true) //For bounding cam
                {
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, minBound.position.x + sizeCam.x, maxBound.position.x - sizeCam.x), Mathf.Clamp(transform.position.y, minBound.position.y + sizeCam.y, maxBound.position.y - sizeCam.y),  -10);
                }
            }
            catch (System.Exception er)
            {

            }
        }
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
        velocityControl = target.GetComponent<Rigidbody2D>();
    }
}