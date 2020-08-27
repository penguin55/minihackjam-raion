using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorNext : MonoBehaviour
{

    [SerializeField] protected Cinemachine2D cinemachine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //cinemachine.activeCameraBoundary[Cinemachine2D.toNextLevel].triggerDoorNext.SetActive(false);
        Cinemachine2D.toNextLevel++;
        for (int i = 0; i < cinemachine.activeCameraBoundary.Length; i++)
        {
            if (i == Cinemachine2D.toNextLevel)
            {
                cinemachine.activeCameraBoundary[Cinemachine2D.toNextLevel].triggerDoorPrev.SetActive(true);
                cinemachine.activeCameraBoundary[Cinemachine2D.toNextLevel].triggerDoorNext.SetActive(true);
            }
            else
            {
                cinemachine.activeCameraBoundary[i].triggerDoorPrev.SetActive(false);
                cinemachine.activeCameraBoundary[i].triggerDoorNext.SetActive(false);
            }
        }


    }
}
