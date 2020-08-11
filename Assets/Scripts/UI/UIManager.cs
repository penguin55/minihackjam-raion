using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text piecesCollected;
   
    void Update()
    {
        piecesCollected.text = SavingSystem.piecesAmount + "/15";
    }
}
