using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void startGame()
    {
        Player.anim.Play("Run");
        gameObject.SetActive(false);
        GameManager.getInstance().isPlaying = true;
    }

    IEnumerator playAnim()
    {
        yield return new WaitForSeconds(5f);
        //play different idle animations
    }

    public void showSettings()
    {
        gameObject.SetActive(false);
       GameManager.getInstance().settings.SetActive(true);
    }

    public void quit()
    {
        Application.Quit();
    }
}
