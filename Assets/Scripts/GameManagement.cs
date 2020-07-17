using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelCongrats;
    private bool gameFreeze;
    public static bool freezing;
    public static GameManagement Instance;

    // Start is called before the first frame update
    void Start()
    {
        freezing = false;
        Instance = this;
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

    public void Resume()
    {
        Time.timeScale = 1;
        gameFreeze = false;
        panelPause.SetActive(gameFreeze);
    }

    public void Restart()
    {
        TransitionManager.Instance.FadeIn(RestartTheGame);
    }

    public void Quit()
    {
        TransitionManager.Instance.FadeIn(BackToMenu);
    }

    public void GameOver()
    {
        panelCongrats.SetActive(true);
    }

    private void StartTheGame()
    {

    }

    private void RestartTheGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
