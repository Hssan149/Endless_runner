using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    public void startGame()
    {
        player.GetComponent<Player>().points.enabled = true;
        GameManager.getInstance().startGame();
        gameObject.SetActive(false);       
    }

    public void showSettings()
    {
        gameObject.SetActive(false);
       GameManager.getInstance().settings.SetActive(true);
    }

    public void showCredits()
    {
        gameObject.SetActive(false);
        GameManager.getInstance().credits.SetActive(true);
    }

    public void quit()
    {
        Application.Quit();
    }
}
