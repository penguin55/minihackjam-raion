using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private void Start()
    {
        TransitionManager.Instance.FadeOut(null);
    }

    public void StartGame()
    {
        TransitionManager.Instance.FadeIn(StartLevelGame);
    }

    public void Quit()
    {
        TransitionManager.Instance.FadeIn(ExitGame);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void StartLevelGame()
    {
        Debug.Log("Test");
        SceneManager.LoadScene("Ngetest");
    }
}
