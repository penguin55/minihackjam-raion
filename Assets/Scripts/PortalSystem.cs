using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalSystem : MonoBehaviour
{

    public string targetScene;

    public GameObject pointer;

    PlayerPositionAfterPortal playerPos;

    private void Start()
    {
        playerPos = FindObjectOfType<PlayerPositionAfterPortal>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().name == "testPortal")
        {
            playerPos.SavePlayerPos(this.pointer.transform.position.x, this.pointer.transform.position.y);
            PlayerPositionAfterPortal.toPortal = true;
        }

        toNextLevel();
    }

    void toNextLevel()
    {
        SceneManager.LoadScene(targetScene);
    }
}
