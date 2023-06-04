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
        player.GetComponent<Player>().points.gameObject.SetActive(true);
        GameManager.getInstance().startGame();
        gameObject.SetActive(false);       
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
