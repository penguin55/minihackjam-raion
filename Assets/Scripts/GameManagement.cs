using System.Collections;
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
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {

    }

}
