using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GateSystem : MonoBehaviour
{

    public bool endGame;
    public string targetScene;
    private SpriteRenderer sr;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBehaviour player = collision.gameObject.GetComponent<PlayerBehaviour>();
        if(player.checkStar())
        {
            GameManagement.freezing = true;
            sr = collision.gameObject.GetComponent<SpriteRenderer>();
            StartCoroutine("FadeOut");
            player.nullStar();
            if (endGame) {
                GameManagement.Instance.GameOver();
            }
            else
            {
                TransitionManager.Instance.FadeIn(toNextLevel);
            }
        }
    }

    IEnumerator FadeOut()
    {
        for (float i = 1f; i >= 0.00f; i -= 0.05f)
        {
            Color c = sr.material.color;
            c.a = i;
            sr.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void toNextLevel()
    {
        SceneManager.LoadScene(targetScene);
    }

}
