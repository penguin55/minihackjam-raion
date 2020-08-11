using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingPieces : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SavingSystem.piecesAmount++;
        Destroy(this.gameObject);
        Debug.Log(SavingSystem.piecesAmount);
    }
}
