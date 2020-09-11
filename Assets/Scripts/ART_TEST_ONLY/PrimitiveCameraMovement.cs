using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveCameraMovement : MonoBehaviour
{
    public int moveSpeed = 10;

    private Vector2 directionMove;

    void Update()
    {
        inputCheck();
    }

    void inputCheck()
    {
        if (Input.GetKey(KeyCode.W)) directionMove = Vector2.up;
        else if (Input.GetKey(KeyCode.S)) directionMove = Vector2.down;
        else if (Input.GetKey(KeyCode.A)) directionMove = Vector2.left;
        else if (Input.GetKey(KeyCode.D)) directionMove = Vector2.right;

        primitiveCameraMove();
        directionMove = Vector2.zero;
    }

    void primitiveCameraMove()
    {
        gameObject.transform.Translate(directionMove * Time.deltaTime * moveSpeed);
    }
}
