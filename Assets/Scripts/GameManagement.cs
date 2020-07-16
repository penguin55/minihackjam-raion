﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    [SerializeField] private GameObject panelPause;
    private bool gameFreeze;

    // Start is called before the first frame update
    void Start()
    {
        TransitionManager.Instance.FadeOut(StartTheGame);
        AudioManager.Instance.PlayBGM("gameplay");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameFreeze = !gameFreeze;
            Pause(gameFreeze);
        }
    }

    public void Pause(bool flag)
    {
        Time.timeScale = flag ? 0 : 1; 
        panelPause.SetActive(flag);
    }

    public void Restart()
    {
        TransitionManager.Instance.FadeIn(RestartTheGame);
    }

    public void Quit()
    {

    }

    private void StartTheGame()
    {

    }

    private void RestartTheGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
