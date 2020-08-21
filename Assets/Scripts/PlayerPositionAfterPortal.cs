using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionAfterPortal : MonoBehaviour
{

    public GameObject player;
    public static bool toPortal; 

    private void Start()
    {
        if (toPortal)
        {
            player.transform.position = new Vector2(PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos"));
        }
    }

    public void SavePlayerPos(float x, float y)
    {
        PlayerPrefs.SetFloat("xPos", x);
        PlayerPrefs.SetFloat("yPos", y);
        PlayerPrefs.SetInt("saved", 1);
        PlayerPrefs.Save();
    }

    /*
    public GameObject player;

    
    void Start()
    {
        if(PlayerPrefs.GetInt("saved") == 1 && PlayerPrefs.GetInt("timeToLoad") == 1)
        {

            float px = player.transform.position.x;
            float py = player.transform.position.y;

            px = PlayerPrefs.GetFloat("xPos");
            py = PlayerPrefs.GetFloat("yPos");
            player.transform.position = new Vector3(px, py, 0);
            PlayerPrefs.SetInt("timeToLoad", 0);
            PlayerPrefs.Save();
        }
        Debug.Log(player.transform.position.x + " " + player.transform.position.y);
        isLoadPlayerPortal();
    }

    public void PlayerPosPortal()
    {
        PlayerPrefs.SetFloat("xPos", player.transform.position.x);
        PlayerPrefs.SetFloat("yPos", player.transform.position.y);
        PlayerPrefs.SetInt("saved", 1);
        PlayerPrefs.Save();
    }

    public void isLoadPlayerPortal()
    {
        PlayerPrefs.SetInt("timeToLoad", 1);
        PlayerPrefs.Save();
    }
    
    public void debugging()
    {
        Debug.Log(player.transform.position.x + " " + player.transform.position.y);
    }
    */
}
